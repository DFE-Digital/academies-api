using System.Threading.Tasks;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
	public class GetAcademyConversionProjectFilterParameters : IGetAcademyConversionProjectFilterParameters
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;

        public GetAcademyConversionProjectFilterParameters(
            IAcademyConversionProjectGateway academyConversionProjectGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
        }

         public async Task<ProjectFilterParameters> Execute()
         {
            return new ProjectFilterParameters
            {
                Statuses = await _academyConversionProjectGateway.GetAvailableProjectStatuses(),
                AssignedUsers = await _academyConversionProjectGateway.GetAvailableAssignedUsers()
            };
        }
    }
}
