using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetEstablishmentByUkprnTests
    {
        private readonly GetEstablishment _useCase;
        private readonly Mock<IEstablishmentGateway> _establishmentGateway;

        private const string UKPRN = "mockukprn";
        private const int URN = 123456789;

        public GetEstablishmentByUkprnTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));

            _establishmentGateway = new Mock<IEstablishmentGateway>();
            _useCase = new GetEstablishment(_establishmentGateway.Object);
        }
        
        [Fact]
        public void GetEstablishmentByUkprn_ReturnsNull_WhenNoEstablishmentsAreFound()
        {
            _establishmentGateway.Setup(gateway => gateway.GetByUkprn(UKPRN)).Returns(() => null);

            _useCase.Execute(UKPRN).Should().BeNull();
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishment_WhenAnEstablishmentIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.Ukprn = UKPRN).Build();

            _establishmentGateway.Setup(gateway => gateway.GetByUkprn(UKPRN)).Returns(establishment);

            var expected = EstablishmentResponseFactory.Create(establishment, null, null, null, null);

            var result = _useCase.Execute(UKPRN);
            
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentWithMisEstablishment_WhenMisEstablishmentDataIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.Ukprn = UKPRN).Build();
            var misEstablishment = Builder<MisEstablishments>.CreateNew().With(m => m.Urn = establishment.Urn).Build();

            _establishmentGateway.Setup(gateway => gateway.GetByUkprn(UKPRN)).Returns(establishment);
            _establishmentGateway.Setup(gateway => gateway.GetMisEstablishmentByUrn(establishment.Urn)).Returns(misEstablishment);

            var expected = EstablishmentResponseFactory.Create(establishment, misEstablishment, null, null, null);
            
            var result = _useCase.Execute(UKPRN);
            
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentWithSmartData_WhenSmartDataIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.Ukprn = UKPRN).Build();
            var smartData = Builder<SmartData>.CreateNew().With(s => s.Urn = establishment.Urn.ToString()).Build();

            _establishmentGateway.Setup(gateway => gateway.GetByUkprn(UKPRN)).Returns(establishment);
            _establishmentGateway.Setup(gateway => gateway.GetSmartDataByUrn(establishment.Urn)).Returns(smartData);

            var expected = EstablishmentResponseFactory.Create(establishment, null, smartData, null, null);

            var result = _useCase.Execute(UKPRN);
            
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentWithFurtherEducationEstablishment_WhenFurtherEducationEstablishmentIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.Ukprn = UKPRN).Build();
            var furtherEducationEstablishment = Builder<FurtherEducationEstablishments>.CreateNew().With(s => s.ProviderUrn = establishment.Urn).Build();

            _establishmentGateway.Setup(gateway => gateway.GetByUkprn(UKPRN)).Returns(establishment);
            _establishmentGateway.Setup(gateway => gateway.GetFurtherEducationEstablishmentByUrn(establishment.Urn)).Returns(furtherEducationEstablishment);

            var expected = EstablishmentResponseFactory.Create(establishment, null, null, furtherEducationEstablishment, null);

            var result = _useCase.Execute(UKPRN);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEstablishmentByUkprn_ReturnsEstablishmentWithViewAcademyConversionInfo_WhenAcademyConversionInfoIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.Ukprn = UKPRN).Build();
            var viewAcademyConversion = Utils.Generators.GenerateViewAcademyConversionsWithUkprn(establishment.Ukprn);

            _establishmentGateway.Setup(gateway => gateway.GetByUkprn(UKPRN)).Returns(establishment);
            _establishmentGateway.Setup(gateway => gateway.GetViewAcademyConversionInfoByUrn(establishment.Urn)).Returns(viewAcademyConversion);

            var expected = EstablishmentResponseFactory.Create(establishment, null, null, null, viewAcademyConversion);

            var result = _useCase.Execute(UKPRN);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEstablishmentByUrn_ReturnsNull_WhenNoEstablishmentsAreFound()
        {
            _establishmentGateway.Setup(gateway => gateway.GetByUrn(It.IsAny<int>())).Returns(() => null);

            _useCase.Execute(new GetEstablishmentByUrnRequest { URN = URN }).Should().BeNull();
        }

        [Fact]
        public void GetEstablishmentByUrn_ReturnsEstablishment_WhenAnEstablishmentIsFound()
        {
            var establishment = Builder<Establishment>.CreateNew().With(e => e.Ukprn = UKPRN).Build();

            _establishmentGateway.Setup(gateway => gateway.GetByUrn(URN)).Returns(establishment);

            var expected = EstablishmentResponseFactory.Create(establishment, null, null, null, null);

            var result = _useCase.Execute(new GetEstablishmentByUrnRequest { URN = URN });

            result.Should().BeEquivalentTo(expected);
        }
    }
}