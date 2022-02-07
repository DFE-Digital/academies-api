using FizzWare.NBuilder;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class FssProjectResponseFactoryTests
    {
        [Fact]
        public void FssProjectResponseFactory_ReturnsNull_WhenFssProjectIsNull()
        {
            var result = FssProjectResponseFactory.Create(null);

            result.Should().BeNull();
        }

        [Fact]
        public void FssProjectResponseFactory_ReturnsFssProjectResponse()
        {
            var project = Builder<FssProject>.CreateNew().Build();

            var expected = new FssProjectResponse();

            var result = FssProjectResponseFactory.Create(project);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
