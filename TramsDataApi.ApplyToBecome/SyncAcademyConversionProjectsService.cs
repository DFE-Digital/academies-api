using Cronos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace TramsDataApi.ApplyToBecome
{
    /// <summary>
    /// Adapted from https://codeburst.io/schedule-cron-jobs-using-hostedservice-in-asp-net-core-e17c47ba06
    /// </summary>
    public class SyncAcademyConversionProjectsService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly CronExpression _expression;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<SyncAcademyConversionProjectsService> _logger;

        public SyncAcademyConversionProjectsService(
            IServiceScopeFactory scopeFactory, 
            ILogger<SyncAcademyConversionProjectsService> logger,
            IConfiguration configuration)
        {
            var cronExpression = configuration.GetValue<string>("SyncAcademyConversionProjectsSchedule") ?? "0 0 1 * * *";
            _expression = CronExpression.Parse(cronExpression, CronFormat.IncludeSeconds);
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting academy conversion projects sync job");
            await ScheduleJob(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Stop();
            _logger.LogInformation("Stopping academy conversion projects sync job");
            await Task.CompletedTask;
        }

        protected async Task ScheduleJob(CancellationToken cancellationToken)
        {
            var next = _expression.GetNextOccurrence(DateTimeOffset.Now, TimeZoneInfo.Local);
            _logger.LogInformation("Next schedule to run academy conversion projects sync is {next}", next.ToString());
            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds <= 0)   // prevent non-positive values from being passed into Timer
                {
                    await ScheduleJob(cancellationToken);
                }
                _timer = new Timer(delay.TotalMilliseconds);
                _timer.Elapsed += async (sender, args) =>
                {
                    _timer.Dispose();  // reset and dispose timer
                    _timer = null;

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            await DoWork(cancellationToken);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("Academy conversion project sync failed", ex);
                        }
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await ScheduleJob(cancellationToken);    // reschedule next
                    }
                };
                _timer.Start();
            }
            await Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplyToBecomeDbContext>();
            var academyConversionProjectIds = await dbContext.AcademyConversionProjects.Select(acp => acp.IfdPipelineId).ToArrayAsync(cancellationToken);
            var ifdPipelineIds = await dbContext.IfdPipeline.Select(ip => ip.Sk).ToArrayAsync(cancellationToken);

            var ifdPipelinesToSync = ifdPipelineIds.Where(id => academyConversionProjectIds.All(acpId => acpId != id)).ToArray();

            foreach (var id in ifdPipelinesToSync)
            {
                _logger.LogInformation("Syncing academy conversion project with ID {id}", id);
                var ifdPipeline = await dbContext.IfdPipeline.SingleOrDefaultAsync(ip => ip.Sk == id, cancellationToken);
                var academyConversionProject = SyncAcademyConversionProjectFactory.Create(ifdPipeline);
                await dbContext.AcademyConversionProjects.AddAsync(academyConversionProject, cancellationToken);
            }
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
