using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.Middleware;
using TramsDataApi.Swagger;
using TramsDataApi.UseCases;

namespace TramsDataApi
{
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
            services.AddScoped<IGetEstablishmentByUkprn, GetEstablishment>();
            services.AddScoped<IGetEstablishmentsByTrustUid, GetEstablishmentsByTrustUid>();
            services.AddScoped<ISearchTrusts, SearchTrusts>();
            services.AddScoped<ICreateAcademyTransferProject, CreateAcademyTransferProject>();
            services.AddScoped<IAcademyTransferProjectGateway, AcademyTransferProjectGateway>();
            services.AddScoped<IGetAcademyTransferProject, GetAcademyTransferProject>();
            services.AddScoped<IUpdateAcademyTransferProject, UpdateAcademyTransferProject>();
            services.AddScoped<IIndexAcademyTransferProjects, IndexAcademyTransferProjects>();
            services.AddScoped<IUpdateAcademyConversionProject, UpdateAcademyConversionProject>();
            services.AddScoped<IAddAcademyConversionProjectNote, AddAcademyConversionProjectNote>();
            services.AddScoped<IGetKeyStagePerformanceByUrn, GetKeyStagePerformanceByUrn>();
            services.AddScoped<IEducationPerformanceGateway, EducationPerformanceGateway>();
            services.AddScoped<IAcademyConversionProjectGateway, AcademyConversionProjectGateway>();
            services.AddScoped<ICensusDataGateway, CensusDataGateway>();
            services.AddScoped<IIfdPipelineGateway, IfdPipelineGateway>();
            services.AddScoped<ICreateConcernsCase, CreateConcernsCase>();
            services.AddScoped<IConcernsCaseGateway, ConcernsCaseGateway>();
            services.AddScoped<IGetConcernsCaseByUrn, GetConcernsCaseByUrn>();
            services.AddScoped<IGetConcernsCaseByTrustUkprn, GetConcernsCaseByTrustUkprn>();
            services.AddScoped<IIndexConcernsStatuses, IndexConcernsStatuses>();
            services.AddScoped<IConcernsStatusGateway, ConcernsStatusGateway>();
            services.AddScoped<IConcernsRecordGateway, ConcernsRecordGateway>();
            services.AddScoped<ICreateConcernsRecord, CreateConcernsRecord>();
            services.AddScoped<IConcernsTypeGateway, ConcernsTypeGateway>();
            services.AddScoped<IConcernsRatingGateway, ConcernsRatingsGateway>();
            services.AddScoped<IIndexConcernsRatings, IndexConcernsRatings>();
            services.AddScoped<IUpdateConcernsCase, UpdateConcernsCase>();
            services.AddScoped<IIndexConcernsTypes, IndexConcernsTypes>();
            services.AddScoped<IUpdateConcernsRecord, UpdateConcernsRecord>();
            
            services.AddScoped<IIndexConcernsMeansOfReferrals, IndexConcernsMeansOfReferrals>();
            services.AddScoped<IConcernsMeansOfReferralGateway, ConcernsMeansOfReferralGateway>();
            
            services.AddScoped<IFssProjectGateway, FssProjectGateway>();
            services.AddScoped<IGetAllFssProjects, GetAllFssProjects>();
            services.AddScoped<IUpdateConcernsRecord, UpdateConcernsRecord>();

            services.AddScoped<IA2BApplicationGateway, A2BApplicationGateway>();
            services.AddScoped<IGetA2BApplication, GetA2BApplication>();
            services.AddScoped<ICreateA2BApplication, CreateA2BApplication>();

            services.AddScoped<IGetConcernsRecordsByCaseUrn, GetConcernsRecordsByCaseUrn>();
            services.AddScoped<IGetConcernsCasesByOwnerId, GetConcernsCasesByOwnerId>();
            services.AddScoped<IGetAllFssProjects, GetAllFssProjects>();

            services.AddScoped<ISRMAGateway, SRMAGateway>();
            services.AddScoped<IFinancialPlanGateway, FinancialPlanGateway>();
            services.AddScoped<INTIUnderConsiderationGateway, NTIUnderConsiderationGateway>();
            services.AddScoped<INTIWarningLetterGateway, NTIWarningLetterGateway>();
            services.AddScoped<INoticeToImproveGateway, NoticeToImproveGateway>();

            services.AddScoped<IGetAcademyConversionProject, GetAcademyConversionProject>();
            services.AddScoped<IGetAcademyConversionProjects, GetAcademyConversionProjects>();
            services.AddScoped<ISearchAcademyConversionProjects, SearchAcademyConversionProjects>();

            services.AddScoped<IGetConcernsCaseworkTeam, GetConcernsCaseworkTeam>();
            services.AddScoped<IUpdateConcernsCaseworkTeam, UpdateConcernsCaseworkTeam>();
            services.AddScoped<IConcernsTeamCaseworkGateway, ConcernsTeamCaseworkGateway>();

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

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseMiddleware<UrlDecoderMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
