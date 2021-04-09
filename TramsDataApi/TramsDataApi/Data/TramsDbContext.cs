using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Data
{
    public class TramsDbContext : DbContext
    {
        public TramsDbContext(DbContextOptions<TramsDbContext> options) : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Group>().ToTable("Group");
        // }
    }
}