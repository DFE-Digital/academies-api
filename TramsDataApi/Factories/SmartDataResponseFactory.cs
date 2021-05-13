using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public static class SmartDataResponseFactory
    {
        public static SMARTDataResponse Create(SmartData smartData)
        {
            if (smartData == null)
            {
                return null;
            }
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