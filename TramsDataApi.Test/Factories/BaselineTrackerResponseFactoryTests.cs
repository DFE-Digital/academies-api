using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class BaselineTrackerResponseFactoryTests
    {
        [Fact]
        public void BaselineTrackerResponseFactory_ReturnsNull_WhenBaselineTrackerIsNull()
        {
            var result = BaselineTrackerResponseFactory.Create();

            result.Should().BeNull();
        }

        [Fact]
        public void BaselineTrackerResponseFactory_ReturnsBaselineTrackerResponse()
        {
            var ifd = Builder<IfdPipeline>.CreateNew().Build();

            var result = BaselineTrackerResponseFactory.Create(ifd);

            result.Should().NotBeNull();
        }
    }
}
