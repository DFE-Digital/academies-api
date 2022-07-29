using System;
using System.Linq;
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
        public virtual DbSet<AcademyConversionProject> AcademyConversionProjects { get; set; }
        public virtual DbSet<AcademyConversionProjectNote> AcademyConversionProjectNotes { get; set; }
        public virtual DbSet<ConcernsCase> ConcernsCase { get; set; }
        public virtual DbSet<ConcernsStatus> ConcernsStatus { get; set; }
        public virtual DbSet<ConcernsRecord> ConcernsRecord { get; set; }
        public virtual DbSet<ConcernsType> ConcernsTypes { get; set; }
        public virtual DbSet<ConcernsRating> ConcernsRatings { get; set; }
        public virtual DbSet<A2BApplication> A2BApplications { get; set; }
        public virtual DbSet<A2BApplicationKeyPersons> A2BApplicationKeyPersons { get; set; }
        public virtual DbSet<A2BApplicationApplyingSchool> A2BApplicationApplyingSchools { get; set; }
        public virtual DbSet<A2BSchoolLease> A2BSchoolLeases { get; set; }
        public virtual DbSet<A2BSchoolLoan> A2BSchoolLoans { get; set; }
        public virtual DbSet<FssProject> FssProjects { get; set; }
        public virtual DbSet<SRMAStatus> SRMAStatuses { get; set; }
        public virtual DbSet<SRMAReason> SRMAReasons { get; set; }
        public virtual DbSet<SRMACase> SRMACases { get; set; }
        public virtual DbSet<FinancialPlanStatus> FinancialPlanStatuses { get; set; }
        public virtual DbSet<FinancialPlanCase> FinancialPlanCases { get; set; }
        public virtual DbSet<NTIUnderConsiderationStatus> NTIUnderConsiderationStatuses { get; set; }
        public virtual DbSet<NTIUnderConsiderationReason> NTIUnderConsiderationReasons { get; set; }
        public virtual DbSet<NTIUnderConsideration> NTIUnderConsiderations { get; set; }
        public virtual DbSet<NTIUnderConsiderationReasonMapping> NTIUnderConsiderationReasonMappings { get; set; }


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

            modelBuilder.Entity<AcademyConversionProject>(entity =>
            {
                entity.ToTable("AcademyConversionProject", "sdd");
            });

            modelBuilder.Entity<AcademyConversionProjectNote>(entity =>
            {
                entity.ToTable("AcademyConversionProjectNote", "sdd");
            });

            modelBuilder.HasSequence<int>("ConcernsGlobalSequence").HasMin(1).StartsAt(1);


            modelBuilder.Entity<ConcernsCase>(entity =>
            {
                entity.ToTable("ConcernsCase", "sdd");

                entity.HasKey(e => e.Id)
                    .HasName("PK__CCase__C5B214360AF620234");

                entity.Property(e => e.Urn)
                    .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

            });

            modelBuilder.Entity<ConcernsStatus>(entity =>
            {
                entity.ToTable("ConcernsStatus", "sdd");

                entity.HasKey(e => e.Id)
                    .HasName("PK__CStatus__C5B214360AF620234");

                entity.Property(e => e.Urn)
                    .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                entity.HasData(
                    new ConcernsStatus
                    {
                        Id = 1,
                        Name = "Live",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsStatus
                    {
                        Id = 2,
                        Name = "Monitoring",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsStatus
                    {
                        Id = 3,
                        Name = "Close",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    }
                    );
            });

            modelBuilder.Entity<ConcernsRecord>(entity =>
            {
                entity.ToTable("ConcernsRecord", "sdd");

                entity.HasKey(e => e.Id)
                    .HasName("PK__CRecord");

                entity.Property(e => e.Urn)
                    .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                entity.HasOne(r => r.ConcernsCase)
                    .WithMany(c => c.ConcernsRecords)
                    .HasForeignKey(r => r.CaseId)
                    .HasConstraintName("FK__ConcernsCase_ConcernsRecord");

                entity.HasOne(r => r.ConcernsType)
                    .WithMany(c => c.FkConcernsRecord)
                    .HasForeignKey(r => r.TypeId)
                    .HasConstraintName("FK__ConcernsRecord_ConcernsType");

                entity.HasOne(r => r.ConcernsRating)
                    .WithMany(c => c.FkConcernsRecord)
                    .HasForeignKey(r => r.RatingId)
                    .HasConstraintName("FK__ConcernsRecord_ConcernsRating");
            });

            modelBuilder.Entity<ConcernsType>(entity =>
            {
                entity.ToTable("ConcernsType", "sdd");

                entity.HasKey(e => e.Id)
                    .HasName("PK__CType");

                entity.Property(e => e.Urn)
                    .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                entity.HasData(
                    new ConcernsType
                    {
                        Id = 1,
                        Name = "Compliance",
                        Description = "Financial reporting",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 2,
                        Name = "Compliance",
                        Description = "Financial returns",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 3,
                        Name = "Financial",
                        Description = "Deficit",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 4,
                        Name = "Financial",
                        Description = "Projected deficit / Low future surplus",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 5,
                        Name = "Financial",
                        Description = "Cash flow shortfall",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 6,
                        Name = "Financial",
                        Description = "Clawback",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 7,
                        Name = "Force majeure",
                        Description = null,
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 8,
                        Name = "Governance",
                        Description = "Governance",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 9,
                        Name = "Governance",
                        Description = "Closure",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 10,
                        Name = "Governance",
                        Description = "Executive Pay",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 11,
                        Name = "Governance",
                        Description = "Safeguarding",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 12,
                        Name = "Irregularity",
                        Description = "Allegations and self reported concerns",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsType
                    {
                        Id = 13,
                        Name = "Irregularity",
                        Description = "Related party transactions - in year",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    }
                );
            });

            modelBuilder.Entity<ConcernsRating>(entity =>
            {
                entity.ToTable("ConcernsRating", "sdd");

                entity.HasKey(e => e.Id)
                    .HasName("PK__CRating");

                entity.Property(e => e.Urn)
                    .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                entity.HasData(
                    new ConcernsRating
                    {
                        Id = 1,
                        Name = "Red-Plus",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsRating
                    {
                        Id = 2,
                        Name = "Red",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsRating
                    {
                        Id = 3,
                        Name = "Red-Amber",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsRating
                    {
                        Id = 4,
                        Name = "Amber-Green",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    },
                    new ConcernsRating
                    {
                        Id = 5,
                        Name = "n/a",
                        CreatedAt = new DateTime(2021, 11, 17),
                        UpdatedAt = new DateTime(2021, 11, 17)
                    });
            });

            modelBuilder.Entity<FssProject>(entity =>
            {
                entity.ToView("vw_Fss_ProjectData", "fsg");
                entity.HasNoKey();
            });

            modelBuilder.Entity<SRMAStatus>(entity =>
            {
                entity.ToTable("SRMAStatus", "sdd");

                entity.HasData(
                    Enum.GetValues(typeof(Enums.SRMAStatus)).Cast<Enums.SRMAStatus>()
                    .Where(enm => enm != Enums.SRMAStatus.Unknown)
                    .Select(enm => new SRMAStatus
                    {
                        Id = (int)enm,
                        Name = enm.ToString(),
                        CreatedAt = new DateTime(2022, 05, 06),
                        UpdatedAt = new DateTime(2022, 05, 06)
                    }));
            });

            modelBuilder.Entity<SRMAReason>(entity =>
            {
                entity.ToTable("SRMAReason", "sdd");

                entity.HasData(
                    Enum.GetValues(typeof(Enums.SRMAReasonOffered)).Cast<Enums.SRMAReasonOffered>()
                    .Where(enm => enm != Enums.SRMAReasonOffered.Unknown)
                    .Select(enm => new SRMAStatus
                    {
                        Id = (int)enm,
                        Name = enm.ToString(),
                        CreatedAt = new DateTime(2022, 05, 06),
                        UpdatedAt = new DateTime(2022, 05, 06)
                    }));
            });


            modelBuilder.Entity<FinancialPlanStatus>(entity =>
            {
                var createdAt = new DateTime(2022, 06, 15);
                entity.ToTable("FinancialPlanStatus", "sdd");

                entity.HasData(
                     new FinancialPlanStatus[]
                    {
                        new FinancialPlanStatus{ Id = 1, Name = "AwaitingPlan", CreatedAt = createdAt, UpdatedAt = createdAt },
                        new FinancialPlanStatus{ Id = 2, Name = "ReturnToTrust", CreatedAt = createdAt, UpdatedAt = createdAt },
                        new FinancialPlanStatus{ Id = 3, Name = "ViablePlanReceived", CreatedAt = createdAt, UpdatedAt = createdAt },
                        new FinancialPlanStatus{ Id = 4, Name = "Abandoned", CreatedAt = createdAt, UpdatedAt = createdAt },
                    });
            });

            modelBuilder.Entity<NTIUnderConsiderationStatus>(entity =>
            {
                entity.ToTable("NTIUnderConsiderationStatus", "sdd");

                entity.HasData(
                    Enum.GetValues(typeof(Enums.NTIUnderConsiderationStatus)).Cast<Enums.NTIUnderConsiderationStatus>()
                    .Where(enm => enm != Enums.NTIUnderConsiderationStatus.Unknown)
                    .Select(enm => new NTIUnderConsiderationStatus
                    {
                        Id = (int)enm,
                        Name = enm.ToString(),
                        CreatedAt = new DateTime(2022, 06, 14),
                        UpdatedAt = new DateTime(2022, 06, 14)
                    }));
            });

            modelBuilder.Entity<NTIUnderConsiderationReason>(entity =>
            {
                entity.ToTable("NTIUnderConsiderationReason", "sdd");

                entity.HasData(
                    Enum.GetValues(typeof(Enums.NTIUnderConsiderationReason)).Cast<Enums.NTIUnderConsiderationReason>()
                    .Where(enm => enm != Enums.NTIUnderConsiderationReason.Unknown)
                    .Select(enm => new NTIUnderConsiderationReason
                    {
                        Id = (int)enm,
                        Name = enm.ToString(),
                        CreatedAt = new DateTime(2022, 06, 14),
                        UpdatedAt = new DateTime(2022, 06, 14)
                    }));
            });

            modelBuilder.Entity<NTIUnderConsiderationReasonMapping>()
                .HasOne(n => n.NTIUnderConsideration)
                .WithMany(n => n.UnderConsiderationReasonsMapping)
                .HasForeignKey(n => n.NTIUnderConsiderationId);

            modelBuilder.Entity<NTIUnderConsiderationReasonMapping>()
                .HasOne(n => n.NTIUnderConsiderationReason)
                .WithMany(n => n.UnderConsiderationReasonsMapping)
                .HasForeignKey(n => n.NTIUnderConsiderationReasonId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
