using System;
using System.Linq;
using TramsDataApi.DatabaseModels.Concerns.Case.Management.Actions.Decisions;
using TramsDataApi.RequestModels.Concerns.Decisions;

namespace TramsDataApi.Factories.Concerns.Decisions
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class DecisionFactory : IDecisionFactory 
    {
        public Decision CreateDecision(int concernsCaseId, CreateDecisionRequest request)
        {
            var decisionTypes = request.DecisionTypes.Select(x => new DecisionType(x)).ToArray();

            return Decision.CreateNew(concernsCaseId, request.CrmCaseNumber, request.RetrospectiveApproval,
                request.SubmissionRequired, request.SubmissionDocumentLink, request.ReceivedRequestDate,
                decisionTypes, request.TotalAmountRequested, request.SupportingNotes, DateTimeOffset.Now);
        }
    }
}