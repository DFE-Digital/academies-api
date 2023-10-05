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