using System.Collections.Generic;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class TrustResponseFactoryTests
    {
        [Fact]
        public void TrustResponseFactory_CreatesTrustResponse_FromAGroup()
        {
            var group = new Group();
            
            var ifdDataResponse = new IFDDataResponse();
            var giasDataResponse = new GIASDataResponse();
            var academyResponses = new List<AcademyResponse>();
            var expected = new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};

            var result = TrustResponseFactory.Create(group);
            expected.Should().BeEquivalentTo(result);
        }
    }
}