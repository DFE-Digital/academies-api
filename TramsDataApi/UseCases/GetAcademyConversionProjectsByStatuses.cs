using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class GetAcademyConversionProjectsByStatuses : IGetAcademyConversionProjectsByStatuses
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly IEstablishmentGateway _establishmentGateway;

        public GetAcademyConversionProjectsByStatuses(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            IEstablishmentGateway establishmentGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _establishmentGateway = establishmentGateway;
        }

        public async Task<List<AcademyConversionProjectResponse>> Execute(int page, int count, IEnumerable<string> statuses)
        {
            var academyConversionProjects = await _academyConversionProjectGateway
                .GetByStatuses(page, count, statuses);

            if (academyConversionProjects == null) return new List<AcademyConversionProjectResponse>();

            var responses = academyConversionProjects
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
