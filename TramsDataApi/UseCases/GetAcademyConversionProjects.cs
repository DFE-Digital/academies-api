using System.Collections.Generic;
using System.Linq;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjects : IUseCase<GetAllAcademyConversionProjectsRequest, IEnumerable<AcademyConversionProjectResponse>>
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly ITrustGateway _trustGateway;
        private readonly IEstablishmentGateway _establishmentGateway;
        private readonly IIfdPipelineGateway _ifdPipelineGateway;

        public GetAcademyConversionProjects(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            ITrustGateway trustGateway, 
            IEstablishmentGateway establishmentGateway,
            IIfdPipelineGateway ifdPipelineGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _trustGateway = trustGateway;
            _establishmentGateway = establishmentGateway;
            _ifdPipelineGateway = ifdPipelineGateway;
        }

         public IEnumerable<AcademyConversionProjectResponse> Execute(GetAllAcademyConversionProjectsRequest request)
        {
            var conversionProjects = _academyConversionProjectGateway
                .GetProjects(request.Page, request.Count);
                      
            var responses = conversionProjects.Select(AcademyConversionProjectResponseFactory.Create).ToList();
            responses.ForEach(r =>
            {
                r.UkPrn = _establishmentGateway.GetByUrn(r.Urn)?.Ukprn;
                r.Laestab = _establishmentGateway.GetMisEstablishmentByUrn(r.Urn)?.Laestab ?? 0;
            });

            return responses;
        }
    }
}
