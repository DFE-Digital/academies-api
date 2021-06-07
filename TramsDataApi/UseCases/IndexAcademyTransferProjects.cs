using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public class IndexAcademyTransferProjects : IIndexAcademyTransferProjects
    {
        private readonly IAcademyTransferProjectGateway _academyTranferProjectGateway;

        public IndexAcademyTransferProjects(IAcademyTransferProjectGateway academyTransferProjectGateway)
        {
            _academyTranferProjectGateway = academyTransferProjectGateway;
        }

        public IList<AcademyTransferProjectSummaryResponse> Execute(int page)
        {
           var listOfAcademyTransferProjects = _academyTranferProjectGateway.IndexAcademyTransferProjects(page);
           
           return listOfAcademyTransferProjects
               .Select(atp => new AcademyTransferProjectSummaryResponse
               {
                   ProjectUrn = atp.Urn.ToString(),
                   OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                   TransferringAcademies = atp.TransferringAcademies.Select(ta => new TransferringAcademiesResponse
                   {
                       OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                       IncomingTrustUkprn = ta.IncomingTrustUkprn
                   }).ToList()
               }).ToList();
        }
    }
}