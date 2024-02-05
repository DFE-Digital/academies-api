using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Test.FakeApi
{
    public class FakeMfspApi
    {
        private IWebHost _server;

        public void Start()
        {
            _server = new WebHostBuilder().UseKestrel(x => x.ListenLocalhost(6784)).Configure(app =>
            {
                app.Run(async context =>
                {
                    if (context.Request.Method == HttpMethods.Get && context.Request.Path == "/api/v1/construct/projects")
                    {
                        var response = new ApiResponseV2<FssProjectResponse>()
                        {
                            Data = new List<FssProjectResponse>()
                            {
                                new FssProjectResponse()
                                {
                                    CurrentFreeSchoolName = "This is my free school",
                                    AgeRange = "5-11",
                                    ProjectStatus = "Open",
                                },
                                new FssProjectResponse()
                                {
                                    CurrentFreeSchoolName = "This is another free school",
                                    AgeRange = "11-16",
                                    ProjectStatus = "Open",
                                },
                            }
                        };

                        await context.Response.WriteAsJsonAsync(response);
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsync("Not found");
                    }
                });
            }).Build();

            _server.Start();
        }

        public void Stop()
        {
            _server.StopAsync().Wait();
        }
    }
}
