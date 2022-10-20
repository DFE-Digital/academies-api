using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public class SearchAcademyConversionProjects : ISearchAcademyConversionProjects
    {
        private readonly IAcademyConversionProjectGateway _academyConversionProjectGateway;
        private readonly IEstablishmentGateway _establishmentGateway;

        public SearchAcademyConversionProjects(
            IAcademyConversionProjectGateway academyConversionProjectGateway,
            IEstablishmentGateway establishmentGateway)
        {
            _academyConversionProjectGateway = academyConversionProjectGateway;
            _establishmentGateway = establishmentGateway;
        }

        public async Task<PagedResult<AcademyConversionProjectResponse>> Execute(int page, int count, IEnumerable<string> statuses, int? urn, string title, IEnumerable<string> deliveryOfficers)
        {
            var academyConversionProjects = await _academyConversionProjectGateway
                .SearchProjects(page, count, statuses, urn, title, deliveryOfficers);

            if (academyConversionProjects == null) return new PagedResult<AcademyConversionProjectResponse>();

            var responses = academyConversionProjects.Results
                .Select(p => AcademyConversionProjectResponseFactory.Create(
                    p, 
                    _establishmentGateway.GetByUrn(p.Urn.Value)?.Ukprn,
                    _establishmentGateway.GetMisEstablishmentByUrn(p.Urn.Value)?.Laestab ?? 0));            

            return new PagedResult<AcademyConversionProjectResponse>(responses, academyConversionProjects.TotalCount);
        }
    }
}
