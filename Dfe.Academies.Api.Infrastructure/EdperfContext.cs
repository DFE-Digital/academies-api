using Dfe.Academies.Academisation.Data;
using Dfe.Academies.Domain.EducationalPerformance;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
