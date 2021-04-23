using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public static class TrustResponseFactory
    {
        public static TrustResponse Create(Group group)
        {
            var ifdDataResponse = new IFDDataResponse();
            var giasDataResponse = new GIASDataResponse();
            var academyResponses = new List<AcademyResponse>();
            return new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};
        }
    }
}