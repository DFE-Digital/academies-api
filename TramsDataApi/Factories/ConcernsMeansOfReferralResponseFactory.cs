using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public static class ConcernsMeansOfReferralResponseFactory
    {
        public static ConcernsMeansOfReferralResponse Create(ConcernsMeansOfReferral concernsMeansOfReferral)
        {
            return new ConcernsMeansOfReferralResponse
            {
                Name = concernsMeansOfReferral.Name,
                Description = concernsMeansOfReferral.Description,
                CreatedAt = concernsMeansOfReferral.CreatedAt,
                UpdatedAt = concernsMeansOfReferral.UpdatedAt,
                Urn = concernsMeansOfReferral.Urn
            };
        }
    }
}