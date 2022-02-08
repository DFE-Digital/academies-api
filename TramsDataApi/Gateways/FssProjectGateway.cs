using System.Collections.Generic;
using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class FssProjectGateway : IFssProjectGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public FssProjectGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
       
        public IList<FssProject> GetAll()
        {
            return _tramsDbContext.FssProjects.ToList();
        }
    }
}
