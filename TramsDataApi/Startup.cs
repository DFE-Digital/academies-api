using Dfe.Academisation.CorrelationIdMiddleware;

namespace TramsDataApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Swashbuckle.AspNetCore.SwaggerUI;
    using DatabaseModels;
    using Gateways;
    using Middleware;
    using Swagger;
    using UseCases;
    using TramsDataApi.SerilogCustomEnrichers;
    using TramsDataApi.ResponseModels;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            // EF setup
            services.AddDbContext<LegacyTramsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));// EF setup
            services.AddDbContext<TramsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITrustGateway, TrustGateway>();
            services.AddScoped<IEstablishmentGateway, EstablishmentGateway>();
            services.AddScoped<IGetTrustByUkprn, GetTrustByUkprn>();
            services.AddScoped<IGetMstrTrustByUkprn, GetMstrTrustByUkprn>();
            services.AddScoped<IGetTrustsByUkprns, GetTrustsByUkprns>();
            services.AddScoped<IGetEstablishmentByUkprn, GetEstablishment>();
            services.AddScoped<IGetEstablishmentURNsByRegion, GetEstablishmentURNsByRegion>();
            services.AddScoped<IGetEstablishmentsByTrustUid, GetEstablishmentsByTrustUid>();
            services.AddScoped<IGetEstablishments, GetEstablishments>();
            services.AddScoped<ISearchTrusts, SearchTrusts>();
            services.AddScoped<IMstrSearchTrusts, MasterSearchTrusts>();  

            services.AddScoped<IGetKeyStagePerformanceByUrn, GetKeyStagePerformanceByUrn>();
            services.AddScoped<IEducationPerformanceGateway, EducationPerformanceGateway>();
            services.AddScoped<ICensusDataGateway, CensusDataGateway>();
            services.AddScoped<IIfdPipelineGateway, IfdPipelineGateway>();

            services.AddScoped<IFssProjectGateway, FssProjectGateway>();
            services.AddScoped<IGetAllFssProjects, GetAllFssProjects>();
            
            services.AddScoped<IGetAllFssProjects, GetAllFssProjects>();
            services.AddScoped<ICorrelationContext, CorrelationContext>();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
            services.AddSwaggerGen();
            services.ConfigureOptions<SwaggerOptions>();
            services.AddUseCases();

            var appInsightsCnnStr = Configuration?.GetSection("ApplicationInsights")?["ConnectionString"];
            if (!string.IsNullOrWhiteSpace(appInsightsCnnStr))
            {
                services.AddApplicationInsightsTelemetry(opt =>
                {
                    opt.ConnectionString = appInsightsCnnStr;
                });
            }

            services.AddSingleton<IUseCase<string, ApiUser>, ApiKeyService>();
            services.AddSingleton<ApiUserEnricher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var desc in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
                }

                c.SupportedSubmitMethods(SubmitMethod.Get);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<UrlDecoderMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
