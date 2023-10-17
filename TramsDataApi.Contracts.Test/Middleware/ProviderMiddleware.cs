using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Test;

namespace TramsDataApi.Contracts.Test.Middleware
{
    public class ProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDictionary<string, Action> _providerStates;

        private readonly string urn = "999999";
        public ProviderMiddleware(RequestDelegate next)
        {
            _next = next;
            _providerStates = new Dictionary<string, Action>
            {
                {
                    $"An application with ID {urn} exists",
                    CreateEstablishment(urn)
                },
                {
                    $"An application with ID {urn} does not exist",
                    DeleteEstablishment(urn)
                },
                {
                    "no specific state required",
                    NoOp
                }
            };
        }

        private Action CreateEstablishment(string urn)
        {
            Console.WriteLine("Create Establishment");
            return () => { };
        }

        private Action DeleteEstablishment(string urn)
        {
            Console.WriteLine("Delete Establishment");
            return () => { };
        }

        private void NoOp() { 
            Console.WriteLine("No provider state action required");
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/provider-states"))
            {
                await this.HandleProviderStatesRequest(context);
                await context.Response.WriteAsync(string.Empty);
            }
            else
            {
                await this._next(context);
            }
        }

        private async Task HandleProviderStatesRequest(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            if (context.Request.Method.ToUpper() == HttpMethod.Post.ToString().ToUpper() &&
                context.Request.Body != null)
            {
                string jsonRequestBody = string.Empty;
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    jsonRequestBody = await reader.ReadToEndAsync();
                }

                var providerState = JsonConvert.DeserializeObject<ProviderState>(jsonRequestBody);

                //A null or empty provider state key must be handled
                if (providerState != null && !string.IsNullOrEmpty(providerState.State))
                {
                    _providerStates[providerState.State].Invoke();
                }
            }
        }
    }
}
