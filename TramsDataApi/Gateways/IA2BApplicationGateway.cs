using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Gateways
{
    public interface IA2BApplicationGateway
    {
        A2BApplication GetByApplicationId(string applicationId);
        A2BApplication CreateA2BApplication(A2BApplication request);
    }
}