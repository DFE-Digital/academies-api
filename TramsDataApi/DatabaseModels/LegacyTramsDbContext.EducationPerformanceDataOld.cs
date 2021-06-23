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

        public virtual DbSet<SipEducationalperformancedataOld> SipEducationalperformancedataOld { get; set; }

        protected void OnModelCreatingEducationPerformancedataOld(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SipEducationalperformancedataOld>(entity =>
            {
                entity.ToTable("sip_educationalperformancedata", "cdm");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Createdbyyominame)
                    .HasColumnName("createdbyyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createdonbehalfbyname)
                    .HasColumnName("createdonbehalfbyname")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdonbehalfbyyominame)
                    .HasColumnName("createdonbehalfbyyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Importsequencenumber).HasColumnName("importsequencenumber");
                
                entity.Property(e => e.SinkCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.SinkModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.SipAachievingebaccatgrade4coraboveengland)
                    .HasColumnName("sip_aachievingebaccatgrade4coraboveengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccatgrade4corabovela)
                    .HasColumnName("sip_aachievingebaccatgrade4corabovela")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccatgrade4corabovesecondary)
                    .HasColumnName("sip_aachievingebaccatgrade4corabovesecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccatgrade5coraboveengland)
                    .HasColumnName("sip_aachievingebaccatgrade5coraboveengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccatgrade5corabovela)
                    .HasColumnName("sip_aachievingebaccatgrade5corabovela")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccatgrade5corabovelocalauth)
                    .HasColumnName("sip_aachievingebaccatgrade5corabovelocalauth")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccatgrade5corabovesecondary)
                    .HasColumnName("sip_aachievingebaccatgrade5corabovesecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade4corabovedisad)
                    .HasColumnName("sip_aachievingebaccgrade4corabovedisad")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade4corabovedisadeng)
                    .HasColumnName("sip_aachievingebaccgrade4corabovedisadeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade4corabovedisadla)
                    .HasColumnName("sip_aachievingebaccgrade4corabovedisadla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade4corabovelocalauth)
                    .HasColumnName("sip_aachievingebaccgrade4corabovelocalauth")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade5corabovedisadengl)
                    .HasColumnName("sip_aachievingebaccgrade5corabovedisadengl")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade5corabovedisadla)
                    .HasColumnName("sip_aachievingebaccgrade5corabovedisadla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAachievingebaccgrade5corabovedisadvantage)
                    .HasColumnName("sip_aachievingebaccgrade5corabovedisadvantage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8ebaccscoresecondarydisadvanta)
                    .HasColumnName("sip_aattainment8ebaccscoresecondarydisadvanta")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8ebaccsecondarydisadvantageden)
                    .HasColumnName("sip_aattainment8ebaccsecondarydisadvantageden")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8ebaccsecondarydisadvantagedla)
                    .HasColumnName("sip_aattainment8ebaccsecondarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8englishscoresecondarydisadvan)
                    .HasColumnName("sip_aattainment8englishscoresecondarydisadvan")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8englishsecondarydisadeng)
                    .HasColumnName("sip_aattainment8englishsecondarydisadeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8englishsecondarydisadla)
                    .HasColumnName("sip_aattainment8englishsecondarydisadla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8mathsscoresecondarydisadvanta)
                    .HasColumnName("sip_aattainment8mathsscoresecondarydisadvanta")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8mathssecondarydisadvantageden)
                    .HasColumnName("sip_aattainment8mathssecondarydisadvantageden")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8mathssecondarydisadvantagedla)
                    .HasColumnName("sip_aattainment8mathssecondarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scoreengland)
                    .HasColumnName("sip_aattainment8scoreengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scorela)
                    .HasColumnName("sip_aattainment8scorela")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scorelocalauthority)
                    .HasColumnName("sip_aattainment8scorelocalauthority")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scoresecondary)
                    .HasColumnName("sip_aattainment8scoresecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scoresecondarydisadvantag)
                    .HasColumnName("sip_aattainment8scoresecondarydisadvantag")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scoresecondarydisadvantaged)
                    .HasColumnName("sip_aattainment8scoresecondarydisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scoresecondarydisadvantageden)
                    .HasColumnName("sip_aattainment8scoresecondarydisadvantageden")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAattainment8scoresecondarydisadvantagedla)
                    .HasColumnName("sip_aattainment8scoresecondarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAcademiceligiblepupils).HasColumnName("sip_academiceligiblepupils");

                entity.Property(e => e.SipAcademiclevelaveragepspe)
                    .HasColumnName("sip_academiclevelaveragepspe")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebacc4cdisadvantagetrustla)
                    .HasColumnName("sip_achievingebacc4cdisadvantagetrustla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebacc5cdisadvantagedtrustla)
                    .HasColumnName("sip_achievingebacc5cdisadvantagedtrustla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4corabove)
                    .HasColumnName("sip_achievingebaccatgrade4corabove")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4coraboveboys)
                    .HasColumnName("sip_achievingebaccatgrade4coraboveboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4coraboveeal)
                    .HasColumnName("sip_achievingebaccatgrade4coraboveeal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4coraboveengland)
                    .HasColumnName("sip_achievingebaccatgrade4coraboveengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4corabovegirls)
                    .HasColumnName("sip_achievingebaccatgrade4corabovegirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4corabovela)
                    .HasColumnName("sip_achievingebaccatgrade4corabovela")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4corabovenotdisadv)
                    .HasColumnName("sip_achievingebaccatgrade4corabovenotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade4corabovetrust)
                    .HasColumnName("sip_achievingebaccatgrade4corabovetrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5corabove)
                    .HasColumnName("sip_achievingebaccatgrade5corabove")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5coraboveboys)
                    .HasColumnName("sip_achievingebaccatgrade5coraboveboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5coraboveeal)
                    .HasColumnName("sip_achievingebaccatgrade5coraboveeal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5coraboveengland)
                    .HasColumnName("sip_achievingebaccatgrade5coraboveengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5corabovegirls)
                    .HasColumnName("sip_achievingebaccatgrade5corabovegirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5corabovela)
                    .HasColumnName("sip_achievingebaccatgrade5corabovela")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5corabovenotdisadv)
                    .HasColumnName("sip_achievingebaccatgrade5corabovenotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5coraboveschool)
                    .HasColumnName("sip_achievingebaccatgrade5coraboveschool")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccatgrade5corabovetrust)
                    .HasColumnName("sip_achievingebaccatgrade5corabovetrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccgrade4corabovedisadvantaged)
                    .HasColumnName("sip_achievingebaccgrade4corabovedisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAchievingebaccgrade5corabovedisadvantaged)
                    .HasColumnName("sip_achievingebaccgrade5corabovedisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscoredisadvantaged)
                    .HasColumnName("sip_aebaccaveragepointscoredisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscoredisadvantagedengl)
                    .HasColumnName("sip_aebaccaveragepointscoredisadvantagedengl")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscoredisadvantagedla)
                    .HasColumnName("sip_aebaccaveragepointscoredisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscoreenglandaverage)
                    .HasColumnName("sip_aebaccaveragepointscoreenglandaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscorelaaverage)
                    .HasColumnName("sip_aebaccaveragepointscorelaaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscorelocalauthaverage)
                    .HasColumnName("sip_aebaccaveragepointscorelocalauthaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAebaccaveragepointscoresecondary)
                    .HasColumnName("sip_aebaccaveragepointscoresecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4cabovedisadvantaged)
                    .HasColumnName("sip_aenglishmathsgrade4cabovedisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4cabovedisadvantageden)
                    .HasColumnName("sip_aenglishmathsgrade4cabovedisadvantageden")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4cabovedisadvantagedla)
                    .HasColumnName("sip_aenglishmathsgrade4cabovedisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4coraboveengland)
                    .HasColumnName("sip_aenglishmathsgrade4coraboveengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4corabovela)
                    .HasColumnName("sip_aenglishmathsgrade4corabovela")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4corabovelocalauth)
                    .HasColumnName("sip_aenglishmathsgrade4corabovelocalauth")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade4corabovesecondary)
                    .HasColumnName("sip_aenglishmathsgrade4corabovesecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade5orabovedisadeng)
                    .HasColumnName("sip_aenglishmathsgrade5orabovedisadeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade5orabovedisadla)
                    .HasColumnName("sip_aenglishmathsgrade5orabovedisadla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenglishmathsgrade5orabovedisadvantaged)
                    .HasColumnName("sip_aenglishmathsgrade5orabovedisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebaccenglandaverage)
                    .HasColumnName("sip_aenteringebaccenglandaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebacclaaverage)
                    .HasColumnName("sip_aenteringebacclaaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebacclocalauthorityaverage)
                    .HasColumnName("sip_aenteringebacclocalauthorityaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebaccsecondary)
                    .HasColumnName("sip_aenteringebaccsecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebaccsecondarydisadvantaged)
                    .HasColumnName("sip_aenteringebaccsecondarydisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebaccsecondarydisadvantagedengl)
                    .HasColumnName("sip_aenteringebaccsecondarydisadvantagedengl")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAenteringebaccsecondarydisadvantagedla)
                    .HasColumnName("sip_aenteringebaccsecondarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAgrade5orabovemathandenglishengland)
                    .HasColumnName("sip_agrade5orabovemathandenglishengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAgrade5orabovemathandenglishla)
                    .HasColumnName("sip_agrade5orabovemathandenglishla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAgrade5orabovemathandenglishsecondary)
                    .HasColumnName("sip_agrade5orabovemathandenglishsecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAgrade5orabovemathsandenglishlocalauth)
                    .HasColumnName("sip_agrade5orabovemathsandenglishlocalauth")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentry)
                    .HasColumnName("sip_aks5apsperentry")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentryacademic)
                    .HasColumnName("sip_aks5apsperentryacademic")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentryacademiceng)
                    .HasColumnName("sip_aks5apsperentryacademiceng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentryacademicla)
                    .HasColumnName("sip_aks5apsperentryacademicla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentryappliedgeneral)
                    .HasColumnName("sip_aks5apsperentryappliedgeneral")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentryappliedgeneraleng)
                    .HasColumnName("sip_aks5apsperentryappliedgeneraleng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5apsperentryappliedgeneralla)
                    .HasColumnName("sip_aks5apsperentryappliedgeneralla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5valueaddedacademic)
                    .HasColumnName("sip_aks5valueaddedacademic")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5valueaddedacademiceng)
                    .HasColumnName("sip_aks5valueaddedacademiceng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5valueaddedacademicla)
                    .HasColumnName("sip_aks5valueaddedacademicla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5valueaddedappliedgeneral)
                    .HasColumnName("sip_aks5valueaddedappliedgeneral")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5valueaddedappliedgeneraleng)
                    .HasColumnName("sip_aks5valueaddedappliedgeneraleng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAks5valueaddedappliedgeneralla)
                    .HasColumnName("sip_aks5valueaddedappliedgeneralla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAlevelaveragepspe)
                    .HasColumnName("sip_alevelaveragepspe")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAleveleligiblepupils).HasColumnName("sip_aleveleligiblepupils");

                entity.Property(e => e.SipAlphaind)
                    .HasColumnName("sip_alphaind")
                    .HasMaxLength(100);

                entity.Property(e => e.SipAmathsscoreprimary)
                    .HasColumnName("sip_amathsscoreprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmathsscoreprimarycategory).HasColumnName("sip_amathsscoreprimarycategory");

                entity.Property(e => e.SipAmathsscoreprimarydisadvantaged)
                    .HasColumnName("sip_amathsscoreprimarydisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmathsscoreprimarydisadvantagedengland)
                    .HasColumnName("sip_amathsscoreprimarydisadvantagedengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmathsscoreprimarydisadvantagedla)
                    .HasColumnName("sip_amathsscoreprimarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmathsscoreprimaryengland)
                    .HasColumnName("sip_amathsscoreprimaryengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmathsscoreprimaryla)
                    .HasColumnName("sip_amathsscoreprimaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetingexpectedstandardinrwmdisadvprimar)
                    .HasColumnName("sip_ameetingexpectedstandardinrwmdisadvprimar")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetingexpectedstandardinrwmprimary)
                    .HasColumnName("sip_ameetingexpectedstandardinrwmprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetingexpectedstandardinrwmprimaryeng)
                    .HasColumnName("sip_ameetingexpectedstandardinrwmprimaryeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetingexpectedstandardinrwmprimaryla)
                    .HasColumnName("sip_ameetingexpectedstandardinrwmprimaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetingexpectedstdrwmdisadvantagedprimen)
                    .HasColumnName("sip_ameetingexpectedstdrwmdisadvantagedprimen")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetingexpectedstdrwmdisadvantagedprimla)
                    .HasColumnName("sip_ameetingexpectedstdrwmdisadvantagedprimla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstandardinrwmprimary)
                    .HasColumnName("sip_ameetinghigherstandardinrwmprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstandardinrwmprimaryeng)
                    .HasColumnName("sip_ameetinghigherstandardinrwmprimaryeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstdinrwmprimareng)
                    .HasColumnName("sip_ameetinghigherstdinrwmprimareng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstdinrwmprimarla)
                    .HasColumnName("sip_ameetinghigherstdinrwmprimarla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstdrwmdisadvantagedprimary)
                    .HasColumnName("sip_ameetinghigherstdrwmdisadvantagedprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstdrwmdisadvantagedprimeng)
                    .HasColumnName("sip_ameetinghigherstdrwmdisadvantagedprimeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAmeetinghigherstdrwmdisadvantagedprimla)
                    .HasColumnName("sip_ameetinghigherstdrwmdisadvantagedprimla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAnumberofdisadvantagedpupilsinprogress8)
                    .HasColumnName("sip_anumberofdisadvantagedpupilsinprogress8")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAnumberofdisadvantagedpupilsinprogress8en)
                    .HasColumnName("sip_anumberofdisadvantagedpupilsinprogress8en")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAnumberofdisadvantagedpupilsinprogress8la)
                    .HasColumnName("sip_anumberofdisadvantagedpupilsinprogress8la")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAppliedeligiblepupils).HasColumnName("sip_appliedeligiblepupils");

                entity.Property(e => e.SipAppliedgeneralaveragepspe)
                    .HasColumnName("sip_appliedgeneralaveragepspe")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8highercidisadvantaged)
                    .HasColumnName("sip_aprogress8highercidisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8highercidisadvantagedeng)
                    .HasColumnName("sip_aprogress8highercidisadvantagedeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8highercidisadvantagedla)
                    .HasColumnName("sip_aprogress8highercidisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8lowercidisadvantaged)
                    .HasColumnName("sip_aprogress8lowercidisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8lowercidisadvantagedengland)
                    .HasColumnName("sip_aprogress8lowercidisadvantagedengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8lowercidisadvantagedla)
                    .HasColumnName("sip_aprogress8lowercidisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scorecategorysecondary).HasColumnName("sip_aprogress8scorecategorysecondary");

                entity.Property(e => e.SipAprogress8scoredisadvantagedsecondary)
                    .HasColumnName("sip_aprogress8scoredisadvantagedsecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoredisadvantagedsecondaryeng)
                    .HasColumnName("sip_aprogress8scoredisadvantagedsecondaryeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoredisadvantagedsecondaryla)
                    .HasColumnName("sip_aprogress8scoredisadvantagedsecondaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreebacc)
                    .HasColumnName("sip_aprogress8scoreebacc")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreebaccdisadvantaged)
                    .HasColumnName("sip_aprogress8scoreebaccdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreebaccdisadvantagedengland)
                    .HasColumnName("sip_aprogress8scoreebaccdisadvantagedengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreebaccdisadvantagedla)
                    .HasColumnName("sip_aprogress8scoreebaccdisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreebaccengland)
                    .HasColumnName("sip_aprogress8scoreebaccengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreebaccla)
                    .HasColumnName("sip_aprogress8scoreebaccla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreenglish)
                    .HasColumnName("sip_aprogress8scoreenglish")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreenglishdisadvantaged)
                    .HasColumnName("sip_aprogress8scoreenglishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreenglishdisadvantagedeng)
                    .HasColumnName("sip_aprogress8scoreenglishdisadvantagedeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreenglishdisadvantagedla)
                    .HasColumnName("sip_aprogress8scoreenglishdisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreenglisheng)
                    .HasColumnName("sip_aprogress8scoreenglisheng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoreenglishla)
                    .HasColumnName("sip_aprogress8scoreenglishla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoremaths)
                    .HasColumnName("sip_aprogress8scoremaths")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoremathsdisadvantaged)
                    .HasColumnName("sip_aprogress8scoremathsdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoremathsdisadvantagedeng)
                    .HasColumnName("sip_aprogress8scoremathsdisadvantagedeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoremathsdisadvantagedla)
                    .HasColumnName("sip_aprogress8scoremathsdisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoremathsengland)
                    .HasColumnName("sip_aprogress8scoremathsengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoremathsla)
                    .HasColumnName("sip_aprogress8scoremathsla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAprogress8scoresecondary)
                    .HasColumnName("sip_aprogress8scoresecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAreadingscoreprimary)
                    .HasColumnName("sip_areadingscoreprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAreadingscoreprimarycategory).HasColumnName("sip_areadingscoreprimarycategory");

                entity.Property(e => e.SipAreadingscoreprimarydisadvantaged)
                    .HasColumnName("sip_areadingscoreprimarydisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAreadingscoreprimarydisadvantagedengand)
                    .HasColumnName("sip_areadingscoreprimarydisadvantagedengand")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAreadingscoreprimarydisadvantagedla)
                    .HasColumnName("sip_areadingscoreprimarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAreadingscoreprimaryengland)
                    .HasColumnName("sip_areadingscoreprimaryengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAreadingscoreprimaryla)
                    .HasColumnName("sip_areadingscoreprimaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAstayingineducationemploymentlocalaut)
                    .HasColumnName("sip_astayingineducationemploymentlocalaut")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAstayingineducationoremploymentengland)
                    .HasColumnName("sip_astayingineducationoremploymentengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAstayingineducationoremploymentsecondary)
                    .HasColumnName("sip_astayingineducationoremploymentsecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8score)
                    .HasColumnName("sip_attainment8score")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreboys)
                    .HasColumnName("sip_attainment8scoreboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoredisadvantaged)
                    .HasColumnName("sip_attainment8scoredisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreeal)
                    .HasColumnName("sip_attainment8scoreeal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreebacc)
                    .HasColumnName("sip_attainment8scoreebacc")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreebaccdisadvantaged)
                    .HasColumnName("sip_attainment8scoreebaccdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreenglish)
                    .HasColumnName("sip_attainment8scoreenglish")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoreenglishdisadvantaged)
                    .HasColumnName("sip_attainment8scoreenglishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoregirls)
                    .HasColumnName("sip_attainment8scoregirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoremaths)
                    .HasColumnName("sip_attainment8scoremaths")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scoremathsdisadvantaged)
                    .HasColumnName("sip_attainment8scoremathsdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAttainment8scorenotdisadvantaged)
                    .HasColumnName("sip_attainment8scorenotdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAveragepointscoreks2)
                    .HasColumnName("sip_averagepointscoreks2")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAwritingscoreprimary)
                    .HasColumnName("sip_awritingscoreprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAwritingscoreprimarycategory).HasColumnName("sip_awritingscoreprimarycategory");

                entity.Property(e => e.SipAwritingscoreprimarydisadvantaged)
                    .HasColumnName("sip_awritingscoreprimarydisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAwritingscoreprimarydisadvantagedengland)
                    .HasColumnName("sip_awritingscoreprimarydisadvantagedengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAwritingscoreprimarydisadvantagedla)
                    .HasColumnName("sip_awritingscoreprimarydisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAwritingscoreprimaryengland)
                    .HasColumnName("sip_awritingscoreprimaryengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipAwritingscoreprimaryla)
                    .HasColumnName("sip_awritingscoreprimaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipContainsacademyprimarydata).HasColumnName("sip_containsacademyprimarydata");

                entity.Property(e => e.SipContainsacademysecondarydata).HasColumnName("sip_containsacademysecondarydata");

                entity.Property(e => e.SipContainsks5data).HasColumnName("sip_containsks5data");

                entity.Property(e => e.SipContainsprimarydata).HasColumnName("sip_containsprimarydata");

                entity.Property(e => e.SipContainssecondarydata).HasColumnName("sip_containssecondarydata");

                entity.Property(e => e.SipDisadvantagedpupilsengland)
                    .HasColumnName("sip_disadvantagedpupilsengland")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipDisadvantagedpupilsla)
                    .HasColumnName("sip_disadvantagedpupilsla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipDisadvantagedpupilsprimarypercentage)
                    .HasColumnName("sip_disadvantagedpupilsprimarypercentage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipDisadvantagedpupilssecondary)
                    .HasColumnName("sip_disadvantagedpupilssecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipDisadvantagedpupilssecondaryengland)
                    .HasColumnName("sip_disadvantagedpupilssecondaryengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipDisadvantagedpupilssecondaryla)
                    .HasColumnName("sip_disadvantagedpupilssecondaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipDisadvantagedpupilssecondarytrust)
                    .HasColumnName("sip_disadvantagedpupilssecondarytrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipDisadvantagedpupilstrust)
                    .HasColumnName("sip_disadvantagedpupilstrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbacc4cdisadvantagedtrust)
                    .HasColumnName("sip_ebacc4cdisadvantagedtrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbacc4cdisadvantagedtrustengland)
                    .HasColumnName("sip_ebacc4cdisadvantagedtrustengland")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.SipEbacc5cdisadvantagedtrust)
                    .HasColumnName("sip_ebacc5cdisadvantagedtrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbacc5cdisadvantagedtrustengland)
                    .HasColumnName("sip_ebacc5cdisadvantagedtrustengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscore)
                    .HasColumnName("sip_ebaccaveragepointscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoreboys)
                    .HasColumnName("sip_ebaccaveragepointscoreboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoredisadvantaged)
                    .HasColumnName("sip_ebaccaveragepointscoredisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoredisadvantagedtrust)
                    .HasColumnName("sip_ebaccaveragepointscoredisadvantagedtrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoredisadvantagedtruste)
                    .HasColumnName("sip_ebaccaveragepointscoredisadvantagedtruste")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoredisadvantagedtrustl)
                    .HasColumnName("sip_ebaccaveragepointscoredisadvantagedtrustl")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoreeal)
                    .HasColumnName("sip_ebaccaveragepointscoreeal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoreengland)
                    .HasColumnName("sip_ebaccaveragepointscoreengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoreenglandaverage)
                    .HasColumnName("sip_ebaccaveragepointscoreenglandaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoregirls)
                    .HasColumnName("sip_ebaccaveragepointscoregirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscorelaaverage)
                    .HasColumnName("sip_ebaccaveragepointscorelaaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscorenotdisadv)
                    .HasColumnName("sip_ebaccaveragepointscorenotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccaveragepointscoretrust)
                    .HasColumnName("sip_ebaccaveragepointscoretrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccdisadvantagedsecondarytrust)
                    .HasColumnName("sip_ebaccdisadvantagedsecondarytrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccdisadvantagedsecondarytrustengland)
                    .HasColumnName("sip_ebaccdisadvantagedsecondarytrustengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEbaccdisadvantagedsecondarytrustla)
                    .HasColumnName("sip_ebaccdisadvantagedsecondarytrustla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEducationalperformancedataid).HasColumnName("sip_educationalperformancedataid");

                entity.Property(e => e.SipEligiblep8pupils).HasColumnName("sip_eligiblep8pupils");

                entity.Property(e => e.SipEligiblep8pupilsboys).HasColumnName("sip_eligiblep8pupilsboys");

                entity.Property(e => e.SipEligiblep8pupilsdisadv).HasColumnName("sip_eligiblep8pupilsdisadv");

                entity.Property(e => e.SipEligiblep8pupilseal).HasColumnName("sip_eligiblep8pupilseal");

                entity.Property(e => e.SipEligiblep8pupilsgirls).HasColumnName("sip_eligiblep8pupilsgirls");

                entity.Property(e => e.SipEligiblep8pupilsnotdisadvantaged).HasColumnName("sip_eligiblep8pupilsnotdisadvantaged");

                entity.Property(e => e.SipEligiblepupilsboysks2).HasColumnName("sip_eligiblepupilsboysks2");

                entity.Property(e => e.SipEligiblepupilsboysks4).HasColumnName("sip_eligiblepupilsboysks4");

                entity.Property(e => e.SipEligiblepupilsdisadvks2).HasColumnName("sip_eligiblepupilsdisadvks2");

                entity.Property(e => e.SipEligiblepupilsdisadvks4).HasColumnName("sip_eligiblepupilsdisadvks4");

                entity.Property(e => e.SipEligiblepupilsealks2).HasColumnName("sip_eligiblepupilsealks2");

                entity.Property(e => e.SipEligiblepupilsealks4).HasColumnName("sip_eligiblepupilsealks4");

                entity.Property(e => e.SipEligiblepupilsgirlsks2).HasColumnName("sip_eligiblepupilsgirlsks2");

                entity.Property(e => e.SipEligiblepupilsgirlsks4)
                    .HasColumnName("sip_eligiblepupilsgirlsks4")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEligiblepupilsks2).HasColumnName("sip_eligiblepupilsks2");

                entity.Property(e => e.SipEligiblepupilsks4).HasColumnName("sip_eligiblepupilsks4");

                entity.Property(e => e.SipEligiblepupilsnotdisadvks2).HasColumnName("sip_eligiblepupilsnotdisadvks2");

                entity.Property(e => e.SipEligiblepupilsnotdisadvks4).HasColumnName("sip_eligiblepupilsnotdisadvks4");

                entity.Property(e => e.SipEnglishadditionallangsecondarytrusteng)
                    .HasColumnName("sip_englishadditionallangsecondarytrusteng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishadditionallangsecondarytrustla)
                    .HasColumnName("sip_englishadditionallangsecondarytrustla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishadditionallanguageprimary)
                    .HasColumnName("sip_englishadditionallanguageprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishadditionallanguagesecondary)
                    .HasColumnName("sip_englishadditionallanguagesecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishadditionallanguagesecondaryeng)
                    .HasColumnName("sip_englishadditionallanguagesecondaryeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishadditionallanguagesecondarytrust)
                    .HasColumnName("sip_englishadditionallanguagesecondarytrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishasadditionallanguagepupilsengland)
                    .HasColumnName("sip_englishasadditionallanguagepupilsengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishasadditionallanguagepupilsla)
                    .HasColumnName("sip_englishasadditionallanguagepupilsla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnglishasanadditionallanguagepupils)
                    .HasColumnName("sip_englishasanadditionallanguagepupils")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteredachievingebacchumanitiesgrade4abov)
                    .HasColumnName("sip_enteredachievingebacchumanitiesgrade4abov")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteredachievingebacchumanitiesgrade5abov)
                    .HasColumnName("sip_enteredachievingebacchumanitiesgrade5abov")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteredachievingebacclanguagegrade4above)
                    .HasColumnName("sip_enteredachievingebacclanguagegrade4above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteredachievingebacclanguagegrade5above)
                    .HasColumnName("sip_enteredachievingebacclanguagegrade5above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteredachievingebaccsciencegrade4above)
                    .HasColumnName("sip_enteredachievingebaccsciencegrade4above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteredachievingebaccsciencegrade5above)
                    .HasColumnName("sip_enteredachievingebaccsciencegrade5above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebacc)
                    .HasColumnName("sip_enteringebacc")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccboys)
                    .HasColumnName("sip_enteringebaccboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccdisadvantaged)
                    .HasColumnName("sip_enteringebaccdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebacceal)
                    .HasColumnName("sip_enteringebacceal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccengland)
                    .HasColumnName("sip_enteringebaccengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccenglandaverage)
                    .HasColumnName("sip_enteringebaccenglandaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccgirls)
                    .HasColumnName("sip_enteringebaccgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebacclaaverage)
                    .HasColumnName("sip_enteringebacclaaverage")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccnotdisadv)
                    .HasColumnName("sip_enteringebaccnotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEnteringebaccschool)
                    .HasColumnName("sip_enteringebaccschool")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipEstablishmenttypeidname)
                    .HasColumnName("sip_establishmenttypeidname")
                    .HasMaxLength(100);

                entity.Property(e => e.SipGrade4oraboveenglishmathsboys)
                    .HasColumnName("sip_grade4oraboveenglishmathsboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade4oraboveenglishmathseal)
                    .HasColumnName("sip_grade4oraboveenglishmathseal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade4oraboveenglishmathsgirls)
                    .HasColumnName("sip_grade4oraboveenglishmathsgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade4oraboveenglishmathsnotdisadv)
                    .HasColumnName("sip_grade4oraboveenglishmathsnotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade4orabovemathandenglish)
                    .HasColumnName("sip_grade4orabovemathandenglish")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade4orabovemathandenglishdisadvantaged)
                    .HasColumnName("sip_grade4orabovemathandenglishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade5oraboveenglishmathsboys)
                    .HasColumnName("sip_grade5oraboveenglishmathsboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade5oraboveenglishmathseal)
                    .HasColumnName("sip_grade5oraboveenglishmathseal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade5oraboveenglishmathsgirls)
                    .HasColumnName("sip_grade5oraboveenglishmathsgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade5oraboveenglishmathsnotdisadv)
                    .HasColumnName("sip_grade5oraboveenglishmathsnotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade5orabovemathandenglish)
                    .HasColumnName("sip_grade5orabovemathandenglish")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipGrade5orabovemathandenglishdisadvantaged)
                    .HasColumnName("sip_grade5orabovemathandenglishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKeystage1averagepointscoreonentryengland)
                    .HasColumnName("sip_keystage1averagepointscoreonentryengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKeystage1averagepointscoreonentryla)
                    .HasColumnName("sip_keystage1averagepointscoreonentryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKeystage1averagepointscoreonentrytrust)
                    .HasColumnName("sip_keystage1averagepointscoreonentrytrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKeystage2averagepointscoreonentryengland)
                    .HasColumnName("sip_keystage2averagepointscoreonentryengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKeystage2averagepointscoreonentryla)
                    .HasColumnName("sip_keystage2averagepointscoreonentryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKeystage2averagepointscoreonentrytrust)
                    .HasColumnName("sip_keystage2averagepointscoreonentrytrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipKs1averagepointscore)
                    .HasColumnName("sip_ks1averagepointscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipLocalauthority).HasColumnName("sip_localauthority");

                entity.Property(e => e.SipLocalauthorityEntitytype)
                    .HasColumnName("sip_localauthority_entitytype")
                    .HasMaxLength(128);

                entity.Property(e => e.SipLocalauthoritycode)
                    .HasColumnName("sip_localauthoritycode")
                    .HasMaxLength(100);

                entity.Property(e => e.SipLocalauthorityname)
                    .HasColumnName("sip_localauthorityname")
                    .HasMaxLength(100);

                entity.Property(e => e.SipMathsprogressboys)
                    .HasColumnName("sip_mathsprogressboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogresseal)
                    .HasColumnName("sip_mathsprogresseal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogressgirls)
                    .HasColumnName("sip_mathsprogressgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogressscore)
                    .HasColumnName("sip_mathsprogressscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogressscorecategory).HasColumnName("sip_mathsprogressscorecategory");

                entity.Property(e => e.SipMathsprogressscoredisadv)
                    .HasColumnName("sip_mathsprogressscoredisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogressscoredisadvantagedengland)
                    .HasColumnName("sip_mathsprogressscoredisadvantagedengland")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipMathsprogressscoredisadvantagedla)
                    .HasColumnName("sip_mathsprogressscoredisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMathsprogressscoredisadvantagedtrust)
                    .HasColumnName("sip_mathsprogressscoredisadvantagedtrust")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipMathsprogressscorenotdisadv)
                    .HasColumnName("sip_mathsprogressscorenotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMatmathsprogressscorecategory).HasColumnName("sip_matmathsprogressscorecategory");

                entity.Property(e => e.SipMatmathsprogressscorenumber)
                    .HasColumnName("sip_matmathsprogressscorenumber")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMatprogress8scorecat).HasColumnName("sip_matprogress8scorecat");

                entity.Property(e => e.SipMatprogress8scorenumber)
                    .HasColumnName("sip_matprogress8scorenumber")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMatreadingprogressscorecategory).HasColumnName("sip_matreadingprogressscorecategory");

                entity.Property(e => e.SipMatreadingprogressscorenumber)
                    .HasColumnName("sip_matreadingprogressscorenumber")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMatwritingprogressscorecategory).HasColumnName("sip_matwritingprogressscorecategory");

                entity.Property(e => e.SipMatwritingscorenumber)
                    .HasColumnName("sip_matwritingscorenumber")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinmaths)
                    .HasColumnName("sip_meetingexpectedstandardinmaths")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinmathsdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinmathsdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinmathsnotdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinmathsnotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinreading)
                    .HasColumnName("sip_meetingexpectedstandardinreading")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinreadingdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinreadingdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinreadingnotdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinreadingnotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinrwm)
                    .HasColumnName("sip_meetingexpectedstandardinrwm")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinrwmboys)
                    .HasColumnName("sip_meetingexpectedstandardinrwmboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinrwmdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinrwmdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinrwmeal)
                    .HasColumnName("sip_meetingexpectedstandardinrwmeal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinrwmgirls)
                    .HasColumnName("sip_meetingexpectedstandardinrwmgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinrwmnotdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinrwmnotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinwriting)
                    .HasColumnName("sip_meetingexpectedstandardinwriting")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinwritingdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinwritingdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipMeetingexpectedstandardinwritingnotdisadv)
                    .HasColumnName("sip_meetingexpectedstandardinwritingnotdisadv")
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

                entity.Property(e => e.SipNationalcategory).HasColumnName("sip_nationalcategory");

                entity.Property(e => e.SipNumberconverteracademiesprimary).HasColumnName("sip_numberconverteracademiesprimary");

                entity.Property(e => e.SipNumberofconverteracademies).HasColumnName("sip_numberofconverteracademies");

                entity.Property(e => e.SipNumberofconverteracademiesks4).HasColumnName("sip_numberofconverteracademiesks4");

                entity.Property(e => e.SipNumberofconverteracademiessecondary).HasColumnName("sip_numberofconverteracademiessecondary");

                entity.Property(e => e.SipNumberoffreeschoolsks2).HasColumnName("sip_numberoffreeschoolsks2");

                entity.Property(e => e.SipNumberoffreeschoolsks4).HasColumnName("sip_numberoffreeschoolsks4");

                entity.Property(e => e.SipNumberoffreeschoolsprimary).HasColumnName("sip_numberoffreeschoolsprimary");

                entity.Property(e => e.SipNumberoffreeschoolssecondary).HasColumnName("sip_numberoffreeschoolssecondary");

                entity.Property(e => e.SipNumberofpupilsprogress8).HasColumnName("sip_numberofpupilsprogress8");

                entity.Property(e => e.SipNumberofpupilsprogress8disadvantaged).HasColumnName("sip_numberofpupilsprogress8disadvantaged");

                entity.Property(e => e.SipNumberofschoolsinmat3years).HasColumnName("sip_numberofschoolsinmat3years");

                entity.Property(e => e.SipNumberofschoolsinmat3yearsprimary).HasColumnName("sip_numberofschoolsinmat3yearsprimary");

                entity.Property(e => e.SipNumberofschoolsinmat4years).HasColumnName("sip_numberofschoolsinmat4years");

                entity.Property(e => e.SipNumberofschoolsinmat4yearsprimary).HasColumnName("sip_numberofschoolsinmat4yearsprimary");

                entity.Property(e => e.SipNumberofsecondaryschoolsinmat3years).HasColumnName("sip_numberofsecondaryschoolsinmat3years");

                entity.Property(e => e.SipNumberofsecondaryschoolsinmat4years).HasColumnName("sip_numberofsecondaryschoolsinmat4years");

                entity.Property(e => e.SipNumberofsecondaryschoolsinmat5years).HasColumnName("sip_numberofsecondaryschoolsinmat5years");

                entity.Property(e => e.SipNumberofsponsoracademiesks4).HasColumnName("sip_numberofsponsoracademiesks4");

                entity.Property(e => e.SipNumberofsponsoredacademies).HasColumnName("sip_numberofsponsoredacademies");

                entity.Property(e => e.SipNumberofsponsoredacademiesks4).HasColumnName("sip_numberofsponsoredacademiesks4");

                entity.Property(e => e.SipNumberofsponsoredacademiesprimary).HasColumnName("sip_numberofsponsoredacademiesprimary");

                entity.Property(e => e.SipNumberofsponsoredacademiessecondary).HasColumnName("sip_numberofsponsoredacademiessecondary");

                entity.Property(e => e.SipOfpupilsachievingebaccenglishgrade4above)
                    .HasColumnName("sip_ofpupilsachievingebaccenglishgrade4above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipOfpupilsachievingebaccenglishgrade5above)
                    .HasColumnName("sip_ofpupilsachievingebaccenglishgrade5above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipOfpupilsachievingebaccmathsgrade4above)
                    .HasColumnName("sip_ofpupilsachievingebaccmathsgrade4above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipOfpupilsachievingebaccmathsgrade5above)
                    .HasColumnName("sip_ofpupilsachievingebaccmathsgrade5above")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipOfpupilsenteringtheebacclanguagesubject)
                    .HasColumnName("sip_ofpupilsenteringtheebacclanguagesubject")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipOfpupilsinkeystage4includedinprogress8)
                    .HasColumnName("sip_ofpupilsinkeystage4includedinprogress8")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipParentaccountid).HasColumnName("sip_parentaccountid");

                entity.Property(e => e.SipParentaccountidEntitytype)
                    .HasColumnName("sip_parentaccountid_entitytype")
                    .HasMaxLength(128);

                entity.Property(e => e.SipParentaccountidname)
                    .HasColumnName("sip_parentaccountidname")
                    .HasMaxLength(160);

                entity.Property(e => e.SipParentaccountidyominame)
                    .HasColumnName("sip_parentaccountidyominame")
                    .HasMaxLength(160);

                entity.Property(e => e.SipPercentageofenrolmentswhoarepersistentabs)
                    .HasColumnName("sip_percentageofenrolmentswhoarepersistentabs")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipPercentageofoverallabsence)
                    .HasColumnName("sip_percentageofoverallabsence")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipPerformancetype).HasColumnName("sip_performancetype");

                entity.Property(e => e.SipPersistentabsentees)
                    .HasColumnName("sip_persistentabsentees")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8afteradjustmentforextremescores)
                    .HasColumnName("sip_progress8afteradjustmentforextremescores")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8disadvantagedschooltrust)
                    .HasColumnName("sip_progress8disadvantagedschooltrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8disadvantagedschooltrustengland)
                    .HasColumnName("sip_progress8disadvantagedschooltrustengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8disadvantagedschooltrustla)
                    .HasColumnName("sip_progress8disadvantagedschooltrustla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8ebacc)
                    .HasColumnName("sip_progress8ebacc")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8ebaccdisadvantaged)
                    .HasColumnName("sip_progress8ebaccdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8english)
                    .HasColumnName("sip_progress8english")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8englishdisadvantaged)
                    .HasColumnName("sip_progress8englishdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8lowerconfidence)
                    .HasColumnName("sip_progress8lowerconfidence")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8lowerconfidencedisadvantaged)
                    .HasColumnName("sip_progress8lowerconfidencedisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8maths)
                    .HasColumnName("sip_progress8maths")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8mathsdisadvantaged)
                    .HasColumnName("sip_progress8mathsdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8measureforenglishelementks4)
                    .HasColumnName("sip_progress8measureforenglishelementks4")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8onunadjustedpupilscoresks4)
                    .HasColumnName("sip_progress8onunadjustedpupilscoresks4")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8score)
                    .HasColumnName("sip_progress8score")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scoreboys)
                    .HasColumnName("sip_progress8scoreboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scorecategory).HasColumnName("sip_progress8scorecategory");

                entity.Property(e => e.SipProgress8scorecategoryschool).HasColumnName("sip_progress8scorecategoryschool");

                entity.Property(e => e.SipProgress8scoredisadvantaged)
                    .HasColumnName("sip_progress8scoredisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scoredisadvantagedsecondary)
                    .HasColumnName("sip_progress8scoredisadvantagedsecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scoreeal)
                    .HasColumnName("sip_progress8scoreeal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scoregirls)
                    .HasColumnName("sip_progress8scoregirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8scorenotdisadvantaged)
                    .HasColumnName("sip_progress8scorenotdisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8upperconfidence)
                    .HasColumnName("sip_progress8upperconfidence")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipProgress8upperconfidencedisadvantaged)
                    .HasColumnName("sip_progress8upperconfidencedisadvantaged")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipPupilssenprimary)
                    .HasColumnName("sip_pupilssenprimary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipPupilssensecondary)
                    .HasColumnName("sip_pupilssensecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressboys)
                    .HasColumnName("sip_readingprogressboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogresseal)
                    .HasColumnName("sip_readingprogresseal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressgirls)
                    .HasColumnName("sip_readingprogressgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressscore)
                    .HasColumnName("sip_readingprogressscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressscoredisadv)
                    .HasColumnName("sip_readingprogressscoredisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressscoredisadvantagedengland)
                    .HasColumnName("sip_readingprogressscoredisadvantagedengland")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipReadingprogressscoredisadvantagedla)
                    .HasColumnName("sip_readingprogressscoredisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogressscoredisadvantagedtrust)
                    .HasColumnName("sip_readingprogressscoredisadvantagedtrust")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipReadingprogressscorenotdisadv)
                    .HasColumnName("sip_readingprogressscorenotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipReadingprogrtessscorecategory).HasColumnName("sip_readingprogrtessscorecategory");

                entity.Property(e => e.SipReportingenddate)
                    .HasColumnName("sip_reportingenddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SipReportingstartdate)
                    .HasColumnName("sip_reportingstartdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SipSenpupilsstatementehcplantrustsecondary)
                    .HasColumnName("sip_senpupilsstatementehcplantrustsecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilsstatementehctrustsecondaryeng)
                    .HasColumnName("sip_senpupilsstatementehctrustsecondaryeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilsstatementehctrustsecondaryla)
                    .HasColumnName("sip_senpupilsstatementehctrustsecondaryla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilswithstatementorehcplanengland)
                    .HasColumnName("sip_senpupilswithstatementorehcplanengland")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilswithstatementorehcplanla)
                    .HasColumnName("sip_senpupilswithstatementorehcplanla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilswithstatementorehcplansecondary)
                    .HasColumnName("sip_senpupilswithstatementorehcplansecondary")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilswithstatementorehcplantrust)
                    .HasColumnName("sip_senpupilswithstatementorehcplantrust")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipSenpupilswithsttmntorehcplansecondaryeng)
                    .HasColumnName("sip_senpupilswithsttmntorehcplansecondaryeng")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipTechlevelaveragepspe)
                    .HasColumnName("sip_techlevelaveragepspe")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipTechleveleligiblepupils).HasColumnName("sip_techleveleligiblepupils");

                entity.Property(e => e.SipTotalschoolsintrust).HasColumnName("sip_totalschoolsintrust");

                entity.Property(e => e.SipTotalschoolsintrustks4).HasColumnName("sip_totalschoolsintrustks4");

                entity.Property(e => e.SipTotalschoolssecondary).HasColumnName("sip_totalschoolssecondary");

                entity.Property(e => e.SipTotalschoolssecondaryother).HasColumnName("sip_totalschoolssecondaryother");

                entity.Property(e => e.SipTrustparentestablishment).HasColumnName("sip_trustparentestablishment");

                entity.Property(e => e.SipTrustparentestablishmentEntitytype)
                    .HasColumnName("sip_trustparentestablishment_entitytype")
                    .HasMaxLength(128);

                entity.Property(e => e.SipTrustparentestablishmentname)
                    .HasColumnName("sip_trustparentestablishmentname")
                    .HasMaxLength(160);

                entity.Property(e => e.SipTrustparentestablishmentyominame)
                    .HasColumnName("sip_trustparentestablishmentyominame")
                    .HasMaxLength(160);

                entity.Property(e => e.SipTypesofschoolcontrol)
                    .HasColumnName("sip_typesofschoolcontrol")
                    .HasMaxLength(100);

                entity.Property(e => e.SipWritingprogressboys)
                    .HasColumnName("sip_writingprogressboys")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogresseal)
                    .HasColumnName("sip_writingprogresseal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressgirls)
                    .HasColumnName("sip_writingprogressgirls")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressscore)
                    .HasColumnName("sip_writingprogressscore")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressscoredisadv)
                    .HasColumnName("sip_writingprogressscoredisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressscoredisadvantagedengland)
                    .HasColumnName("sip_writingprogressscoredisadvantagedengland")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipWritingprogressscoredisadvantagedla)
                    .HasColumnName("sip_writingprogressscoredisadvantagedla")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogressscoredisadvantagedtrust)
                    .HasColumnName("sip_writingprogressscoredisadvantagedtrust")
                    .HasColumnType("decimal(38, 1)");

                entity.Property(e => e.SipWritingprogressscorenotdisadv)
                    .HasColumnName("sip_writingprogressscorenotdisadv")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SipWritingprogrtessscorecategory).HasColumnName("sip_writingprogrtessscorecategory");

                entity.Property(e => e.Statecode).HasColumnName("statecode");

                entity.Property(e => e.Statuscode).HasColumnName("statuscode");

                entity.Property(e => e.Timezoneruleversionnumber).HasColumnName("timezoneruleversionnumber");

                entity.Property(e => e.Utcconversiontimezonecode).HasColumnName("utcconversiontimezonecode");
            });
        }
    }
}
