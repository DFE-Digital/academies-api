using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IIfdPipelineGateway
    {
        IEnumerable<IfdPipeline> GetPipelineProjectsByStatus(int page, int take, List<string> statues);
    }
}