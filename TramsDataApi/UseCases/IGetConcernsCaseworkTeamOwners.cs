using System;
using System.Threading;
using System.Threading.Tasks;

namespace TramsDataApi.UseCases
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public interface IGetConcernsCaseworkTeamOwners
    {
        public Task<string[]> Execute(CancellationToken cancellationToken);
    }
}
