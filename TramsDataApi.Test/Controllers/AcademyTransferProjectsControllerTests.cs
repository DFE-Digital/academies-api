using System;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TramsDataApi.Controllers;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class AcademyTransferProjectsControllerTests
    {
        [Fact]
        public void CreateAcademyTransferProject_Returns201WhenSuccessfullyCreatesAnAcademyTransferProject()
        {
            var createAcademyTransferProject = new Mock<ICreateAcademyTransferProject>();
            var createAcademyTransferRequest = Builder<AcademyTransferProjectRequest>
                .CreateNew().With(atp => atp.OutgoingTrustUkprn = "12345678").Build();

            var academyTransferProjectResponse = Builder<AcademyTransferProjectResponse>
                .CreateNew().Build();

            createAcademyTransferProject.Setup(a => a.Execute(createAcademyTransferRequest))
                .Returns(academyTransferProjectResponse);

            var controller = new AcademyTransferProjectController(
                createAcademyTransferProject.Object,
                new Mock<IGetAcademyTransferProject>().Object,
                new Mock<IUpdateAcademyTransferProject>().Object
            );
            var result = controller.Create(createAcademyTransferRequest);
            
            result.Result.Should().BeEquivalentTo(new CreatedAtActionResult("Create", null, null,academyTransferProjectResponse));
        }
        
        [Fact]
        public void CreateAcademyTransferProject_Returns401WhenGivenIncompleteRequest()
        {
            var createAcademyTransferProject = new Mock<ICreateAcademyTransferProject>();
            var createAcademyTransferRequest = Builder<AcademyTransferProjectRequest>
                .CreateNew().With(atp => atp.OutgoingTrustUkprn = null).Build();

            createAcademyTransferProject.Setup(a => a.Execute(createAcademyTransferRequest))
                .Throws(new Exception("Shouldn't be called."));

            var controller = new AcademyTransferProjectController(
                createAcademyTransferProject.Object,
                new Mock<IGetAcademyTransferProject>().Object,
                new Mock<IUpdateAcademyTransferProject>().Object
            );
            var result = controller.Create(createAcademyTransferRequest);
            
            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }

        [Fact]
        public void UpdateAcademyTransferProject_Returns404WhenProjectNotFound()
        {
            var urn = 10001001;
            var updateAcademyTransferProject = new Mock<IUpdateAcademyTransferProject>();
            var getAcademyTransferProject = new Mock<IGetAcademyTransferProject>();

            var updateAcademyTransferRequest = Builder<AcademyTransferProjectRequest>.CreateNew().Build();
            
            getAcademyTransferProject.Setup(useCase => useCase.Execute(urn)).Returns(() => null);

            var controller = new AcademyTransferProjectController(
                new Mock<ICreateAcademyTransferProject>().Object,
                getAcademyTransferProject.Object,
                updateAcademyTransferProject.Object
            );
            var result = controller.Update(urn, updateAcademyTransferRequest);

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }

        [Fact]
        public void UpdateAcademyTransferProject_UpdatesTheProject_WhenItIsFound()
        {
            var urn = 10000323;
            var updateAcademyTransferProject = new Mock<IUpdateAcademyTransferProject>();
            var getAcademyTransferProject = new Mock<IGetAcademyTransferProject>();

            var updateAcademyTransferRequest = Builder<AcademyTransferProjectRequest>
                .CreateNew().With(uat => uat.OutgoingTrustUkprn = "12345671").Build();
            var updateAcademyTransferResponse = Builder<AcademyTransferProjectResponse>.CreateNew().Build();
            
            getAcademyTransferProject.Setup(useCase => useCase.Execute(urn))
                .Returns(Builder<AcademyTransferProjectResponse>.CreateNew().Build);
            
            updateAcademyTransferProject.Setup(useCase => useCase.Execute(urn, updateAcademyTransferRequest))
                .Returns(updateAcademyTransferResponse);

            var controller = new AcademyTransferProjectController(
                new Mock<ICreateAcademyTransferProject>().Object,
                getAcademyTransferProject.Object,
                updateAcademyTransferProject.Object
            ); 
            var result = controller.Update(urn, updateAcademyTransferRequest);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(updateAcademyTransferResponse));
        }

        [Fact]
        public void UpdateAcademyTransferProject_ReturnsBadRequest_WhenInvalidRequestIsGiven()
        {
            var urn = 10000323;
            var updateAcademyTransferProject = new Mock<IUpdateAcademyTransferProject>();
            var getAcademyTransferProject = new Mock<IGetAcademyTransferProject>();

            var updateAcademyTransferRequest = Builder<AcademyTransferProjectRequest>
                .CreateNew().With(uat => uat.OutgoingTrustUkprn = null).Build();
            
            getAcademyTransferProject.Setup(useCase => useCase.Execute(urn))
                .Returns(Builder<AcademyTransferProjectResponse>.CreateNew().Build);

            var controller = new AcademyTransferProjectController(
                new Mock<ICreateAcademyTransferProject>().Object,
                getAcademyTransferProject.Object,
                updateAcademyTransferProject.Object
            ); 
            var result = controller.Update(urn, updateAcademyTransferRequest);

            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }

        [Fact]
        public void GetAcademyTransferProject_ReturnsNotFound_WhenAcademyTransferProjectDoesNotExist()
        {
            var urn = 10021231;
            var getAcademyTransferProject = new Mock<IGetAcademyTransferProject>();

            getAcademyTransferProject
                .Setup(get => get.Execute(urn))
                .Returns(() => null);

            var controller = new AcademyTransferProjectController(
                new Mock<ICreateAcademyTransferProject>().Object,
                getAcademyTransferProject.Object,
                new Mock<IUpdateAcademyTransferProject>().Object
            );

            var result = controller.GetByUrn(urn);

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }
    }
}