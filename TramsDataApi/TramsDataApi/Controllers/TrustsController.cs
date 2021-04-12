using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrustsController : ControllerBase
    {
        [HttpGet]
        public List<Group> Get()
        {
            return new List<Group>();
        }
    }
}