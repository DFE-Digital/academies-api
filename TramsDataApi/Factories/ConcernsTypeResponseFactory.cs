using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsTypeResponseFactory
    {
        public static ConcernsTypeResponse Create(ConcernsType concernsType)
        {
            return new ConcernsTypeResponse
            {
                Name = concernsType.Name,
                Description = concernsType.Description,
                CreatedAt = concernsType.CreatedAt,
                UpdatedAt = concernsType.UpdatedAt,
                Urn = concernsType.Urn
            };
        }
    }
}