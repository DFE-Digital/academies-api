using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class EstablishmentListItemResponseFactory
    {
        public static EstablishmentListItemResponse Create(Establishment e)
        {
            return new EstablishmentListItemResponse
            {
                Name = e.EstablishmentName,
                Urn = e.Urn.ToString()
            };
        }
    }
}