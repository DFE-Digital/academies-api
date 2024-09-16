using Dfe.Academies.Domain.EducationalPerformance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Academies.Infrastructure
{
    public class EdperfContext : DbContext
    {
        const string DEFAULT_SCHEMA = "edperf";

        public EdperfContext()
        {

        }

        public EdperfContext(DbContextOptions<EdperfContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Ed perf is split across two contexts, Legacy and Edperf
                // We need to use the docker image, because this context only has part of the schema
                // When the migration is generated it needs to only include the differences between the docker image and this context
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=sip;Integrated Security=true;TrustServerCertificate=True");
            }
        }

        public DbSet<SchoolAbsence> SchoolAbsences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolAbsence>(ConfigureSchoolAbsence);


            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureSchoolAbsence(EntityTypeBuilder<SchoolAbsence> schoolAbsenceConfiguration)
        {
            schoolAbsenceConfiguration.ToTable("download_PUPILABSENCE_england_ALL", DEFAULT_SCHEMA);
            schoolAbsenceConfiguration.HasKey(e => new { e.DownloadYear, e.URN, e.LA, e.ESTAB });
        }
    }
}
