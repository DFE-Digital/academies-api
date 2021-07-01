using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TramsDataApi.ApplyToBecome;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.Middleware;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TramsDataApi", Version = "v1"});
            });

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

            // this is a temporary solution to move academy conversion projects from mstr.IfdPipeline to sdd.AcademyConversionProject
            // once the a2b external service can write directly to trams this should be removed
            services.AddDbContext<ApplyToBecomeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHostedService<SyncAcademyConversionProjectsService>();

            services.AddUseCases();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TramsDataApi v1");
                c.SupportedSubmitMethods();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ApiKeyMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
