using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrustsController : ControllerBase
    {
        private readonly TramsDbContext _dbContext;

        public TrustsController(TramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<Group> Get()
        {
            return _dbContext.Group.ToList();
        }
    }
}