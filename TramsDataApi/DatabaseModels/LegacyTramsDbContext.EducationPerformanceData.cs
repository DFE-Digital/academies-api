using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class LegacyTramsDbContext
    {

        public virtual DbSet<SipEducationalperformancedata> SipEducationalperformancedata { get; set; }

        protected void OnModelCreatingEducationPerformancedata(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SipEducationalperformancedata>(entity =>
            {
                entity.ToTable("sip_educationalperformancedata", "cdm");

                entity.Property(e => e.Id).ValueGeneratedNever();
                
                entity.Property(e => e.SipParentaccountid).HasColumnName("sip_parentaccountid");

                entity.Property(e => e.SipMeetingexpectedstandardinrwm)
                    .HasColumnName("sip_meetingexpectedstandardinrwm")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipMeetingexpectedstandardinrwmdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinrwmdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetinghigherstandardinrwm)
                    .HasColumnName("sip_meetinghigherstandardinrwm")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetinghigherstandardrwmdisadv)
                    .HasColumnName("sip_meetinghigherstandardrwmdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipName)
                    .HasColumnName("sip_name")
                    .HasMaxLength(100);
                    
                entity.Property(e => e.SipProgress8score)
                    .HasColumnName("sip_progress8score")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scoredisadvantaged)
                     .HasColumnName("sip_progress8scoredisadvantaged")
                     .HasColumnType("decimal(38, 2)");
            });
        }
    }
}
