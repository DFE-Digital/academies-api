using AutoFixture;
using Dfe.Academies.Application.Trust;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Trusts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TramsDataApi.Controllers.V4;
using TramsDataApi.RequestModels;

namespace Dfe.Academies.TramsDataApi.Tests.Controllers.V4
{
    public class TrustsControllerTests
    {
        private readonly Fixture _fixture = new();
        private readonly Mock<ITrustQueries> _trustQueries = new();
        private readonly Mock<ILogger<TrustsController>> _logger = new();
        private readonly TrustsController _controller;

        public TrustsControllerTests()
        {
            _controller = new TrustsController(_trustQueries.Object, _logger.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [Fact]
        public async Task GetTrustByUkprn_WhenTrustExists_ReturnsOk()
        {
            var ukprn = "10000001";
            var trust = _fixture.Build<TrustDto>().With(t => t.Ukprn, ukprn).Create();
            _trustQueries
                .Setup(q => q.GetByUkprn(ukprn, It.IsAny<CancellationToken>()))
                .ReturnsAsync(trust);

            var result = await _controller.GetTrustByUkprn(ukprn, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trust));
        }

        [Fact]
        public async Task GetTrustByUkprn_WhenTrustDoesNotExist_ReturnsNotFound()
        {
            var ukprn = "missing";
            _trustQueries
                .Setup(q => q.GetByUkprn(ukprn, It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrustDto?)null);

            var result = await _controller.GetTrustByUkprn(ukprn, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetTrustByCompaniesHouseNumber_WhenTrustExists_ReturnsOk()
        {
            var companiesHouseNumber = "12345678";
            var trust = _fixture.Build<TrustDto>().With(t => t.CompaniesHouseNumber, companiesHouseNumber).Create();
            _trustQueries
                .Setup(q => q.GetByCompaniesHouseNumber(companiesHouseNumber, It.IsAny<CancellationToken>()))
                .ReturnsAsync(trust);

            var result = await _controller.GetTrustByCompaniesHouseNumber(companiesHouseNumber, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trust));
        }

        [Fact]
        public async Task GetTrustByCompaniesHouseNumber_WhenTrustDoesNotExist_ReturnsNotFound()
        {
            var companiesHouseNumber = "missing";
            _trustQueries
                .Setup(q => q.GetByCompaniesHouseNumber(companiesHouseNumber, It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrustDto?)null);

            var result = await _controller.GetTrustByCompaniesHouseNumber(companiesHouseNumber, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetTrustByTrustReferenceNumber_WhenTrustExists_ReturnsOk()
        {
            var trustReferenceNumber = "TR00001";
            var trust = _fixture.Build<TrustDto>().With(t => t.ReferenceNumber, trustReferenceNumber).Create();
            _trustQueries
                .Setup(q => q.GetByTrustReferenceNumber(trustReferenceNumber, It.IsAny<CancellationToken>()))
                .ReturnsAsync(trust);

            var result = await _controller.GetTrustByTrustReferenceNumber(trustReferenceNumber, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trust));
        }

        [Fact]
        public async Task GetTrustByTrustReferenceNumber_WhenTrustDoesNotExist_ReturnsNotFound()
        {
            var trustReferenceNumber = "missing";
            _trustQueries
                .Setup(q => q.GetByTrustReferenceNumber(trustReferenceNumber, It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrustDto?)null);

            var result = await _controller.GetTrustByTrustReferenceNumber(trustReferenceNumber, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task SearchTrusts_WhenTrustsFound_ReturnsPagedOk()
        {
            var trusts = _fixture.CreateMany<TrustDto>(3).ToList();
            _trustQueries
                .Setup(q => q.Search(1, 10, "Alpha", It.IsAny<string>(), It.IsAny<string>(), TrustStatus.Open, It.IsAny<CancellationToken>()))
                .ReturnsAsync((trusts, trusts.Count));

            var result = await _controller.SearchTrusts("Alpha", string.Empty, string.Empty, CancellationToken.None);

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var response = okResult.Value.Should().BeOfType<PagedDataResponse<TrustDto>>().Subject;
            response.Data.Should().BeEquivalentTo(trusts);
            response.Paging.Page.Should().Be(1);
            response.Paging.RecordCount.Should().Be(3);
        }

        [Fact]
        public async Task SearchTrusts_WhenNoTrustsFound_ReturnsEmptyPagedOk()
        {
            _trustQueries
                .Setup(q => q.Search(1, 10, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), TrustStatus.Open, It.IsAny<CancellationToken>()))
                .ReturnsAsync((new List<TrustDto>(), 0));

            var result = await _controller.SearchTrusts(string.Empty, string.Empty, string.Empty, CancellationToken.None);

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var response = okResult.Value.Should().BeOfType<PagedDataResponse<TrustDto>>().Subject;
            response.Data.Should().BeEmpty();
            response.Paging.RecordCount.Should().Be(0);
        }

        [Fact]
        public async Task GetByUkprns_WhenTrustsFound_ReturnsOk()
        {
            var ukprns = new[] { "10000001", "10000002" };
            var trusts = _fixture.CreateMany<TrustDto>(2).ToList();
            _trustQueries
                .Setup(q => q.GetByUkprns(ukprns, It.IsAny<CancellationToken>()))
                .ReturnsAsync(trusts);

            var result = await _controller.GetByUkprns(ukprns, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trusts));
        }

        [Fact]
        public async Task GetByUkprns_WhenNoTrustsFound_ReturnsNotFound()
        {
            var ukprns = new[] { "missing" };
            _trustQueries
                .Setup(q => q.GetByUkprns(ukprns, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<TrustDto>());

            var result = await _controller.GetByUkprns(ukprns, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetByUkprns_WhenNullReturned_ReturnsNotFound()
        {
            var ukprns = new[] { "missing" };
            _trustQueries
                .Setup(q => q.GetByUkprns(ukprns, It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<TrustDto>)null!);

            var result = await _controller.GetByUkprns(ukprns, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetByTrns_WhenTrustsFound_ReturnsOk()
        {
            var trns = new[] { "TR00001", "TR00002" };
            var trusts = _fixture.CreateMany<TrustDto>(2).ToList();
            _trustQueries
                .Setup(q => q.GetByTrns(trns, It.IsAny<CancellationToken>()))
                .ReturnsAsync(trusts);

            var result = await _controller.GetByTrns(trns, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trusts));
        }

        [Fact]
        public async Task GetByTrns_WhenNoTrustsFound_ReturnsNotFound()
        {
            var trns = new[] { "missing" };
            _trustQueries
                .Setup(q => q.GetByTrns(trns, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<TrustDto>());

            var result = await _controller.GetByTrns(trns, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetByTrns_WhenNullReturned_ReturnsNotFound()
        {
            var trns = new[] { "missing" };
            _trustQueries
                .Setup(q => q.GetByTrns(trns, It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<TrustDto>)null!);

            var result = await _controller.GetByTrns(trns, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrnsAsync_WhenTrustsFound_ReturnsOk()
        {
            var model = new UrnRequestModel { Urns = [22, 33] };
            var trusts = new Dictionary<int, TrustDto>
            {
                [22] = _fixture.Create<TrustDto>(),
                [33] = _fixture.Create<TrustDto>()
            };
            _trustQueries
                .Setup(q => q.GetTrustsByEstablishmentUrns(model.Urns, It.IsAny<CancellationToken>()))
                .ReturnsAsync(trusts);

            var result = await _controller.GetTrustsByEstablishmentUrnsAsync(model, CancellationToken.None);

            result.Result.Should().BeEquivalentTo(new OkObjectResult(trusts));
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrnsAsync_WhenNoTrustsFound_ReturnsNotFound()
        {
            var model = new UrnRequestModel { Urns = [111] };
            _trustQueries
                .Setup(q => q.GetTrustsByEstablishmentUrns(model.Urns, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Dictionary<int, TrustDto>());

            var result = await _controller.GetTrustsByEstablishmentUrnsAsync(model, CancellationToken.None);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrnsAsync_WhenModelIsNull_ReturnsBadRequest()
        {
            var result = await _controller.GetTrustsByEstablishmentUrnsAsync(null!, CancellationToken.None);

            var badRequest = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
            badRequest.Value.Should().Be("Establishments URN list cannot be null or empty.");
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrnsAsync_WhenUrnsEmpty_ReturnsBadRequest()
        {
            var model = new UrnRequestModel { Urns = [] };

            var result = await _controller.GetTrustsByEstablishmentUrnsAsync(model, CancellationToken.None);

            var badRequest = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
            badRequest.Value.Should().Be("Establishments URN list cannot be null or empty.");
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrnsAsync_WhenUrnsNull_ReturnsBadRequest()
        {
            var model = new UrnRequestModel { Urns = null! };

            var result = await _controller.GetTrustsByEstablishmentUrnsAsync(model, CancellationToken.None);

            var badRequest = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
            badRequest.Value.Should().Be("Establishments URN list cannot be null or empty.");
        }
    }
}
