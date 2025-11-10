using Dfe.Academies.Domain.SignificantChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Academies.Infrastructure
{
    public class SigChgMstrContext(DbContextOptions<SigChgMstrContext> options) : DbContext(options)
    {
        const string DEFAULT_SCHEMA = "sig_chg_mstr";

        public DbSet<SignificantChange> SignificantChanges { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=sip;Integrated_Security=true;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignificantChange>(ConfigureSignificantChange);

            base.OnModelCreating(modelBuilder);
        }
        private static void ConfigureSignificantChange(EntityTypeBuilder<SignificantChange> establishmentConfiguration)
        {
            establishmentConfiguration.HasKey(e => e.SignificantChangeId);

            establishmentConfiguration.Property(e => e.SignificantChangeId).HasColumnName("sig_change_id");

            establishmentConfiguration.ToTable("sig_changes", DEFAULT_SCHEMA);

            establishmentConfiguration.Property(e => e.URN).HasColumnName("urn");
            establishmentConfiguration.Property(e => e.TypeofGiasChangeId).HasColumnName("type_of_gias_change_id");
            establishmentConfiguration.Property(e => e.TypeofSigChange).HasColumnName("type_of_sig_change");
            establishmentConfiguration.Property(e => e.TypeofSigChangedMapped).HasColumnName("type_of_sig_change_mapped");
            establishmentConfiguration.Property(e => e.CreatedUserName).HasColumnName("created_user_name");
            establishmentConfiguration.Property(e => e.EditedUserName).HasColumnName("edited_user_name");
            establishmentConfiguration.Property(e => e.ApplicationType).HasColumnName("application_type");
            establishmentConfiguration.Property(e => e.DecisionDate).HasColumnName("decision_date");
            establishmentConfiguration.Property(e => e.DeliveryLead).HasColumnName("delivery_lead");
            establishmentConfiguration.Property(e => e.ChangeCreationDate).HasColumnName("change_creation_date");
            establishmentConfiguration.Property(e => e.ChangeEditDate).HasColumnName("change_edit_date");
            establishmentConfiguration.Property(e => e.AllActionsCompleted).HasColumnName("all_actions_completed");
            establishmentConfiguration.Property(e => e.Withdrawn).HasColumnName("withdrawn");
            establishmentConfiguration.Property(e => e.LocalAuthority).HasColumnName("local_authority");
            establishmentConfiguration.Property(e => e.Region).HasColumnName("region");
            establishmentConfiguration.Property(e => e.TrustName).HasColumnName("trust_name");
            establishmentConfiguration.Property(e => e.AcademyName).HasColumnName("academy_name");
            establishmentConfiguration.Property(e => e.MetaIngestionDateTime).HasColumnName("meta_ingestion_datetime");
            establishmentConfiguration.Property(e => e.MetaSourceSystem).HasColumnName("meta_source_system");
        }
    }
}
