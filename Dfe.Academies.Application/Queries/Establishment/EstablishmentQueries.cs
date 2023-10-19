using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Application.Queries.Establishment
{
    public class EstablishmentQueries : IEstablishmentQueries
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentQueries(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }
        public async Task<EstablishmentDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetEstablishmentByUkprn(ukprn, cancellationToken).ConfigureAwait(false);

            return establishment == null ? null : new EstablishmentDto()
            {                             
                Address = new AddressDto()
                {
                    Street = establishment.AddressLine1,
                    Town = establishment.Town,
                    Postcode = establishment.Postcode,
                    County = establishment.County,
                    Additional = establishment.AddressLine2,
                    Locality = establishment.AddressLine3
                }
            };
        }
    }
}
