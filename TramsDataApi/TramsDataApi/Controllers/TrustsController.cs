using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Data;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrustsController: ControllerBase
    {
        private readonly TramsDbContext _dbContext;

        public TrustsController(TramsDbContext context)
        {
            _dbContext = context;
        }
        
        [HttpGet]
        public IEnumerable<Group> Index()
        {
            var trusts = _dbContext.Groups;
            return trusts;
        }
    }
}