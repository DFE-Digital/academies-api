using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface ISRMAGateway
    {
        Task<SRMACase> CreateSRMA(SRMACase request);
    }
}
