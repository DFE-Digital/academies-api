using System.Linq;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class ProposedAcademyAdditionalFieldsGateway : IProposedAcademyAdditionalFieldsGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public ProposedAcademyAdditionalFieldsGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public ProposedAcademyAdditionalFields GetByUrn(int URN)
        {
            return _tramsDbContext.ProposedAcademyAdditionalFields.FirstOrDefault(x => x.URN == URN);
        }
    }
}
