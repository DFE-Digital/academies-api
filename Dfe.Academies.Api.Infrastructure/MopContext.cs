using Dfe.Academies.Domain.Constituencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Academies.Academisation.Data;

public class MopContext : DbContext
{
    const string DEFAULT_SCHEMA = "mop";

    public MopContext()
    {

    }

    public MopContext(DbContextOptions<MopContext> options) : base(options)
    {

    }

    public DbSet<MemberContactDetails> MemberContactDetails { get; set; } = null!;
    public DbSet<Constituency> Constituencies { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=sip;Integrated Security=true;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemberContactDetails>(ConfigureMemberContactDetails);
        modelBuilder.Entity<Constituency>(ConfigureConstituency);

        base.OnModelCreating(modelBuilder);
    }


    private void ConfigureMemberContactDetails(EntityTypeBuilder<MemberContactDetails> memberContactDetailsConfiguration)
    {
        memberContactDetailsConfiguration.HasKey(e => e.MemberID);

        memberContactDetailsConfiguration.ToTable("MemberContactDetails", DEFAULT_SCHEMA);
        memberContactDetailsConfiguration.Property(e => e.MemberID).HasColumnName("memberID");
        memberContactDetailsConfiguration.Property(e => e.Email).HasColumnName("email");
        memberContactDetailsConfiguration.Property(e => e.Phone).HasColumnName("phone");
        memberContactDetailsConfiguration.Property(e => e.TypeId).HasColumnName("typeId");
    }

    private void ConfigureConstituency(EntityTypeBuilder<Constituency> constituencyConfiguration)
    {
        constituencyConfiguration.ToTable("Constituencies", DEFAULT_SCHEMA);
        constituencyConfiguration.Property(e => e.ConstituencyId).HasColumnName("constituencyId");
        constituencyConfiguration.Property(e => e.ConstituencyName).HasColumnName("constituencyName");
        constituencyConfiguration.Property(e => e.NameList).HasColumnName("nameListAs");
        constituencyConfiguration.Property(e => e.NameDisplayAs).HasColumnName("nameDisplayAs");
        constituencyConfiguration.Property(e => e.NameFullTitle).HasColumnName("nameFullTitle");
        constituencyConfiguration.Property(e => e.NameFullTitle).HasColumnName("nameFullTitle");
        constituencyConfiguration.Property(e => e.LastRefresh).HasColumnName("lastRefresh");
    }


}
