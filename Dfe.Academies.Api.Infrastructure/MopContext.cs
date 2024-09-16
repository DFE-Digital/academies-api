using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Academies.Infrastructure;

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

    private static void ConfigureMemberContactDetails(EntityTypeBuilder<MemberContactDetails> memberContactDetailsConfiguration)
    {
        memberContactDetailsConfiguration.HasKey(e => e.MemberId);

        memberContactDetailsConfiguration.ToTable("MemberContactDetails", DEFAULT_SCHEMA);
        memberContactDetailsConfiguration.Property(e => e.MemberId).HasColumnName("memberID")
                .HasConversion(
                    v => v.Value,
                    v => new MemberId(v));
        memberContactDetailsConfiguration.Property(e => e.Email).HasColumnName("email");
        memberContactDetailsConfiguration.Property(e => e.Phone).HasColumnName("phone");
        memberContactDetailsConfiguration.Property(e => e.TypeId).HasColumnName("typeId");
    }

    private void ConfigureConstituency(EntityTypeBuilder<Constituency> constituencyConfiguration)
    {
        constituencyConfiguration.ToTable("Constituencies", DEFAULT_SCHEMA);
        constituencyConfiguration.Property(e => e.ConstituencyId).HasColumnName("constituencyId")
            .HasConversion(
                    v => v.Value,
                    v => new ConstituencyId(v));
        constituencyConfiguration.Property(e => e.MemberId)
            .HasConversion(
                    v => v.Value,
                    v => new MemberId(v));
        constituencyConfiguration.Property(e => e.ConstituencyName).HasColumnName("constituencyName");

        constituencyConfiguration.OwnsOne(e => e.NameDetails, nameDetails =>
        {
            nameDetails.Property(nd => nd.NameListAs).HasColumnName("nameListAs");
            nameDetails.Property(nd => nd.NameDisplayAs).HasColumnName("nameDisplayAs");
            nameDetails.Property(nd => nd.NameFullTitle).HasColumnName("nameFullTitle");
        });

        constituencyConfiguration.Property(e => e.LastRefresh).HasColumnName("lastRefresh");

        constituencyConfiguration
            .HasOne(c => c.MemberContactDetails)
            .WithOne()
            .HasForeignKey<Constituency>(c => c.MemberId)
            .HasPrincipalKey<MemberContactDetails>(m => m.MemberId);
    }


}
