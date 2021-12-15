using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IA2BSchoolLeaseGateway
    {
        A2BSchoolLease CreateA2BSchoolLease(A2BSchoolLease schoolLease);
        A2BSchoolLease GetByLeaseId(string leaseId);
    }
}