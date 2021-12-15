using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public interface IGetA2BSchoolLease
    {
        A2BSchoolLeaseResponse Execute(string leaseId);
    }
}