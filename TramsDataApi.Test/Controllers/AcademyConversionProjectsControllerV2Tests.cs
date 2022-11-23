using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.UseCases;
using Xunit;
using TramsDataApi.DatabaseModels;
using System.Security.Policy;

namespace TramsDataApi.Test.Controllers
{
	public class AcademyConversionProjectsControllerV2Tests
	{
		private readonly Mock<ILogger<AcademyConversionProjectController>> _mockLogger;

		public AcademyConversionProjectsControllerV2Tests()
		{
			_mockLogger = new Mock<ILogger<AcademyConversionProjectController>>();
		}

		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenDeliveryOfficerNotAssignedFilterAppliedAndProjectsExist()
		{
			string[] projectDeliveryOfficers = { "Not Assigned" };
			const int urn = 10001;

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { ProjectStatus = null, Urn = urn, SchoolName = null } };

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), urn, It.IsAny<string>(), projectDeliveryOfficers, It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 1));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

			GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = string.Empty, Count = 1, Page = 1, RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = projectDeliveryOfficers
            };
			var result = await controller.GetConversionProjects(searchModel, urn: urn);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenDeliveryOfficerFilterAppliedAndProjectsExist()
		{
			string[] projectDeliveryOfficers = { "ADO" };
			const int urn = 10001;

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { ProjectStatus = null, Urn = urn, SchoolName = null, AssignedUser = new AssignedUser(null, "ADO", string.Empty) } };

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), urn, It.IsAny<string>(), projectDeliveryOfficers, It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 1));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);
            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = string.Empty,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = projectDeliveryOfficers
            };
            var result = await controller.GetConversionProjects(searchModel, urn: urn);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}
		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenDeliveryOfficerFilterAppliedAndNoResultsFound()
		{
			string[] projectDeliveryOfficers = { "ADO" };
			const int urn = 10001;

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 0 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse> { Paging = expectedPaging };

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(new List<AcademyConversionProjectResponse>()));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = string.Empty,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = Array.Empty<string>()
            };
            var result = await controller.GetConversionProjects(searchModel, urn: urn);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenTitleFilterAppliedAndProjectsExist()
		{
			const string projectTitle = "ATitle";
			const int urn = 10001;

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { ProjectStatus = null, Urn = urn, SchoolName = projectTitle } };

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), urn, projectTitle, It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 1));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = projectTitle,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = null
            };
            var result = await controller.GetConversionProjects(searchModel, urn: urn);
            
			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}
		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenTitleFilterAppliedAndNoResultsFound()
		{
			const string projectTitle = "ATitle";
			const int urn = 10001;

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 0 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse> { Paging = expectedPaging };

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), It.IsAny<int?>(), projectTitle, It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(new List<AcademyConversionProjectResponse>()));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = projectTitle,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = null
            };
            var result = await controller.GetConversionProjects(searchModel, urn: urn);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenRegionFiltersAppliedAndProjectsExist()
		{
			const int urn = 10001;
			int?[] projectRegionEstablishmentURNs = { urn };

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { Urn = urn } };

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), urn, It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 1));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = null,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = projectRegionEstablishmentURNs,
                DeliveryOfficerQueryString = null
            };
            var result = await controller.GetConversionProjects(searchModel, urn: urn);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithListOfAcademyConversionProjects_WhenFiltersAppliedAndProjectsExist()
		{
			const string projectStatus = "AStatus";
			const string projectTitle = "ATitle";
			string[] projectDeliveryOfficer = { "ADO" };
			const int urn = 10001;
			int?[] projectRegionEstablishmentURNs = { urn };

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var data = new List<AcademyConversionProjectResponse> { new AcademyConversionProjectResponse { ProjectStatus = projectStatus, Urn = urn, SchoolName = projectTitle } };

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 1 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), urn, It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 1));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = projectTitle,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = projectRegionEstablishmentURNs,
                DeliveryOfficerQueryString = projectDeliveryOfficer,
				StatusQueryString = new[] { projectStatus }
            };
            var result = await controller.GetConversionProjects(searchModel, urn: urn);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_ReturnsResponseWithEmptyList_WhenNoFiltersAndNoResultsFound()
		{
			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(new List<AcademyConversionProjectResponse>()));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object);

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 0 };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse> { Paging = expectedPaging };

            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = null,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = null
            };
            var result = await controller.GetConversionProjects(searchModel);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_WithPaging_AndMultiplePages_ShouldHavePagingWithValuesSetAndNextPageURLProvided()
		{
			const string expectedNextPageUrl = "?page=2&count=1";

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();

			var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };

			var data = new List<AcademyConversionProjectResponse>
			{
				new AcademyConversionProjectResponse(),
				new AcademyConversionProjectResponse()
			};

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data.Take(1).ToList(), 2));

			var controller = new AcademyConversionProjectController(
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object)
			{
				ControllerContext = controllerContext
			};

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 2, NextPageUrl = expectedNextPageUrl };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data.Take(1), expectedPaging);
            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = null,
                Count = 1,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = null
            };
            var result = await controller.GetConversionProjects(searchModel);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjects_WithPaging_AndSinglePage_ShouldHavePagingWithValuesSetAndNextPageUrlAsNull()
		{
			const string expectedNextPageUrl = null;

			var mockUseCase = new Mock<ISearchAcademyConversionProjects>();
			var controllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };

			var data = new List<AcademyConversionProjectResponse>
			{
				new AcademyConversionProjectResponse(),
				new AcademyConversionProjectResponse()
			};

			mockUseCase
				.Setup(uc => uc.Execute(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<IEnumerable<int?>>()))
				.ReturnsAsync(new PagedResult<AcademyConversionProjectResponse>(data, 2));

			var controller = new AcademyConversionProjectController(
			   mockUseCase.Object,
			   new Mock<IGetAcademyConversionProject>().Object,
			   new Mock<IUpdateAcademyConversionProject>().Object,
			   new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
			   _mockLogger.Object)
			{
				ControllerContext = controllerContext
			};

			var expectedPaging = new PagingResponse { Page = 1, RecordCount = 2, NextPageUrl = expectedNextPageUrl };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(data, expectedPaging);
            GetAcademyConversionSearchModel searchModel = new GetAcademyConversionSearchModel
            {
                TitleFilter = null,
                Count = 10,
                Page = 1,
                RegionUrnsQueryString = null,
                DeliveryOfficerQueryString = null
            };
            var result = await controller.GetConversionProjects(searchModel);

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjectById_ReturnsAcademyConversionProject_WhenIdExists()
		{
			var mockUseCase = new Mock<IGetAcademyConversionProject>();

			var academyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

			mockUseCase
				.Setup(x => x.Execute(It.IsAny<int>()))
				.Returns(Task.FromResult(academyConversionProjectResponse));

			var controller = new AcademyConversionProjectController(
				new Mock<ISearchAcademyConversionProjects>().Object,
				mockUseCase.Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object
			);

			var expectedData = new List<AcademyConversionProjectResponse> { academyConversionProjectResponse };
			var expected = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData, null);

			var result = await controller.GetConversionProjectById(It.IsAny<int>());

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetConversionProjectById_ReturnsNotFound_WhenNoConversionProjectExists()
		{
			var controller = new AcademyConversionProjectController(
				new Mock<ISearchAcademyConversionProjects>().Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object
			);

			var result = await controller.GetConversionProjectById(It.IsAny<int>());

			result.Result.Should().BeEquivalentTo(new NotFoundResult());
		}

		[Fact]
		public async Task UpdateConversionProject_Returns_UpdatedConversionProject_WhenConversionProjectExists()
		{
			var mockUseCase = new Mock<IUpdateAcademyConversionProject>();

			var updatedAcademyConversionProjectResponse = Builder<AcademyConversionProjectResponse>.CreateNew().Build();

			mockUseCase
				.Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>()))
				.Returns(Task.FromResult(updatedAcademyConversionProjectResponse));

			var controller = new AcademyConversionProjectController(
				new Mock<ISearchAcademyConversionProjects>().Object,
				new Mock<IGetAcademyConversionProject>().Object,
				mockUseCase.Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object
			);

			var expectedData = new List<AcademyConversionProjectResponse> { updatedAcademyConversionProjectResponse };
			var expectedResult = new ApiResponseV2<AcademyConversionProjectResponse>(expectedData, null);

			var result = await controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expectedResult));
		}

		[Fact]
		public async Task UpdateConversionProject_ReturnsNotFound_WhenConversionProjectExists()
		{
			var controller = new AcademyConversionProjectController(
				new Mock<ISearchAcademyConversionProjects>().Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				new Mock<IGetAcademyConversionProjectFilterParameters>().Object,
				_mockLogger.Object
			);

			var result = await
				controller.UpdateConversionProject(It.IsAny<int>(), It.IsAny<UpdateAcademyConversionProjectRequest>());

			result.Result.Should().BeEquivalentTo(new NotFoundResult());
		}

		[Fact]
		public async Task GetFilterParameters_ReturnsStatuses()
		{
			var expected = new ProjectFilterParameters
			{
				Statuses = new List<string> { "DECLINED", "APPROVED" }
			};

			var mockUseCase = new Mock<IGetAcademyConversionProjectFilterParameters>();
			mockUseCase
				.Setup(uc => uc.Execute())
				.ReturnsAsync(expected);

			var controller = new AcademyConversionProjectController(
				new Mock<ISearchAcademyConversionProjects>().Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				mockUseCase.Object,
				_mockLogger.Object
			);

			var result = await
				controller.GetFilterParameters();

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}

		[Fact]
		public async Task GetFilterParameters_ReturnsAssignedUsers()
		{
			var expected = new ProjectFilterParameters
			{
				Statuses = new List<string> { "Bob 1", "Bob 2", "Bob 3" }
			};

			var mockUseCase = new Mock<IGetAcademyConversionProjectFilterParameters>();
			mockUseCase
				.Setup(uc => uc.Execute())
				.ReturnsAsync(expected);

			var controller = new AcademyConversionProjectController(
				new Mock<ISearchAcademyConversionProjects>().Object,
				new Mock<IGetAcademyConversionProject>().Object,
				new Mock<IUpdateAcademyConversionProject>().Object,
				mockUseCase.Object,
				_mockLogger.Object
			);

			var result = await
				controller.GetFilterParameters();

			result.Result.Should().BeEquivalentTo(new OkObjectResult(expected));
		}
	}
}