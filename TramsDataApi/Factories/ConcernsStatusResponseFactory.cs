using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class ConcernsStatusResponseFactory
    {
        public  static ConcernsStatusResponse Create(ConcernsStatus concernsStatus)
        {
            return new ConcernsStatusResponse
            {
                Name = concernsStatus.Name,
                CreatedAt = concernsStatus.CreatedAt,
                UpdatedAt = concernsStatus.UpdatedAt,
                Urn = concernsStatus.Urn
            };
        }
    }
}