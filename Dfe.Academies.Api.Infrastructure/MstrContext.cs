
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Academies.Academisation.Data;

public class MstrContext : DbContext
{
    const string DEFAULT_SCHEMA = "mstr";

    public MstrContext()
    {

    }

    public MstrContext(DbContextOptions<MstrContext> options) : base(options)
    {

    }

    public DbSet<Trust> Trusts { get; set; } = null!;
    public DbSet<TrustType> TrustTypes { get; set; } = null!;
    public DbSet<Establishment> Establishments { get; set; } = null!;
    public DbSet<EstablishmentType> EstablishmentTypes { get; set; } = null!;
    public DbSet<EducationEstablishmentTrust> EducationEstablishmentTrusts { get; set; } = null!;
    public DbSet<LocalAuthority> LocalAuthorities { get; set; } = null!;

    public DbSet<IfdPipeline> IfdPipelines { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=sip;Integrated Security=true;TrustServerCertificate=True");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trust>(ConfigureTrust);
        modelBuilder.Entity<TrustType>(ConfigureTrustType);

        modelBuilder.Entity<Establishment>(ConfigureEstablishment);
        modelBuilder.Entity<EstablishmentType>(ConfigureEstablishmentType);
        modelBuilder.Entity<EducationEstablishmentTrust>(ConfigureEducationEstablishmentTrust);
        modelBuilder.Entity<LocalAuthority>(ConfigureLocalAuthority);
        modelBuilder.Entity<IfdPipeline>(ConfigureIfdPipeline);

        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureEstablishment(EntityTypeBuilder<Establishment> establishmentConfiguration)
    {
        establishmentConfiguration.HasKey(e => e.SK);

        establishmentConfiguration.ToTable("EducationEstablishment", DEFAULT_SCHEMA);

        establishmentConfiguration.Property(e => e.Diocese).HasColumnName("Diocese");
        establishmentConfiguration.Property(e => e.OverallEffectiveness).HasColumnName("Overall effectiveness");
        establishmentConfiguration.Property(e => e.IsSafeguardingEffective).HasColumnName("Is safeguarding effective?");
        establishmentConfiguration.Property(e => e.InspectionType).HasColumnName("Inspection type");
        establishmentConfiguration.Property(e => e.AddressLine1).HasColumnName("Address Line1");
        establishmentConfiguration.Property(e => e.AddressLine2).HasColumnName("Address Line2");
        establishmentConfiguration.Property(e => e.AddressLine3).HasColumnName("Address Line3");
        establishmentConfiguration.Property(e => e.AdministrativeDistrict).HasColumnName("Administrative District");
        establishmentConfiguration.Property(e => e.BehaviourAndAttitudes).HasColumnName("Behaviour and attitudes");
        establishmentConfiguration.Property(e => e.CategoryOfConcern).HasColumnName("Category of concern");
        establishmentConfiguration.Property(e => e.CloseDate).HasColumnName("CloseDate");
        establishmentConfiguration.Property(e => e.County).HasColumnName("County");
        establishmentConfiguration.Property(e => e.DateOfLatestShortInspection).HasColumnName("Date of latest short inspection");
        establishmentConfiguration.Property(e => e.DidTheLatestShortInspectionConvertToAFullInspection).HasColumnName("Did the latest short inspection convert to a full inspection?");
        establishmentConfiguration.Property(e => e.EarlyYearsProvisionWhereApplicable).HasColumnName("Early years provision (where applicable)");
        establishmentConfiguration.Property(e => e.EffectivenessOfLeadershipAndManagement).HasColumnName("Effectiveness of leadership and management");
        establishmentConfiguration.Property(e => e.Email).HasColumnName("Email");
        establishmentConfiguration.Property(e => e.EstablishmentName).HasColumnName("EstablishmentName");
        establishmentConfiguration.Property(e => e.EstablishmentNumber).HasColumnName("EstablishmentNumber");
        establishmentConfiguration.Property(e => e.EstablishmentGroupTypeId).HasColumnName("FK_EstablishmentGroupType");
        establishmentConfiguration.Property(e => e.EstablishmentStatusId).HasColumnName("FK_EstablishmentStatus");
        establishmentConfiguration.Property(e => e.EstablishmentTypeId).HasColumnName("FK_EstablishmentType");
        establishmentConfiguration.Property(e => e.LocalAuthorityId).HasColumnName("FK_LocalAuthority");
        establishmentConfiguration.Property(e => e.RegionId).HasColumnName("FK_Region");
        establishmentConfiguration.Property(e => e.GORregion).HasColumnName("GORregion");
        establishmentConfiguration.Property(e => e.HeadFirstName).HasColumnName("HeadFirstName");
        establishmentConfiguration.Property(e => e.HeadLastName).HasColumnName("HeadLastName");
        establishmentConfiguration.Property(e => e.HeadPreferredJobTitle).HasColumnName("HeadPreferredJobTitle");
        establishmentConfiguration.Property(e => e.HeadTitle).HasColumnName("HeadTitle");
        establishmentConfiguration.Property(e => e.InspectionEndDate).HasColumnName("Inspection end date");
        establishmentConfiguration.Property(e => e.InspectionStartDate).HasColumnName("Inspection start date");
        establishmentConfiguration.Property(e => e.InspectionType).HasColumnName("Inspection type");
        establishmentConfiguration.Property(e => e.IsSafeguardingEffective).HasColumnName("Is safeguarding effective?");
        establishmentConfiguration.Property(e => e.Latitude).HasColumnName("Latitude");
        establishmentConfiguration.Property(e => e.Longitude).HasColumnName("Longitude");
        establishmentConfiguration.Property(e => e.MainPhone).HasColumnName("Main Phone");
        establishmentConfiguration.Property(e => e.Modified).HasColumnName("Modified");
        establishmentConfiguration.Property(e => e.ModifiedBy).HasColumnName("Modified By");
        establishmentConfiguration.Property(e => e.NumberOfOtherSection8InspectionsSinceLastFullInspection).HasColumnName("Number of other section 8 inspections since last full inspection");
        establishmentConfiguration.Property(e => e.NumberOfShortInspectionsSinceLastFullInspection).HasColumnName("Number of short inspections since last full inspection");
        establishmentConfiguration.Property(e => e.NumberOfPupils).HasColumnName("NumberOfPupils");
        establishmentConfiguration.Property(e => e.OfstedLastInspection).HasColumnName("OfstedLastInspection");
        establishmentConfiguration.Property(e => e.OfstedRating).HasColumnName("OfstedRating");
        establishmentConfiguration.Property(e => e.OpenDate).HasColumnName("OpenDate");
        establishmentConfiguration.Property(e => e.OverallEffectiveness).HasColumnName("Overall effectiveness");
        establishmentConfiguration.Property(e => e.ParliamentaryConstituency).HasColumnName("Parliamentary constituency");
        establishmentConfiguration.Property(e => e.PercentageFSM).HasColumnName("PercentageFSM");
        establishmentConfiguration.Property(e => e.PersonalDevelopment).HasColumnName("Personal development");
        establishmentConfiguration.Property(e => e.PhaseOfEducation).HasColumnName("PhaseOfEducation");
        establishmentConfiguration.Property(e => e.PK_CDM_ID).HasColumnName("PK_CDM_ID");
        establishmentConfiguration.Property(e => e.PK_GIAS_URN).HasColumnName("PK_GIAS_URN").HasConversion<int?>();
        establishmentConfiguration.Property(e => e.Postcode).HasColumnName("Postcode");
        establishmentConfiguration.Property(e => e.PreviousCategoryOfConcern).HasColumnName("Previous category of concern");
        establishmentConfiguration.Property(e => e.PreviousEarlyYearsProvisionWhereApplicable).HasColumnName("Previous early years provision (where applicable)");
        establishmentConfiguration.Property(e => e.PreviousFullInspectionOverallEffectiveness).HasColumnName("Previous full inspection overall effectiveness");
        establishmentConfiguration.Property(e => e.PreviousInspectionEndDate).HasColumnName("Previous inspection end date");
        establishmentConfiguration.Property(e => e.PreviousInspectionStartDate).HasColumnName("Previous inspection start date");
        establishmentConfiguration.Property(e => e.PreviousIsSafeguardingEffective).HasColumnName("Previous is safeguarding effective?");
        establishmentConfiguration.Property(e => e.PreviousPublicationDate).HasColumnName("Previous publication date");
        establishmentConfiguration.Property(e => e.ProjectLead).HasColumnName("Project Lead");
        establishmentConfiguration.Property(e => e.PublicationDate).HasColumnName("Publication date");
        establishmentConfiguration.Property(e => e.QualityOfEducation).HasColumnName("Quality of education");
        establishmentConfiguration.Property(e => e.ReasonEstablishmentClosed).HasColumnName("ReasonEstablishmentClosed");
        establishmentConfiguration.Property(e => e.ReligiousCharacter).HasColumnName("ReligiousCharacter");
        establishmentConfiguration.Property(e => e.ReligiousEthos).HasColumnName("ReligiousEthos");
        establishmentConfiguration.Property(e => e.RouteOfProject).HasColumnName("Route of Project");
        establishmentConfiguration.Property(e => e.SchoolCapacity).HasColumnName("SchoolCapacity");
        establishmentConfiguration.Property(e => e.SFSOTerritory).HasColumnName("SFSO Territory");
        establishmentConfiguration.Property(e => e.ShortInspectionOverallOutcome).HasColumnName("Short inspection overall outcome");
        establishmentConfiguration.Property(e => e.ShortInspectionPublicationDate).HasColumnName("Short inspection publication date");
        establishmentConfiguration.Property(e => e.SixthFormProvisionWhereApplicable).HasColumnName("Sixth form provision (where applicable)");
        establishmentConfiguration.Property(e => e.StatutoryHighAge).HasColumnName("StatutoryHighAge");
        establishmentConfiguration.Property(e => e.StatutoryLowAge).HasColumnName("StatutoryLowAge");
        establishmentConfiguration.Property(e => e.TheIncomeDeprivationAffectingChildrenIndexIDACIQuintile).HasColumnName("The income deprivation affecting children index (IDACI) quintile");
        establishmentConfiguration.Property(e => e.Town).HasColumnName("Town");
        establishmentConfiguration.Property(e => e.UKPRN).HasColumnName("UKPRN");
        establishmentConfiguration.Property(e => e.URN).HasColumnName("URN");
        establishmentConfiguration.Property(e => e.URNAtCurrentFullInspection).HasColumnName("URN at Current full inspection");
        establishmentConfiguration.Property(e => e.URNAtPreviousFullInspection).HasColumnName("URN at Previous full inspection");
        establishmentConfiguration.Property(e => e.URNAtSection8Inspection).HasColumnName("URN at Section 8 inspection");
        establishmentConfiguration.Property(e => e.Website).HasColumnName("Website");

        establishmentConfiguration.Property(e => e.DioceseCode).HasColumnName("Diocese(code)");
        establishmentConfiguration.Property(e => e.GORregionCode).HasColumnName("GORregion(code)");
        establishmentConfiguration.Property(e => e.ReligiousCharacterCode).HasColumnName("ReligiousCharacter(code)");
        establishmentConfiguration.Property(e => e.PhaseOfEducationCode).HasColumnName("PhaseOfEducation(code)");
        establishmentConfiguration.Property(e => e.ParliamentaryConstituencyCode).HasColumnName("ParliamentaryConstituency(code)");

        establishmentConfiguration
            .HasOne(x => x.EstablishmentType)
            .WithMany()
            .HasForeignKey(x => x.EstablishmentTypeId)
            .IsRequired(false);

        establishmentConfiguration
            .HasOne(x => x.LocalAuthority)
            .WithMany()
            .HasForeignKey(x => x.LocalAuthorityId)
            .IsRequired(false);

        // No relationship exists yet
        // Make sure entity framework doesn't generate one
        establishmentConfiguration.Ignore(x => x.IfdPipeline);
    }

    /// <summary>
    /// New mapping for refactoring
    /// </summary>
    /// <param name="trustConfiguration"></param>

    void ConfigureTrust(EntityTypeBuilder<Trust> trustConfiguration)
    {
        trustConfiguration.HasKey(e => e.SK);
        
        trustConfiguration.ToTable("Trust", DEFAULT_SCHEMA);

        trustConfiguration.Property(e => e.TrustTypeId).HasColumnName("FK_TrustType");
        trustConfiguration.Property(e => e.RegionId).HasColumnName("FK_Region");
        trustConfiguration.Property(e => e.TrustBandingId).HasColumnName("FK_TrustBanding");
        trustConfiguration.Property(e => e.TrustStatusId).HasColumnName("FK_TrustStatus");
        trustConfiguration.Property(e => e.GroupUID).HasColumnName("Group UID").IsRequired();
        trustConfiguration.Property(e => e.GroupID).HasColumnName("Group ID");
        trustConfiguration.Property(e => e.RID).HasColumnName("RID");
        trustConfiguration.Property(e => e.Name).HasColumnName("Name").IsRequired();
        trustConfiguration.Property(e => e.CompaniesHouseNumber).HasColumnName("Companies House Number");
        trustConfiguration.Property(e => e.ClosedDate).HasColumnName("Closed Date");
        trustConfiguration.Property(e => e.TrustStatus).HasColumnName("Trust Status");
        trustConfiguration.Property(e => e.JoinedDate).HasColumnName("Joined Date");
        trustConfiguration.Property(e => e.MainPhone).HasColumnName("Main Phone");
        trustConfiguration.Property(e => e.AddressLine1).HasColumnName("Address Line1");
        trustConfiguration.Property(e => e.AddressLine2).HasColumnName("Address Line2");
        trustConfiguration.Property(e => e.AddressLine3).HasColumnName("Address Line3");
        trustConfiguration.Property(e => e.Town).HasColumnName("Town");
        trustConfiguration.Property(e => e.County).HasColumnName("County");
        trustConfiguration.Property(e => e.Postcode).HasColumnName("Postcode");
        trustConfiguration.Property(e => e.PrioritisedForReview).HasColumnName("Prioritised for Review");
        trustConfiguration.Property(e => e.CurrentSingleListGrouping).HasColumnName("Current Single List Grouping");
        trustConfiguration.Property(e => e.DateOfGroupingDecision).HasColumnName("Date of Grouping Decision");
        trustConfiguration.Property(e => e.DateEnteredOntoSingleList).HasColumnName("Date Entered Onto Single List");
        trustConfiguration.Property(e => e.TrustReviewWriteUp).HasColumnName("Trust Review Write Up");
        trustConfiguration.Property(e => e.DateOfTrustReviewMeeting).HasColumnName("Date of Trust Review Meeting");
        trustConfiguration.Property(e => e.FollowUpLetterSent).HasColumnName("Follow Up Letter Sent");
        trustConfiguration.Property(e => e.DateActionPlannedFor).HasColumnName("Date Action Planned For");
        trustConfiguration.Property(e => e.WIPSummaryGoesToMinister).HasColumnName("WIP Summary Goes To Minister");
        trustConfiguration.Property(e => e.ExternalGovernanceReviewDate).HasColumnName("External Governance Review Date");
        trustConfiguration.Property(e => e.EfficiencyICFPReviewCompleted).HasColumnName("Efficiency ICFP Review Completed");
        trustConfiguration.Property(e => e.EfficiencyICFPReviewOther).HasColumnName("Efficiency ICFP Review Other");
        trustConfiguration.Property(e => e.LinkToWorkplaceForEfficiencyICFPReview).HasColumnName("Link To Workplace For Efficiency ICFP Review");
        trustConfiguration.Property(e => e.NumberInTrust).HasColumnName("Number In Trust");
        trustConfiguration.Property(e => e.Modified).HasColumnName("Modified");
        trustConfiguration.Property(e => e.ModifiedBy).HasColumnName("Modified By");
        trustConfiguration.Property(e => e.AMSDTerritory).HasColumnName("AMSD Territory");
        trustConfiguration.Property(e => e.LeadAMSDTerritory).HasColumnName("Lead AMSD Territory");
        trustConfiguration.Property(e => e.UKPRN).HasColumnName("UKPRN");
        trustConfiguration.Property(e => e.TrustPerformanceAndRiskDateOfMeeting).HasColumnName("Trust Performance And Risk Date Of Meeting");
        trustConfiguration.Property(e => e.UPIN).HasColumnName("UPIN");
        trustConfiguration.Property(e => e.IncorporatedOnOpenDate).HasColumnName("Incorporated on (open date)");

        trustConfiguration
            .HasOne(x => x.TrustType)
            .WithMany()
            .HasForeignKey(x => x.TrustTypeId);
    }

    private void ConfigureTrustType(EntityTypeBuilder<TrustType> trustTypeConfiguration)
    {
        trustTypeConfiguration.HasKey(e => e.SK);

        trustTypeConfiguration.ToTable("Ref_TrustType", DEFAULT_SCHEMA);

        trustTypeConfiguration.HasData(new TrustType() { SK = 30, Code = "06", Name = "Multi-academy trust" });
        trustTypeConfiguration.HasData(new TrustType() { SK = 32, Code = "10", Name = "Single-academy trust" });
    }
    private void ConfigureEducationEstablishmentTrust(EntityTypeBuilder<EducationEstablishmentTrust> entityBuilder)
    {
        entityBuilder.HasKey(e => e.SK);
        entityBuilder.ToTable("EducationEstablishmentTrust", DEFAULT_SCHEMA);

        entityBuilder.Property(e => e.EducationEstablishmentId).HasColumnName("FK_EducationEstablishment");
        entityBuilder.Property(e => e.TrustId).HasColumnName("FK_Trust");
    }

    private void ConfigureLocalAuthority(EntityTypeBuilder<LocalAuthority> localAuthorityConfiguration)
    {
        localAuthorityConfiguration.HasKey(e => e.SK);
        localAuthorityConfiguration.ToTable("Ref_LocalAuthority", DEFAULT_SCHEMA);

        localAuthorityConfiguration.HasData(new LocalAuthority() { SK = 1, Code = "202", Name = "Barnsley" });
        localAuthorityConfiguration.HasData(new LocalAuthority() { SK = 2, Code = "203", Name = "Birmingham" });
        localAuthorityConfiguration.HasData(new LocalAuthority() { SK = 3, Code = "204", Name = "Bradford" });
    }

    private void ConfigureEstablishmentType(EntityTypeBuilder<EstablishmentType> establishmentTypeConfiguration)
    {
        establishmentTypeConfiguration.HasKey(e => e.SK);
        establishmentTypeConfiguration.ToTable("Ref_EducationEstablishmentType", DEFAULT_SCHEMA);

        establishmentTypeConfiguration.HasData(new EstablishmentType() { SK = 224, Code = "35", Name = "Free schools" });
        establishmentTypeConfiguration.HasData(new EstablishmentType() { SK = 228, Code = "18", Name = "Further education" });
    }

    private void ConfigureIfdPipeline(EntityTypeBuilder<IfdPipeline> ifdPipelineConfiguration)
    {
        ifdPipelineConfiguration.HasKey(e => e.SK);

        ifdPipelineConfiguration.ToTable("IfdPipeline", DEFAULT_SCHEMA);

        ifdPipelineConfiguration.Property(e => e.GeneralDetailsUrn)
            .HasColumnName("General Details.URN");

        ifdPipelineConfiguration.Property(e => e.DeliveryProcessPFI)
            .HasColumnName("Delivery Process.PFI");
        ifdPipelineConfiguration.Property(e => e.DeliveryProcessPAN)
            .HasColumnName("Delivery Process.PAN");

        ifdPipelineConfiguration.Property(e => e.ProjectTemplateInformationDeficit)
            .HasColumnName("Project template information.Deficit?");
        ifdPipelineConfiguration.Property(e => e.ProjectTemplateInformationViabilityIssue)
            .HasColumnName("Project template information.Viability issue?");
    }

}
