using System.Threading;
using System.Threading.Tasks;

namespace TramsDataApi.UseCases
{
    public interface IGetConcernsCaseworkTeamOwners
    {
        public Task<string[]> Execute(CancellationToken cancellationToken);
    }
}
