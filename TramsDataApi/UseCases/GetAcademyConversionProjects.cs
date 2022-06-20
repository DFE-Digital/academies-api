using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjects : IGetAcademyConversionProjects
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetAcademyConversionProjects(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            IEstablishmentGateway establishmentGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _establishmentGateway = establishmentGateway;
        }

         public async Task<List<AcademyConversionProjectResponse>> Execute(int page, int count)
         {
             var conversionProjects = await _academyConversionProjectGateway.GetProjects(page, count);

            if (!conversionProjects.Any()) return new List<AcademyConversionProjectResponse>();

            var responses = conversionProjects
                .Select(AcademyConversionProjectResponseFactory.Create)
                .ToList();
            
            responses.ForEach(r =>
            {
                r.UkPrn = _establishmentGateway.GetByUrn(r.Urn)?.Ukprn;
                r.Laestab = _establishmentGateway.GetMisEstablishmentByUrn(r.Urn)?.Laestab ?? 0;
            });

            return responses;
        }
    }
}
