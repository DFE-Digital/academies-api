using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class BaselineTrackerResponseFactoryTests
    {
        [Fact]
        public void BaselineTrackerResponseFactory_ReturnsNull_WhenBaselineTrackerIsNull()
        {
            var result = BaselineTrackerResponseFactory.Create();

            result.Should().BeEquivalentTo(new BaselineTrackerResponse());
        }

        [Fact]
        public void BaselineTrackerResponseFactory_ReturnsBaselineTrackerResponse()
        {
            var ifd = Builder<IfdPipeline>.CreateNew().Build();
            ifd.GeneralDetailsUrn = "12";

            var result = BaselineTrackerResponseFactory.Create(ifd);

            result.Should().NotBeNull();
        }
    }
}
