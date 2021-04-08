using Microsoft.AspNetCore.Mvc;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Health check ok";
        }
    }
}