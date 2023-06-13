using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyTransferProject;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public class CreateAcademyTransferProject : ICreateAcademyTransferProject
    {
        private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;
        public CreateAcademyTransferProject(IAcademyTransferProjectGateway academyTransferProjectGateway)
        {
            _academyTransferProjectGateway = academyTransferProjectGateway;
        }

        public AcademyTransferProjectResponse Execute(AcademyTransferProjectRequest request)
        {
            AcademyTransferProjects academyTransferProjectToCreate = AcademyTransferProjectFactory.Create(request);
            AcademyTransferProjects createdAcademyTransferModel =
                _academyTransferProjectGateway.SaveAcademyTransferProject(academyTransferProjectToCreate);
            return AcademyTransferProjectResponseFactory.Create(createdAcademyTransferModel);
        }
    }
}