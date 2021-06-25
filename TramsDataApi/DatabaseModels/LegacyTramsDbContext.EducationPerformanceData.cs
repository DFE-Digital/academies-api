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
                
                entity.Property(e => e.SipReadingprogressscore)
                    .HasColumnName("sip_readingprogressscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressscoredisadv)
                    .HasColumnName("sip_readingprogressscoredisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressscore)
                    .HasColumnName("sip_writingprogressscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressscoredisadv)
                    .HasColumnName("sip_writingprogressscoredisadv")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipMathsprogressscore)
                    .HasColumnName("sip_mathsprogressscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogressscoredisadv)
                    .HasColumnName("sip_mathsprogressscoredisadv")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipAttainment8score)
                    .HasColumnName("sip_attainment8score")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipAttainment8scoredisadvantaged)
                    .HasColumnName("sip_attainment8scoredisadvantaged")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipAttainment8scoreenglish)
                    .HasColumnName("sip_attainment8scoreenglish")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreenglishdisadvantaged)
                    .HasColumnName("sip_attainment8scoreenglishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipAttainment8scoremaths)
                    .HasColumnName("sip_attainment8scoremaths")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoremathsdisadvantaged)
                    .HasColumnName("sip_attainment8scoremathsdisadvantaged")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipAttainment8scoreebacc)
                    .HasColumnName("sip_attainment8scoreebacc")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreebaccdisadvantaged)
                    .HasColumnName("sip_attainment8scoreebaccdisadvantaged")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipNumberofpupilsprogress8)
                    .HasColumnName("sip_numberofpupilsprogress8");

                entity.Property(e => e.SipNumberofpupilsprogress8disadvantaged)
                    .HasColumnName("sip_numberofpupilsprogress8disadvantaged");
                
                entity.Property(e => e.SipProgress8lowerconfidence)
                    .HasColumnName("sip_progress8lowerconfidence")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipProgress8upperconfidence)
                    .HasColumnName("sip_progress8upperconfidence")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipProgress8english)
                    .HasColumnName("sip_progress8english")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8englishdisadvantaged)
                    .HasColumnName("sip_progress8englishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipProgress8maths)
                    .HasColumnName("sip_progress8maths")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8mathsdisadvantaged)
                    .HasColumnName("sip_progress8mathsdisadvantaged")
                    .HasColumnType("decimal(38, 2)");
                
                entity.Property(e => e.SipProgress8ebacc)
                    .HasColumnName("sip_progress8ebacc")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8ebaccdisadvantaged)
                    .HasColumnName("sip_progress8ebaccdisadvantaged")
                    .HasColumnType("decimal(38, 2)");
            });
        }
    }
}
