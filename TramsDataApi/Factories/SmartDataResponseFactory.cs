using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class SmartDataResponseFactory
    {
        public SMARTDataResponse Create(SmartData smartData)
        {
            return new SMARTDataResponse
            {
                ProbabilityOfDeclining = smartData.ProbabilityOfDeclining.ToString(),
                ProbabilityOfStayingTheSame = smartData.ProbabilityOfStayingTheSame.ToString(),
                ProbabilityOfImproving = smartData.ProbabilityOfImproving.ToString(),
                PredictedChangeInProgress8Score = smartData.PredictedChangeInProgress8Score,
                PredictedChanceOfChangeOccurring = smartData.PredictedChanceOfChangeOccuring.ToString(),
                TotalNumberOfRisks = smartData.TotalNumberOfRisks.ToString(),
                TotalRiskScore = smartData.TotalRiskScore.ToString(),
                RiskRatingNum = smartData.RiskRatingNum.ToString()
            };
        }
    }
}