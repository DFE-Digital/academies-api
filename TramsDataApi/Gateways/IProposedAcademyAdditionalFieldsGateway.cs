using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IProposedAcademyAdditionalFieldsGateway
    {
        ProposedAcademyAdditionalFields GetByUrn(int URN);
    }
}
