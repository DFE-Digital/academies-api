using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GlobalOptionSetMetadata> GlobalOptionSetMetadata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=sip;persist security info=True;User id=sa; Password=StrongPassword905");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlobalOptionSetMetadata>(entity =>
            {
                entity.HasKey(e => new { e.OptionSetName, e.Option, e.IsUserLocalizedLabel, e.LocalizedLabelLanguageCode })
                    .HasName("PK__GlobalOp__C1071A5B45CD0479");

                entity.ToTable("GlobalOptionSetMetadata", "cdm");

                entity.Property(e => e.OptionSetName).HasMaxLength(64);

                entity.Property(e => e.LocalizedLabel).HasMaxLength(350);
            });

            modelBuilder.HasSequence<int>("AcademyTransferProjectUrns")
                .StartsAt(10000000)
                .HasMin(10000000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
