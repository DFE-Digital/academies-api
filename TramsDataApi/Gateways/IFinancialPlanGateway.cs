using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IFinancialPlanGateway
    {
        Task<FinancialPlanCase> CreateFinancialPlan(FinancialPlanCase request);
        Task<FinancialPlanCase> GetFinancialPlanById(long financialPlanId);
        Task<ICollection<FinancialPlanCase>> GetFinancialPlansByCaseUrn(int caseUrn);
        Task<FinancialPlanCase> PatchFinancialPlan(FinancialPlanCase updatedFinancialPlan);
        Task<List<FinancialPlanStatus>> GetAllStatuses();

    }
}
