using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
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