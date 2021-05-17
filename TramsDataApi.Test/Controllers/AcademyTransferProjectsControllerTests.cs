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
            var createAcademyTransferRequest = Builder<CreateOrUpdateAcademyTransferProjectRequest>
                .CreateNew().Build();

            var academyTransferProjectResponse = Builder<AcademyTransferProjectResponse>
                .CreateNew().Build();

            createAcademyTransferProject.Setup(a => a.Execute(createAcademyTransferRequest))
                .Returns(academyTransferProjectResponse);

            var controller = new AcademyTransferProjectController(createAcademyTransferProject.Object);
            var result = controller.Create(createAcademyTransferRequest);
            
            result.Result.Should().BeEquivalentTo(new CreatedAtActionResult("Create", null, null,academyTransferProjectResponse));
        }
    }
}