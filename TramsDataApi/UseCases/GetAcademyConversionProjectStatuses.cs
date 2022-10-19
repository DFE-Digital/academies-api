using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Gateways;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjectStatuses : IGetAcademyConversionProjectStatuses
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;        

        public GetAcademyConversionProjectStatuses(
            IAcademyConversionProjectGateway academyConversionProjectGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
        }

         public async Task<List<string>> Execute()
         {
            var statuses = await _academyConversionProjectGateway.GetAvailableProjectStatuses();

            if (!statuses.Any()) return new List<string>();
                       
            return statuses;
        }        
    }
}
