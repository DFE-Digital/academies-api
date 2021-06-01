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

            var controller = new AcademyTransferProjectController(createAcademyTransferProject.Object);
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

            var controller = new AcademyTransferProjectController(createAcademyTransferProject.Object);
            var result = controller.Create(createAcademyTransferRequest);
            
            result.Result.Should().BeEquivalentTo(new BadRequestResult());
        }
    }
}