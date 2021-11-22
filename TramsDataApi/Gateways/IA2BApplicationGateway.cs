using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BApplicationGateway
    {
        A2BApplication GetByApplicationId(string applicationId);
    }
}