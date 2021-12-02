using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BApplicationStatusGateway
    {
        A2BApplicationStatus GetByStatusId(int applicationStatusId);
        A2BApplicationStatus CreateA2BApplicationStatus(A2BApplicationStatus status);
    }
}