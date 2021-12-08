using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public static class A2BApplicationStatusFactory
    {
        public static A2BApplicationStatus Create(A2BApplicationStatusCreateRequest request)
        {
            return request == null
                ? null
                : new A2BApplicationStatus
                {
                    Name = request.Name
                };
        }
    }
}