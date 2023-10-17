using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TramsDataApi.Contracts.Test
{
    public class AcademiesApiFixture : IDisposable
    {
        private readonly IHost server;
        public Uri ServerUri { get; private set; }
        public AcademiesApiFixture()
        {
            ServerUri = new Uri("http://localhost:9223");
            server = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseUrls(ServerUri.ToString());
                    webBuilder.UseStartup<PactStartup>();
                    })
                    .Build();
            server.Start();
        }

        public void Dispose()
        {
            server.Dispose();
        }
    }
}
