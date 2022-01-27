using Microsoft.AspNetCore.Mvc;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/")]
    public class FSSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
