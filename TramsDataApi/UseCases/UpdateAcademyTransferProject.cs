using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class UpdateAcademyTransferProject : IUpdateAcademyTransferProject
    {
        private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;

        public UpdateAcademyTransferProject(IAcademyTransferProjectGateway academyTransferProjectGateway)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
        }

        public AcademyTransferProjectResponse Execute(int urn, AcademyTransferProjectRequest updateRequest)
        {
            var currentAcademyTransferProject = _academyTransferProjectGateway.GetAcademyTransferProjectByUrn(urn);
            var updatedAcademyTransferProject = AcademyTransferProjectFactory.Update(currentAcademyTransferProject, updateRequest);

            return AcademyTransferProjectResponseFactory.Create(_academyTransferProjectGateway.SaveAcademyTransferProject(updatedAcademyTransferProject));
        }
    }
}