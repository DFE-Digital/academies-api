using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.ApplyToBecome;
using TramsDataApi.Test.Utils;
using Xunit;

namespace TramsDataApi.Test.ApplyToBecome
{
    [Collection("Database")]
    public class SyncAcademyConversionProjectsServiceTests : IClassFixture<TramsDataApiFactory>, IDisposable
    {
        private readonly ApplyToBecomeDbContextMock _dbContext;
        private readonly LoggerSpy<SyncAcademyConversionProjectsService> _logger;
        private readonly IConfiguration _configuration;
        private readonly DateTime _dateTime;
        private SyncAcademyConversionProjectsService _service;
        private readonly Fixture _fixture;
        private readonly CancellationTokenSource _source = new CancellationTokenSource();

        public SyncAcademyConversionProjectsServiceTests(TramsDataApiFactory fixture)
        {
            _dbContext = fixture.Services.GetRequiredService<ApplyToBecomeDbContextMock>();
            _logger = new LoggerSpy<SyncAcademyConversionProjectsService>();
            _configuration = fixture.Services.GetRequiredService<IConfiguration>();
            _dateTime = DateTime.Now.AddSeconds(2);
            _configuration["SyncAcademyConversionProjectsSchedule"] = $"{_dateTime.Second} {_dateTime.Minute} {_dateTime.Hour} * * *";
            _service = new SyncAcademyConversionProjectsService(new ScopeFactoryStub(_dbContext), _logger, _configuration);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Should_log_message_when_service_starts()
        {
            await _service.StartAsync(_source.Token);

            _source.Cancel();

            _logger.MessageSink.Should().Contain("Starting academy conversion projects sync job");
        }

        [Fact]
        public async Task Should_log_message_when_service_stops()
        {
            await _service.StopAsync(CancellationToken.None);

            _logger.MessageSink.Should().Contain("Stopping academy conversion projects sync job");
        }

        [Fact]
        public async Task Should_log_message_for_next_scheduled_time_to_do_work()
        {
            await _service.StartAsync(_source.Token);

            _dbContext.ManualResetEvent.Wait();
            _source.Cancel();

            var expect = $"Next schedule to run academy conversion projects sync is {_dateTime.ToShortDateString()} {_dateTime.ToLongTimeString()}";
            _logger.MessageSink.Should().Contain(x => Regex.IsMatch(x, expect));
        }

        [Fact]
        public async Task Should_sync_from_IfdPipeline_to_AcademyConversionProject_table()
        {
            var ifdPipelines = _fixture.Build<SyncIfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "123456")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationAy1CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy1TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy2CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy2TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy3CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy3TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .CreateMany();

            _dbContext.IfdPipeline.AddRange(ifdPipelines);
            _dbContext.SaveChanges();

            await _service.StartAsync(_source.Token);

            _dbContext.ManualResetEvent.Wait();
            _source.Cancel();

            var actual = _dbContext.AcademyConversionProjects.ToArray();
            var expected = ifdPipelines.Select(SyncAcademyConversionProjectFactory.Create).ToArray();

            actual.Should().BeEquivalentTo(expected, options => options.Excluding(x => x.Id));
        }

        [Fact]
        public async Task Should_log_message_for_each_item_to_sync()
        {
            var ifdPipelines = _fixture.Build<SyncIfdPipeline>()
                .With(x => x.GeneralDetailsUrn, "123456")
                .With(x => x.ProjectTemplateInformationFyRevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationFy1RevenueBalanceCarriedForward, _fixture.Create<decimal>().ToString)
                .With(x => x.ProjectTemplateInformationAy1CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy1TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy2CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy2TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy3CapacityForecast, _fixture.Create<int>().ToString)
                .With(x => x.ProjectTemplateInformationAy3TotalPupilNumberForecast, _fixture.Create<int>().ToString)
                .CreateMany();
            _dbContext.IfdPipeline.AddRange(ifdPipelines);
            _dbContext.SaveChanges();

            await _service.StartAsync(_source.Token);

            _dbContext.ManualResetEvent.Wait();
            _source.Cancel();

            var ipIds = ifdPipelines.Select(ip => (int)ip.Sk).ToArray();
            foreach (var id in ipIds)
            {
                _logger.MessageSink.Should().Contain(x => Regex.IsMatch(x, $"Syncing academy conversion project with ID {id}"));
            }
        }

        [Fact]
        public async Task Should_log_message_when_sync_throws_exception()
        {
            _dbContext.Exceptions.Push(new Exception());

            await _service.StartAsync(_source.Token);

            _dbContext.ManualResetEvent.Wait();
            _source.Cancel();

            _logger.MessageSink.Should().Contain(x => Regex.IsMatch(x, $"Academy conversion project sync failed"));
        }

        public void Dispose()
        {
            foreach (var entity in _dbContext.IfdPipeline)
            {
                _dbContext.IfdPipeline.Remove(entity);
            }
            foreach (var entity in _dbContext.AcademyConversionProjects)
            {
                _dbContext.AcademyConversionProjects.Remove(entity);
            }
            _dbContext.SaveChanges();
            _service.Dispose();
        }
    }
}
