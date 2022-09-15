using System;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.Gateways;

namespace TramsDataApi.UseCases
{
    public class GetConcernsCaseworkTeamOwners : IGetConcernsCaseworkTeamOwners
    {
        private readonly IConcernsTeamCaseworkGateway _gateway;

        public GetConcernsCaseworkTeamOwners(IConcernsTeamCaseworkGateway gateway)
        {
            _gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
        }
        public async Task<string[]> Execute(CancellationToken cancellationToken)
        {
            return await _gateway.GetTeamOwners(cancellationToken);
        }
    }
}
