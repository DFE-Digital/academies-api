
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.Mime.MediaTypeNames;

namespace Dfe.Academies.Academisation.Data;

public class MstrContext : DbContext
{
    const string DEFAULT_SCHEMA = "mstr";
    public MstrContext(DbContextOptions<MstrContext> options) : base(options)
    {

    }

    public DbSet<Trust> Trusts { get; set; } = null!;
    public DbSet<TrustType> TrustTypes { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trust>(ConfigureTrust);
        modelBuilder.Entity<TrustType>(ConfigureTrustType);

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// New mapping for refactoring
    /// </summary>
    /// <param name="trustConfiguration"></param>

    void ConfigureTrust(EntityTypeBuilder<Trust> trustConfiguration)
    {
        trustConfiguration.HasKey(e => e.SK).HasName("SK");

        trustConfiguration.ToTable("Trust", DEFAULT_SCHEMA);

        trustConfiguration.Property(e => e.TrustsTrustType).HasColumnName("FK_TrustType");
        trustConfiguration.Property(e => e.Region).HasColumnName("FK_Region");
        trustConfiguration.Property(e => e.TrustBanding).HasColumnName("FK_TrustBanding");
        trustConfiguration.Property(e => e.FK_TrustStatus).HasColumnName("FK_TrustStatus");
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
        .WithOne()
        .HasForeignKey<Trust>(x => x.TrustsTrustType)
        .IsRequired(false);
    }

    void ConfigureTrustType(EntityTypeBuilder<TrustType> trustTypeConfiguration) {
        trustTypeConfiguration.HasKey(e => e.SK).HasName("SK");

        trustTypeConfiguration.ToTable("Ref_TrustType", DEFAULT_SCHEMA);
    }

}
