namespace Dfe.Academies.Domain.SignificantChange;

public class SignificantChange
{
    public long? SignificantChangeId { get; set; }
    public int? URN { get; set; } 
    public int? TypeofGiasChangeId { get; set; }
    public string? TypeofSigChange { get; set; }
    public string? TypeofSigChangedMapped { get; set; }
    public string? CreatedUserName { get; set; }
    public string? EditedUserName { get; set; } 
    public string? ApplicationType { get; set; }
    public DateOnly? DecisionDate { get; set; }
    public string? DeliveryLead { get; set; }
    public DateTime? ChangeCreationDate { get; set; }
    public DateTime? ChangeEditDate { get; set; }
    public bool? AllActionsCompleted { get; set; }
    public bool? Withdrawn { get; set; }
    public string? LocalAuthority { get; set; }
    public string? Region { get; set; }
    public string? TrustName { get; set; }
    public string? AcademyName { get; set; }
    public DateTime? MetaIngestionDateTime { get; set; }
    public string? MetaSourceSystem { get; set; }

}
