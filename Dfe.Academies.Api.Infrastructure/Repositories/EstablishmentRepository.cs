using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public class EstablishmentRepository(MstrContext context, MisMstrContext misMstrContext) : IEstablishmentRepository
    {
        public MisEstablishment? GetMisEstablishmentByURN(int? urn)
        {
            return misMstrContext.Establishments.FirstOrDefault(m => m.Urn == urn);
        }

        public ReportCardFullInspection? GetOfstedReportCardsByURN(int? urn)
        {
            return misMstrContext.ReportCardsFullInspection.FirstOrDefault(m => m.Urn == urn);
        }


        public async Task<Establishment?> GetEstablishmentByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var queryResult = await BaseQuery().FirstOrDefaultAsync(r => r.Establishment.UKPRN == ukprn, cancellationToken: cancellationToken);

            if (queryResult == null)
            {
                return null;
            }

            var result = ToEstablishment(queryResult);

            return result;

        }
        public EducationEstablishmentLink? GetEducationEstablishmentLinksByURN(long? urn)
        {
            var result = context.EducationEstablishmentLinks
                .FirstOrDefault(e => e.FK_EducationEstablishmentURN == urn && e.LinkType == "Predecessor");
            return result;
        }

        public async Task<Establishment?> GetEstablishmentByUrn(string urn, CancellationToken cancellationToken)
        {
            var queryResult = await BaseQuery().FirstOrDefaultAsync(r => r.Establishment.URN.ToString() == urn, cancellationToken: cancellationToken);

            if (queryResult == null)
            {
                return null;
            }

            var result = ToEstablishment(queryResult);

            return result;
        }

        public async Task<List<Establishment>> Search(string name, string ukPrn, string urn, bool? excludeClosed, bool? matchAny, CancellationToken cancellationToken)
        {
            IQueryable<EstablishmentQueryResult> query = BaseQuery();

            if (matchAny == true)
            {
                query = ApplyMatchAnyFilter(query, name, ukPrn, urn);
            }
            else
            {
                query = ApplyAllFilters(query, name, ukPrn, urn);
            }

            if (excludeClosed == true)
            {
                query = query.Where(r => !r.Establishment.CloseDate.HasValue);
            }

            var queryResult = await query.Take(100).ToListAsync(cancellationToken);

            return queryResult.Select(ToEstablishment).ToList();
        }

        public async Task<List<Establishment>> SearchByNameStartsWith(string name, bool? excludeClosed, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<Establishment>();
            }

            IQueryable<EstablishmentQueryResult> query = BaseQuery();


            query = query.Where(r => r.Establishment.EstablishmentName != null && r.Establishment.EstablishmentName.StartsWith(name));


            if (excludeClosed == true)
            {
                query = query.Where(r => !r.Establishment.CloseDate.HasValue);
            }

            var queryResult = await query.Take(100).ToListAsync(cancellationToken);

            return queryResult.Select(ToEstablishment).ToList();
        }


        public async Task<List<Establishment>> SearchByFilters(
            string name,
            long[] groupTypeIds,
            CancellationToken cancellationToken)
        {
            var hasName = !string.IsNullOrWhiteSpace(name);
            var hasGroupTypes = groupTypeIds != null && groupTypeIds.Length > 0;

            if (!hasName && !hasGroupTypes)
            {
                return [];
            }

            var groupTypeCodes = hasGroupTypes
                ? groupTypeIds.Select(x => x.ToString()).ToArray()
                : [];

            var matchingGroupTypeSk = hasGroupTypes
                ? await context.EstablishmentGroupTypes
                    .AsNoTracking()
                    .Where(g => g.Code != null && groupTypeCodes.Contains(g.Code))
                    .Select(g => g.SK)
                    .ToArrayAsync(cancellationToken)
                    .ConfigureAwait(false)
                : [];

            if (hasGroupTypes && matchingGroupTypeSk.Length == 0 && !hasName)
            {
                return [];
            }

            IQueryable<Establishment> filteredEstablishments = context.Establishments.AsNoTracking();

            if (hasName)
            {
                filteredEstablishments = filteredEstablishments.Where(e =>
                    e.EstablishmentName != null &&
                    e.EstablishmentName.StartsWith(name));
            }

            if (hasGroupTypes)
            {
                filteredEstablishments = filteredEstablishments.Where(e =>
                    e.EstablishmentGroupTypeId.HasValue &&
                    matchingGroupTypeSk.Contains(e.EstablishmentGroupTypeId.Value));
            }

            var queryResult = await BaseQuery(filteredEstablishments)
                .Take(100)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return queryResult.Select(ToEstablishment).ToList();
        }

        private IQueryable<EstablishmentQueryResult> BaseQuery()
        {
            return BaseQuery(context.Establishments);
        }

        private IQueryable<EstablishmentQueryResult> BaseQuery(IQueryable<Establishment> establishments)
        {
            var result =
                from establishment in establishments
                from ifdPipeline in context.IfdPipelines.Where(i => i.GeneralDetailsUrn == establishment.PK_GIAS_URN).DefaultIfEmpty()
                from establishmentType in context.EstablishmentTypes.Where(e => e.SK == establishment.EstablishmentTypeId).DefaultIfEmpty()
                from localAuthority in context.LocalAuthorities.Where(l => l.SK == establishment.LocalAuthorityId).DefaultIfEmpty()
                from groupType in context.EstablishmentGroupTypes.Where(g => g.SK == establishment.EstablishmentGroupTypeId).DefaultIfEmpty()
                select new EstablishmentQueryResult
                {
                    Establishment = establishment,
                    IfdPipeline = ifdPipeline,
                    LocalAuthority = localAuthority,
                    EstablishmentType = establishmentType,
                    EstablishmentGroupType = groupType
                };

            return result;
        }

        private static Establishment ToEstablishment(EstablishmentQueryResult queryResult)
        {
            var result = queryResult.Establishment;
            result.IfdPipeline = queryResult.IfdPipeline;
            result.LocalAuthority = queryResult.LocalAuthority;
            result.EstablishmentType = queryResult.EstablishmentType;
            result.EstablishmentGroupType = queryResult.EstablishmentGroupType;

            return result;
        }

        private static IQueryable<EstablishmentQueryResult> ApplyMatchAnyFilter(IQueryable<EstablishmentQueryResult> query, string? name, string? ukPrn, string? urn)
        {
            return query.Where(r =>
                (!string.IsNullOrEmpty(name) && r.Establishment.EstablishmentName != null && r.Establishment.EstablishmentName.Contains(name)) ||
                (!string.IsNullOrEmpty(ukPrn) && r.Establishment.UKPRN != null && r.Establishment.UKPRN.Contains(ukPrn)) ||
                (IsValidUrn(urn) && r.Establishment.URN.HasValue && r.Establishment.URN.Value.ToString().Contains(urn!)))
            ;
        }

        private static IQueryable<EstablishmentQueryResult> ApplyAllFilters(IQueryable<EstablishmentQueryResult> query, string? name, string? ukPrn, string? urn)
        {
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(r =>
                    r.Establishment.EstablishmentName != null &&
                    r.Establishment.EstablishmentName.Contains(name));
            }

            if (!string.IsNullOrEmpty(ukPrn))
            {
                query = query.Where(r =>
                    r.Establishment.UKPRN != null &&
                    r.Establishment.UKPRN == ukPrn);
            }

            if (int.TryParse(urn, out var urnAsNumber))
            {
                query = query.Where(r => r.Establishment.URN == urnAsNumber);
            }

            return query;
        }

        private static bool IsValidUrn(string? urn) =>
            !string.IsNullOrEmpty(urn) && urn.All(char.IsDigit);

        public async Task<Diocese?> GetDioceseByCode(string code, CancellationToken cancellationToken)
        {
            var distinctDioceses = context.Establishments
                .AsNoTracking()
                .Where(e => !string.IsNullOrWhiteSpace(e.DioceseCode) && !string.IsNullOrWhiteSpace(e.Diocese))
                .Select(e => new
                {
                    Code = e.DioceseCode!,
                    Name = e.Diocese!
                })
                .Distinct();

            return await distinctDioceses
                .Where(d => d.Code == code)
                .Select(d => new Diocese
                {
                    Code = d.Code,
                    Name = d.Name
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<(IEnumerable<Diocese> dioceses, int recordCount)> SearchDioceses(string name, string code, CancellationToken cancellationToken)
        {
            var query = context.Establishments
                .AsNoTracking()
                .Where(e => !string.IsNullOrWhiteSpace(e.DioceseCode) && !string.IsNullOrWhiteSpace(e.Diocese));

            var nameFilter = string.IsNullOrWhiteSpace(name) ? null : name.Trim();
            var codeFilter = string.IsNullOrWhiteSpace(code) ? null : code.Trim();

            if (nameFilter != null || codeFilter != null)
            {
                query = query.Where(e =>
                    (nameFilter != null && EF.Functions.Like(e.Diocese!, $"%{nameFilter}%")) ||
                    (codeFilter != null && EF.Functions.Like(e.DioceseCode!, $"%{codeFilter}%")));
            }

            var distinctDiocesesQuery = query
                .Select(e => new Diocese
                {
                    Name = e.Diocese!,
                    Code = e.DioceseCode!
                })
                .Distinct();

            var recordCount = await distinctDiocesesQuery.CountAsync(cancellationToken);

            var dioceses = await distinctDiocesesQuery
                .OrderBy(d => d.Name)
                .ThenBy(d => d.Code)
                .Take(100)
                .ToListAsync(cancellationToken);

            return (dioceses, recordCount);
        }


        public async Task<IEnumerable<int>> GetURNsByRegion(string[] regions, CancellationToken cancellationToken)
        {
            return await context.Establishments
                .AsNoTracking()
                .Where(p => regions.Contains(p.GORregion) && p.URN.HasValue)
                .Select(e => e.URN.Value)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Establishment>> GetByUrns(int[] urns, CancellationToken cancellationToken)
        {
            var urnsList = urns.ToList();
            var queryResult = await BaseQuery()
                .Where(r => urnsList.Contains((int)r.Establishment.URN))
                .ToListAsync(cancellationToken);

            var result = queryResult.Select(ToEstablishment).ToList();

            return result;
        }

        public async Task<List<Establishment>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var ukprnsList = ukprns.ToList();
            var queryResult = await BaseQuery()
                .Where(r => ukprnsList.Contains(r.Establishment.UKPRN))
                .ToListAsync(cancellationToken);

            var result = queryResult.Select(ToEstablishment).ToList();

            return result;
        }

        public async Task<List<Establishment>> GetByTrust(long? trustId, CancellationToken cancellationToken)
        {
            var establishmentIds =
                await context.EducationEstablishmentTrusts
                        .AsNoTracking()
                        .Where(eet => eet.TrustId == Convert.ToInt32(trustId))
                        .Select(eet => (long)eet.EducationEstablishmentId)
                        .ToListAsync(cancellationToken);

            var establishments =
                    await BaseQuery()
                        .Where(r => establishmentIds.Contains(r.Establishment.SK.Value))
                        .ToListAsync(cancellationToken);

            var result = establishments.Select(ToEstablishment).ToList();

            return result;
        }

        internal record EstablishmentQueryResult
        {
            public Establishment Establishment { get; set; }
            public IfdPipeline IfdPipeline { get; set; }
            public LocalAuthority LocalAuthority { get; set; }
            public EstablishmentType EstablishmentType { get; set; }
            public EstablishmentGroupType EstablishmentGroupType { get; set; }
        }

    }
}
