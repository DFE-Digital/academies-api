using Microsoft.EntityFrameworkCore;

namespace TramsDataApi.DatabaseModels
{
    public partial class TramsDbContext : DbContext
    {
        public TramsDbContext()
        {
        }

        public TramsDbContext(DbContextOptions<TramsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademyTransferProjectIntendedTransferBenefits> AcademyTransferProjectIntendedTransferBenefits { get; set; }
        public virtual DbSet<AcademyTransferProjects> AcademyTransferProjects { get; set; }
        public virtual DbSet<TransferringAcademies> TransferringAcademies { get; set; }
        public virtual DbSet<A2BApplication> A2BApplications { get; set; }
        public virtual DbSet<A2BApplicationKeyPersons> A2BApplicationKeyPersons { get; set; }
        public virtual DbSet<A2BApplicationApplyingSchool> A2BApplicationApplyingSchools { get; set; }
        public virtual DbSet<A2BSchoolLease> A2BSchoolLeases { get; set; }
        public virtual DbSet<A2BSchoolLoan> A2BSchoolLoans { get; set; }
        public virtual DbSet<FssProject> FssProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=local_trams_test_db;persist security info=True;User id=sa; Password=StrongPassword905");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademyTransferProjectIntendedTransferBenefits>(entity =>
            {
                entity.ToTable("AcademyTransferProjectIntendedTransferBenefits", "sdd");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkAcademyTransferProjectId).HasColumnName("fk_AcademyTransferProjectId");

                entity.Property(e => e.SelectedBenefit).IsRequired();

                entity.HasOne(d => d.FkAcademyTransferProject)
                    .WithMany(p => p.AcademyTransferProjectIntendedTransferBenefits)
                    .HasForeignKey(d => d.FkAcademyTransferProjectId)
                    .HasConstraintName("FK__AcademyTr__fk_Ac__4316F928");
            });

            modelBuilder.HasSequence<int>("AcademyTransferProjectUrns").HasMin(10000000).StartsAt(10000000);

            modelBuilder.Entity<AcademyTransferProjects>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__AcademyT__C5B214360AF6201A");

                entity.ToTable("AcademyTransferProjects", "sdd");

                entity.HasIndex(e => e.Urn)
                    .HasName("AcademyTransferProjectUrn");

                entity.Property(e => e.Urn)
                    .HasDefaultValueSql("NEXT VALUE FOR AcademyTransferProjectUrns");

                entity.Property(e => e.HtbDate).HasColumnType("date");

                entity.Property(e => e.OutgoingTrustUkprn)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.TargetDateForTransfer).HasColumnType("date");
                entity.Property(e => e.TransferFirstDiscussed).HasColumnType("date");
                entity.Property(e => e.AssignedUserId).HasColumnType("uniqueidentifier");
                entity.Property(e => e.AssignedUserFullName).HasColumnType("nvarchar(max)");
                entity.Property(e => e.AssignedUserEmailAddress).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<TransferringAcademies>(entity =>
            {
                entity.ToTable("TransferringAcademies", "sdd");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkAcademyTransferProjectId).HasColumnName("fk_AcademyTransferProjectId");

                entity.Property(e => e.IncomingTrustUkprn).HasMaxLength(8);

                entity.Property(e => e.OutgoingAcademyUkprn)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.FkAcademyTransferProject)
                    .WithMany(p => p.TransferringAcademies)
                    .HasForeignKey(d => d.FkAcademyTransferProjectId)
                    .HasConstraintName("FK__Transferr__fk_Ac__403A8C7D");
            });

            modelBuilder.Entity<FssProject>(entity =>
            {
                entity.ToView("vw_Fss_ProjectData", "fsg");
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}