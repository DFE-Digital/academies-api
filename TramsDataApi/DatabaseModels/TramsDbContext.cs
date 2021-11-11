using System;
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
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }, 
                    new ConcernsStatus
                    {
                        Id = 2,
                        Name = "Monitoring",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsStatus
                    {   Id = 3,
                        Name = "Close",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
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
                
                entity.HasOne(r => r.FkConcernsCase)
                    .WithMany(c => c.ConcernsRecords)
                    .HasForeignKey(r => r.CaseId)
                    .HasConstraintName("FK__ConcernsCase_ConcernsRecord");
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
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 2,
                        Name = "Compliance",
                        Description = "Financial returns",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 3,
                        Name = "Financial",
                        Description = "Deficit",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 4,
                        Name = "Financial",
                        Description = "Projected deficit / Low future surplus",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 5,
                        Name = "Financial",
                        Description = "Cash flow shortfall",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 6,
                        Name = "Financial",
                        Description = "Clawback",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 7,
                        Name = "Force majeure",
                        Description = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 8,
                        Name = "Governance",
                        Description = "Governance",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 9,
                        Name = "Governance",
                        Description = "Closure",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 10,
                        Name = "Governance",
                        Description = "Executive Pay",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 11,
                        Name = "Governance",
                        Description = "Safeguarding",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 12,
                        Name = "Irregularity",
                        Description = "Allegations and self reported concerns",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ConcernsType
                    {
                        Id = 13,
                        Name = "Irregularity",
                        Description = "Related party transactions - in year",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
