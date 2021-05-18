using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class EstablishmentSummaryResponseFactory
    {
        public static EstablishmentSummaryResponse Create(Establishment e)
        {
            return new EstablishmentSummaryResponse
            {
                Name = e.EstablishmentName,
                Urn = e.Urn.ToString()
            };
        }
    }
}