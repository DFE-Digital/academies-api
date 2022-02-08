using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetAllFssProjectTests
    {
        [Fact]
        public void GetAll_ReturnsEmptyList_WhenNoProjectFound()
        {
            var gateway = new Mock<IFssProjectGateway>();
            gateway.Setup(g => g.GetAll())
                .Returns(new List<FssProject>());

            var useCase = new GetAllFssProject(gateway.Object);
            var result = useCase.Execute();

            result.Should().BeEquivalentTo(new List<FssProjectResponse>());
        }

        [Fact]
        public void GetAll_ShouldGetAllProjects_WhenFound()
        {
            var expectedProjects = Builder<FssProject>
                .CreateNew()
                .Build();

            var gateway = new Mock<IFssProjectGateway>();

            gateway.Setup(g => g.GetAll())
                .Returns(new List<FssProject> { expectedProjects });

            var expected = new List<FssProjectResponse>
            {
                FssProjectResponseFactory.Create(expectedProjects)
            };

            var searchTrusts = new GetAllFssProject(gateway.Object);
            var result = searchTrusts.Execute();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
