using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Utils.Extensions;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.SignificantChange; 

namespace Dfe.Academies.Application.SignificantChange;

public class SignificantChangeQueries(ISignificantChangeRepositiory significantChangeRepositiory) : ISignificantChangeQueries
{
    public async Task<(IEnumerable<SignificantChangeDto>, int)> SearchSignificantChanges(string deliveryOfficer, bool orderByChangeEditDate = false, int page = 1, int count = 10, CancellationToken cancellationToken = default)
    {
        var (significantChanges, recordCount) = await significantChangeRepositiory.SearchSignificantChanges(deliveryOfficer, orderByChangeEditDate, page, count, cancellationToken);
        return (significantChanges.Select(MapToSignificantChangeDto).ToList(), recordCount);
    }
    private static SignificantChangeDto MapToSignificantChangeDto(Domain.SignificantChange.SignificantChange significantChange)
    {
        return new SignificantChangeDto
        {
            SigChangeId = significantChange.SignificantChangeId,
            URN = significantChange.URN,
            TypeofGiasChangeId = significantChange.TypeofGiasChangeId,
            TypeofSigChange = significantChange.TypeofSigChange,
            TypeOfSigChangeMapped = significantChange.TypeofSigChangedMapped,
            CreatedUserName = significantChange.CreatedUserName,
            EditedUserName = significantChange.EditedUserName,
            ApplicationType = significantChange.ApplicationType,
            DecisionDate = significantChange.DecisionDate.ToISODateOnly(),
            DeliveryLead = significantChange.DeliveryLead,
            ChangeCreationDate = significantChange.ChangeCreationDate.ToISO8601DateTime(),
            ChangeEditDate = significantChange.ChangeEditDate.ToISO8601DateTime(),
            AllActionsCompleted = significantChange.AllActionsCompleted,
            Withdrawn = significantChange.Withdrawn,
            LocalAuthority = significantChange.LocalAuthority,
            Region = significantChange.Region,
            TrustName = significantChange.TrustName,
            AcademyName = significantChange.AcademyName,
            MetaIngestionDateTime = significantChange.MetaIngestionDateTime.ToISO8601DateTime(),
            MetaSourceSystem = significantChange.MetaSourceSystem
        };
         
    }
}
