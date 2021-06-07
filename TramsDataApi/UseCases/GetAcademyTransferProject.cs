using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class GetAcademyTransferProject : IGetAcademyTransferProject
    {
        private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;

        public GetAcademyTransferProject(IAcademyTransferProjectGateway academyTransferProjectGateway)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
        }

        public AcademyTransferProjectResponse Execute(int urn)
        {
            return AcademyTransferProjectResponseFactory
                .Create(_academyTransferProjectGateway.GetAcademyTransferProjectByUrn(urn));
        }
    }
}