using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Data
{
    public class TramsDbContext : DbContext
    {
        public TramsDbContext(DbContextOptions<TramsDbContext> options) : base(options)
        {
        }
        public DbSet<Group> Trusts { get; set; }
    }
}