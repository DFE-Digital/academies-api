using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IConcernsTeamCaseworkGateway
    {
        Task<IList<ConcernsTeamCaseworkSelectedUser>> GetByOwnerId(string ownerId, CancellationToken cancellationToken);
    }
}
