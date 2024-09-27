using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Dfe.Academies.Application.Common.Behaviours;
using Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituencies;
using Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency;
using Dfe.Academies.Application.MappingProfiles;
using Dfe.Academies.Domain.Interfaces.Caching;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Infrastructure.Caching;
using Dfe.Academies.Infrastructure.Repositories;
using Dfe.Academies.Testing.Common.Helpers;
using Dfe.Academies.Utils.Caching;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dfe.PersonsApi.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 2, iterationCount: 10, invocationCount: 50)]
    public class ConstituencyQueryHandlerBenchmark
    {
        [Params("Test Constituency 1")]
        public string? ConstituencyName;

        [Params(true, false)]
        public bool IncludePerformanceBehaviour;

        private IMediator? _mediator;
        private GetMembersOfParliamentByConstituenciesQuery? _query;
        private IConstituencyRepository? _realRepository;
        private ICacheService? _cacheService;
        private IMapper? _mapper;

        [GlobalSetup]
        public void Setup()
        {
            var services = new ServiceCollection();

            var dbContext = DbContextHelper<MopContext>.CreateDbContext(services);
            _realRepository = new ConstituencyRepository(dbContext);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ConstituencyProfile>();
            });
            _mapper = config.CreateMapper();

            var httpContextAccessor = new HttpContextAccessor
            {
                HttpContext = new DefaultHttpContext()
            };

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<MemoryCacheService>();

            var cacheSettings = Options.Create(new CacheSettings
            {
                DefaultDurationInSeconds = 600, // 10 minutes
                Durations = new Dictionary<string, int>
                {
                    { nameof(GetMemberOfParliamentByConstituencyQueryHandler), 300 } // 5 minutes
                }
            });

            _cacheService = new MemoryCacheService(memoryCache, logger, cacheSettings);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetMemberOfParliamentByConstituencyQueryHandler).Assembly);

                if (IncludePerformanceBehaviour)
                {
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
                }
            });

            services.AddSingleton(loggerFactory);
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddSingleton(_realRepository);
            services.AddSingleton(_cacheService);
            services.AddSingleton(_mapper);
            services.AddSingleton<IHttpContextAccessor>(httpContextAccessor);

            var provider = services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();

            _query = new GetMembersOfParliamentByConstituenciesQuery(dbContext.Constituencies.Select(x => x.ConstituencyName).Take(100).ToList());
        }

        [Benchmark]
        public async Task RunHandlerWithCacheAsync()
        {
            await _mediator?.Send(_query!)!;
        }

        [Benchmark]
        public async Task RunHandlerWithoutCacheAsync()
        {
            var cacheKey = $"MemberOfParliament_{CacheKeyHelper.GenerateHashedCacheKey(_query?.ConstituencyNames!)}";
            _cacheService?.Remove(cacheKey);
            await _mediator?.Send(_query!)!;
        }

        public static class Program
        {
            public static void Main(string[] args)
            {
                BenchmarkRunner.Run<ConstituencyQueryHandlerBenchmark>();
            }
        }
    }
}
