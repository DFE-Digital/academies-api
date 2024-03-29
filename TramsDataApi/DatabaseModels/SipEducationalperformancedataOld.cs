﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class SipEducationalperformancedataOld
    {
        public Guid Id { get; set; }
        public DateTime? SinkCreatedOn { get; set; }
        public DateTime? SinkModifiedOn { get; set; }
        public int? Statecode { get; set; }
        public int? Statuscode { get; set; }
        public int? SipMatmathsprogressscorecategory { get; set; }
        public int? SipMatwritingprogressscorecategory { get; set; }
        public int? SipAmathsscoreprimarycategory { get; set; }
        public int? SipAreadingscoreprimarycategory { get; set; }
        public int? SipProgress8scorecategoryschool { get; set; }
        public int? SipAwritingscoreprimarycategory { get; set; }
        public int? SipMatprogress8scorecat { get; set; }
        public int? SipMatreadingprogressscorecategory { get; set; }
        public int? SipAprogress8scorecategorysecondary { get; set; }
        public Guid? SipParentaccountid { get; set; }
        public string SipParentaccountidEntitytype { get; set; }
        public decimal? SipAmathsscoreprimarydisadvantagedengland { get; set; }
        public decimal? SipSenpupilswithstatementorehcplansecondary { get; set; }
        public decimal? SipEbaccaveragepointscoreenglandaverage { get; set; }
        public int? SipTotalschoolssecondary { get; set; }
        public decimal? SipAebaccaveragepointscoreenglandaverage { get; set; }
        public decimal? SipEbacc4cdisadvantagedtrustengland { get; set; }
        public decimal? SipAmeetinghigherstdrwmdisadvantagedprimeng { get; set; }
        public decimal? SipSenpupilswithsttmntorehcplansecondaryeng { get; set; }
        public decimal? SipEnglishasanadditionallanguagepupils { get; set; }
        public int? SipNumberofsecondaryschoolsinmat3years { get; set; }
        public decimal? SipEbaccdisadvantagedsecondarytrust { get; set; }
        public decimal? SipAchievingebaccatgrade4coraboveengland { get; set; }
        public decimal? SipEnteringebacc { get; set; }
        public decimal? SipAattainment8scoresecondarydisadvantaged { get; set; }
        public decimal? SipAachievingebaccatgrade4coraboveengland { get; set; }
        public decimal? SipEnteringebaccschool { get; set; }
        public decimal? SipEnteredachievingebacclanguagegrade5above { get; set; }
        public string SipTypesofschoolcontrol { get; set; }
        public decimal? SipEbacc5cdisadvantagedtrustengland { get; set; }
        public decimal? SipAwritingscoreprimarydisadvantagedengland { get; set; }
        public decimal? SipAattainment8scoreengland { get; set; }
        public decimal? SipAebaccaveragepointscorelocalauthaverage { get; set; }
        public decimal? SipOfpupilsenteringtheebacclanguagesubject { get; set; }
        public decimal? SipAmeetinghigherstdinrwmprimareng { get; set; }
        public decimal? SipEnteringebaccenglandaverage { get; set; }
        public int? SipTotalschoolsintrust { get; set; }
        public decimal? SipAmathsscoreprimary { get; set; }
        public decimal? SipSenpupilsstatementehctrustsecondaryeng { get; set; }
        public decimal? SipAenglishmathsgrade5orabovedisadeng { get; set; }
        public decimal? SipAenglishmathsgrade5orabovedisadvantaged { get; set; }
        public decimal? SipAstayingineducationoremploymentengland { get; set; }
        public decimal? SipOfpupilsachievingebaccenglishgrade5above { get; set; }
        public string SipName { get; set; }
        public int? SipNumberofsecondaryschoolsinmat5years { get; set; }
        public decimal? SipEnteredachievingebaccsciencegrade5above { get; set; }
        public decimal? SipOfpupilsachievingebaccmathsgrade5above { get; set; }
        public decimal? SipEnteredachievingebacchumanitiesgrade4abov { get; set; }
        public decimal? SipKeystage1averagepointscoreonentryengland { get; set; }
        public string SipParentaccountidname { get; set; }
        public decimal? SipDisadvantagedpupilsengland { get; set; }
        public decimal? SipAmeetinghigherstdrwmdisadvantagedprimary { get; set; }
        public decimal? SipAchievingebaccatgrade5corabovetrust { get; set; }
        public decimal? SipAachievingebaccatgrade5coraboveengland { get; set; }
        public string SipEstablishmenttypeidname { get; set; }
        public decimal? SipWritingprogressscoredisadvantagedtrust { get; set; }
        public decimal? SipAachievingebaccgrade4corabovedisadeng { get; set; }
        public decimal? SipOfpupilsachievingebaccenglishgrade4above { get; set; }
        public decimal? SipAreadingscoreprimarydisadvantagedengand { get; set; }
        public decimal? SipAprogress8scoredisadvantagedsecondaryeng { get; set; }
        public decimal? SipEnteredachievingebaccsciencegrade4above { get; set; }
        public decimal? SipSenpupilsstatementehcplantrustsecondary { get; set; }
        public decimal? SipEnteredachievingebacclanguagegrade4above { get; set; }
        public decimal? SipAenteringebaccsecondary { get; set; }
        public decimal? SipEbaccaveragepointscoredisadvantagedtrust { get; set; }
        public decimal? SipKeystage1averagepointscoreonentrytrust { get; set; }
        public decimal? SipEnglishadditionallangsecondarytrusteng { get; set; }
        public decimal? SipAattainment8scoresecondary { get; set; }
        public decimal? SipMatmathsprogressscorenumber { get; set; }
        public decimal? SipAmathsscoreprimarydisadvantaged { get; set; }
        public decimal? SipMathsprogressscoredisadvantagedengland { get; set; }
        public string Owneridyominame { get; set; }
        public decimal? SipEbaccaveragepointscoreengland { get; set; }
        public decimal? SipAachievingebaccatgrade5corabovelocalauth { get; set; }
        public int? Timezoneruleversionnumber { get; set; }
        public int? SipNumberofconverteracademiessecondary { get; set; }
        public decimal? SipProgress8measureforenglishelementks4 { get; set; }
        public DateTime? SipReportingenddate { get; set; }
        public decimal? SipAachievingebaccgrade5corabovedisadengl { get; set; }
        public decimal? SipAstayingineducationoremploymentsecondary { get; set; }
        public decimal? SipAenglishmathsgrade4corabovesecondary { get; set; }
        public decimal? SipOfpupilsachievingebaccmathsgrade4above { get; set; }
        public DateTime? Createdon { get; set; }
        public decimal? SipAmeetingexpectedstdrwmdisadvantagedprimen { get; set; }
        public string Createdonbehalfbyname { get; set; }
        public decimal? SipAachievingebaccatgrade4corabovesecondary { get; set; }
        public decimal? SipEnglishadditionallanguagesecondarytrust { get; set; }
        public string Owneridtype { get; set; }
        public decimal? SipAenteringebaccenglandaverage { get; set; }
        public int? SipNumberofsponsoredacademiessecondary { get; set; }
        public decimal? SipAebaccaveragepointscoredisadvantaged { get; set; }
        public decimal? SipProgress8afteradjustmentforextremescores { get; set; }
        public decimal? SipProgress8scoredisadvantagedsecondary { get; set; }
        public string Owneridname { get; set; }
        public decimal? SipEbaccaveragepointscoretrust { get; set; }
        public string Createdonbehalfbyyominame { get; set; }
        public decimal? SipAachievingebaccgrade4corabovelocalauth { get; set; }
        public int? SipTotalschoolssecondaryother { get; set; }
        public string SipAlphaind { get; set; }
        public decimal? SipAenglishmathsgrade4corabovelocalauth { get; set; }
        public decimal? SipAattainment8scoresecondarydisadvantageden { get; set; }
        public decimal? SipAchievingebaccatgrade4corabovetrust { get; set; }
        public string Modifiedonbehalfbyname { get; set; }
        public decimal? SipAwritingscoreprimarydisadvantaged { get; set; }
        public decimal? SipProgress8score { get; set; }
        public decimal? SipReadingprogressscoredisadvantagedengland { get; set; }
        public decimal? SipEbaccdisadvantagedsecondarytrustengland { get; set; }
        public decimal? SipAchievingebaccatgrade5coraboveschool { get; set; }
        public decimal? SipAgrade5orabovemathsandenglishlocalauth { get; set; }
        public decimal? SipEnteredachievingebacchumanitiesgrade5abov { get; set; }
        public decimal? SipEbacc5cdisadvantagedtrust { get; set; }
        public decimal? SipProgress8onunadjustedpupilscoresks4 { get; set; }
        public decimal? SipAebaccaveragepointscoresecondary { get; set; }
        public decimal? SipAgrade5orabovemathandenglishengland { get; set; }
        public decimal? SipEbaccaveragepointscoredisadvantagedtruste { get; set; }
        public decimal? SipAwritingscoreprimary { get; set; }
        public decimal? SipAebaccaveragepointscoredisadvantagedengl { get; set; }
        public decimal? SipAenteringebaccsecondarydisadvantaged { get; set; }
        public decimal? SipWritingprogressscoredisadvantagedengland { get; set; }
        public decimal? SipProgress8disadvantagedschooltrustengland { get; set; }
        public decimal? SipAgrade5orabovemathandenglishsecondary { get; set; }
        public DateTime? SipReportingstartdate { get; set; }
        public decimal? SipReadingprogressscoredisadvantagedtrust { get; set; }
        public decimal? SipMatwritingscorenumber { get; set; }
        public Guid? SipEducationalperformancedataid { get; set; }
        public string Modifiedbyyominame { get; set; }
        public decimal? SipAachievingebaccgrade5corabovedisadvantage { get; set; }
        public string Modifiedonbehalfbyyominame { get; set; }
        public int? SipNumberofschoolsinmat4years { get; set; }
        public decimal? SipAenteringebaccsecondarydisadvantagedengl { get; set; }
        public decimal? SipKeystage2averagepointscoreonentrytrust { get; set; }
        public decimal? SipAenglishmathsgrade4coraboveengland { get; set; }
        public decimal? SipAachievingebaccatgrade5corabovesecondary { get; set; }
        public int? Importsequencenumber { get; set; }
        public decimal? SipAattainment8scorelocalauthority { get; set; }
        public decimal? SipMatprogress8scorenumber { get; set; }
        public int? Utcconversiontimezonecode { get; set; }
        public decimal? SipAreadingscoreprimarydisadvantaged { get; set; }
        public decimal? SipEnglishasadditionallanguagepupilsengland { get; set; }
        public decimal? SipAenglishmathsgrade4cabovedisadvantaged { get; set; }
        public decimal? SipOfpupilsinkeystage4includedinprogress8 { get; set; }
        public decimal? SipAmeetinghigherstandardinrwmprimaryeng { get; set; }
        public decimal? SipMathsprogressscoredisadvantagedtrust { get; set; }
        public decimal? SipAmeetingexpectedstandardinrwmdisadvprimar { get; set; }
        public decimal? SipEnteringebaccengland { get; set; }
        public decimal? SipDisadvantagedpupilssecondarytrust { get; set; }
        public decimal? SipAmeetinghigherstandardinrwmprimary { get; set; }
        public decimal? SipDisadvantagedpupilssecondaryengland { get; set; }
        public decimal? SipAprogress8scoresecondary { get; set; }
        public decimal? SipAmeetingexpectedstandardinrwmprimary { get; set; }
        public decimal? SipAenteringebacclocalauthorityaverage { get; set; }
        public decimal? SipAreadingscoreprimary { get; set; }
        public decimal? SipSenpupilswithstatementorehcplantrust { get; set; }
        public int? SipNumberofschoolsinmat3years { get; set; }
        public decimal? SipAstayingineducationemploymentlocalaut { get; set; }
        public decimal? SipMatreadingprogressscorenumber { get; set; }
        public decimal? SipAenglishmathsgrade4cabovedisadvantageden { get; set; }
        public int? SipNumberofconverteracademies { get; set; }
        public int? SipNumberofsecondaryschoolsinmat4years { get; set; }
        public decimal? SipDisadvantagedpupilstrust { get; set; }
        public decimal? SipAchievingebaccatgrade5coraboveengland { get; set; }
        public string Createdbyyominame { get; set; }
        public decimal? SipEnglishadditionallanguagesecondaryeng { get; set; }
        public int? SipNumberofsponsoredacademies { get; set; }
        public decimal? SipAmeetingexpectedstandardinrwmprimaryeng { get; set; }
        public decimal? SipProgress8disadvantagedschooltrust { get; set; }
        public decimal? SipAachievingebaccgrade4corabovedisad { get; set; }
        public decimal? SipEbacc4cdisadvantagedtrust { get; set; }
        public decimal? SipSenpupilswithstatementorehcplanengland { get; set; }
        public decimal? SipKeystage2averagepointscoreonentryengland { get; set; }
        public string SipParentaccountidyominame { get; set; }
        public bool? SipContainsprimarydata { get; set; }
        public bool? SipContainssecondarydata { get; set; }
        public bool? SipContainsacademyprimarydata { get; set; }
        public bool? SipContainsacademysecondarydata { get; set; }
        public decimal? SipReadingprogressscoredisadvantagedla { get; set; }
        public decimal? SipWritingprogressscoredisadvantagedla { get; set; }
        public decimal? SipMathsprogressscoredisadvantagedla { get; set; }
        public decimal? SipKeystage1averagepointscoreonentryla { get; set; }
        public decimal? SipDisadvantagedpupilsla { get; set; }
        public decimal? SipSenpupilswithstatementorehcplanla { get; set; }
        public decimal? SipEnglishasadditionallanguagepupilsla { get; set; }
        public decimal? SipEnteringebacclaaverage { get; set; }
        public decimal? SipEbaccaveragepointscorelaaverage { get; set; }
        public decimal? SipAchievingebaccatgrade5corabovela { get; set; }
        public decimal? SipAchievingebaccatgrade4corabovela { get; set; }
        public decimal? SipProgress8disadvantagedschooltrustla { get; set; }
        public decimal? SipEbaccdisadvantagedsecondarytrustla { get; set; }
        public decimal? SipEbaccaveragepointscoredisadvantagedtrustl { get; set; }
        public decimal? SipAchievingebacc5cdisadvantagedtrustla { get; set; }
        public decimal? SipAchievingebacc4cdisadvantagetrustla { get; set; }
        public decimal? SipKeystage2averagepointscoreonentryla { get; set; }
        public decimal? SipDisadvantagedpupilssecondaryla { get; set; }
        public decimal? SipSenpupilsstatementehctrustsecondaryla { get; set; }
        public decimal? SipEnglishadditionallangsecondarytrustla { get; set; }
        public decimal? SipAmeetingexpectedstandardinrwmprimaryla { get; set; }
        public decimal? SipAmeetinghigherstdinrwmprimarla { get; set; }
        public decimal? SipAmeetingexpectedstdrwmdisadvantagedprimla { get; set; }
        public decimal? SipAmeetinghigherstdrwmdisadvantagedprimla { get; set; }
        public decimal? SipAreadingscoreprimarydisadvantagedla { get; set; }
        public decimal? SipAwritingscoreprimarydisadvantagedla { get; set; }
        public decimal? SipAmathsscoreprimarydisadvantagedla { get; set; }
        public decimal? SipAattainment8scorela { get; set; }
        public decimal? SipAgrade5orabovemathandenglishla { get; set; }
        public decimal? SipAenglishmathsgrade4corabovela { get; set; }
        public decimal? SipAenteringebacclaaverage { get; set; }
        public decimal? SipAachievingebaccatgrade5corabovela { get; set; }
        public decimal? SipAebaccaveragepointscorelaaverage { get; set; }
        public decimal? SipAachievingebaccatgrade4corabovela { get; set; }
        public decimal? SipAprogress8scoredisadvantagedsecondaryla { get; set; }
        public decimal? SipAattainment8scoresecondarydisadvantag { get; set; }
        public decimal? SipAenglishmathsgrade5orabovedisadla { get; set; }
        public decimal? SipAenglishmathsgrade4cabovedisadvantagedla { get; set; }
        public decimal? SipAenteringebaccsecondarydisadvantagedla { get; set; }
        public decimal? SipAebaccaveragepointscoredisadvantagedla { get; set; }
        public decimal? SipAachievingebaccgrade4corabovedisadla { get; set; }
        public decimal? SipAachievingebaccgrade5corabovedisadla { get; set; }
        public decimal? SipAattainment8scoresecondarydisadvantagedla { get; set; }
        public int? SipNumberofconverteracademiesks4 { get; set; }
        public int? SipNumberofsponsoracademiesks4 { get; set; }
        public int? SipTotalschoolsintrustks4 { get; set; }
        public int? SipNumberofsponsoredacademiesks4 { get; set; }
        public int? SipNumberoffreeschoolsks2 { get; set; }
        public int? SipNumberoffreeschoolsks4 { get; set; }
        public int? SipNumberoffreeschoolssecondary { get; set; }
        public decimal? SipAmathsscoreprimaryla { get; set; }
        public decimal? SipAwritingscoreprimaryla { get; set; }
        public decimal? SipPercentageofenrolmentswhoarepersistentabs { get; set; }
        public decimal? SipAreadingscoreprimaryla { get; set; }
        public decimal? SipPercentageofoverallabsence { get; set; }
        public Guid? SipLocalauthority { get; set; }
        public string SipLocalauthorityEntitytype { get; set; }
        public string SipLocalauthorityname { get; set; }
        public string SipLocalauthoritycode { get; set; }
        public Guid? SipTrustparentestablishment { get; set; }
        public string SipTrustparentestablishmentEntitytype { get; set; }
        public string SipTrustparentestablishmentyominame { get; set; }
        public string SipTrustparentestablishmentname { get; set; }
        public decimal? SipAattainment8mathsscoresecondarydisadvanta { get; set; }
        public decimal? SipAattainment8englishscoresecondarydisadvan { get; set; }
        public decimal? SipAattainment8ebaccsecondarydisadvantagedla { get; set; }
        public decimal? SipAattainment8ebaccsecondarydisadvantageden { get; set; }
        public decimal? SipAattainment8ebaccscoresecondarydisadvanta { get; set; }
        public decimal? SipAattainment8mathssecondarydisadvantagedla { get; set; }
        public decimal? SipAattainment8mathssecondarydisadvantageden { get; set; }
        public decimal? SipAattainment8englishsecondarydisadla { get; set; }
        public decimal? SipAattainment8englishsecondarydisadeng { get; set; }
        public decimal? SipAnumberofdisadvantagedpupilsinprogress8 { get; set; }
        public decimal? SipAprogress8scoredisadvantagedsecondary { get; set; }
        public decimal? SipAprogress8lowercidisadvantaged { get; set; }
        public decimal? SipAprogress8lowercidisadvantagedla { get; set; }
        public decimal? SipAprogress8lowercidisadvantagedengland { get; set; }
        public decimal? SipAprogress8highercidisadvantagedla { get; set; }
        public decimal? SipAprogress8highercidisadvantaged { get; set; }
        public decimal? SipAprogress8highercidisadvantagedeng { get; set; }
        public decimal? SipAprogress8scoreenglishla { get; set; }
        public decimal? SipAprogress8scoreenglish { get; set; }
        public decimal? SipAprogress8scoreenglisheng { get; set; }
        public decimal? SipAprogress8scoremaths { get; set; }
        public decimal? SipAprogress8scoreebaccla { get; set; }
        public decimal? SipAprogress8scoreebacc { get; set; }
        public decimal? SipAprogress8scoreebaccengland { get; set; }
        public decimal? SipAprogress8scoremathsengland { get; set; }
        public decimal? SipAprogress8scoremathsla { get; set; }
        public decimal? SipAreadingscoreprimaryengland { get; set; }
        public decimal? SipAwritingscoreprimaryengland { get; set; }
        public decimal? SipAmathsscoreprimaryengland { get; set; }
        public decimal? SipAks5apsperentry { get; set; }
        public decimal? SipAks5apsperentryacademic { get; set; }
        public decimal? SipAks5apsperentryappliedgeneral { get; set; }
        public decimal? SipAnumberofdisadvantagedpupilsinprogress8la { get; set; }
        public decimal? SipAnumberofdisadvantagedpupilsinprogress8en { get; set; }
        public decimal? SipAks5valueaddedacademic { get; set; }
        public decimal? SipAks5valueaddedappliedgeneral { get; set; }
        public decimal? SipAks5apsperentryacademicla { get; set; }
        public decimal? SipAks5apsperentryacademiceng { get; set; }
        public decimal? SipAks5valueaddedacademicla { get; set; }
        public decimal? SipAks5valueaddedacademiceng { get; set; }
        public int? SipPerformancetype { get; set; }
        public decimal? SipAprogress8scoreenglishdisadvantaged { get; set; }
        public decimal? SipAprogress8scoreenglishdisadvantagedla { get; set; }
        public decimal? SipAprogress8scoreenglishdisadvantagedeng { get; set; }
        public decimal? SipAprogress8scoremathsdisadvantagedeng { get; set; }
        public decimal? SipAprogress8scoreebaccdisadvantagedla { get; set; }
        public decimal? SipAprogress8scoreebaccdisadvantaged { get; set; }
        public decimal? SipAprogress8scoreebaccdisadvantagedengland { get; set; }
        public decimal? SipAprogress8scoremathsdisadvantaged { get; set; }
        public decimal? SipAprogress8scoremathsdisadvantagedla { get; set; }
        public decimal? SipAks5apsperentryappliedgeneralla { get; set; }
        public decimal? SipAks5apsperentryappliedgeneraleng { get; set; }
        public decimal? SipAks5valueaddedappliedgeneraleng { get; set; }
        public decimal? SipAks5valueaddedappliedgeneralla { get; set; }
        public decimal? SipMeetingexpectedstandardinrwmdisadv { get; set; }
        public decimal? SipMeetingexpectedstandardinrwm { get; set; }
        public decimal? SipMeetinghigherstandardinrwm { get; set; }
        public decimal? SipMeetinghigherstandardrwmdisadv { get; set; }
        public decimal? SipReadingprogressscore { get; set; }
        public decimal? SipReadingprogressscoredisadv { get; set; }
        public decimal? SipWritingprogressscoredisadv { get; set; }
        public decimal? SipWritingprogressscore { get; set; }
        public decimal? SipMathsprogressscore { get; set; }
        public decimal? SipMathsprogressscoredisadv { get; set; }
        public decimal? SipAttainment8score { get; set; }
        public decimal? SipAttainment8scoredisadvantaged { get; set; }
        public decimal? SipProgress8scoredisadvantaged { get; set; }
        public decimal? SipGrade5orabovemathandenglish { get; set; }
        public decimal? SipGrade5orabovemathandenglishdisadvantaged { get; set; }
        public decimal? SipGrade4orabovemathandenglish { get; set; }
        public decimal? SipGrade4orabovemathandenglishdisadvantaged { get; set; }
        public decimal? SipEnteringebaccdisadvantaged { get; set; }
        public decimal? SipEbaccaveragepointscore { get; set; }
        public decimal? SipEbaccaveragepointscoredisadvantaged { get; set; }
        public decimal? SipAchievingebaccgrade5corabovedisadvantaged { get; set; }
        public decimal? SipAchievingebaccatgrade5corabove { get; set; }
        public decimal? SipAchievingebaccgrade4corabovedisadvantaged { get; set; }
        public decimal? SipAchievingebaccatgrade4corabove { get; set; }
        public decimal? SipDisadvantagedpupilssecondary { get; set; }
        public decimal? SipAveragepointscoreks2 { get; set; }
        public decimal? SipEnglishadditionallanguagesecondary { get; set; }
        public decimal? SipPupilssensecondary { get; set; }
        public decimal? SipKs1averagepointscore { get; set; }
        public decimal? SipPupilssenprimary { get; set; }
        public decimal? SipDisadvantagedpupilsprimarypercentage { get; set; }
        public int? SipNumberconverteracademiesprimary { get; set; }
        public decimal? SipEnglishadditionallanguageprimary { get; set; }
        public int? SipNumberofsponsoredacademiesprimary { get; set; }
        public int? SipNumberoffreeschoolsprimary { get; set; }
        public int? SipNumberofschoolsinmat4yearsprimary { get; set; }
        public int? SipNumberofschoolsinmat3yearsprimary { get; set; }
        public int? SipReadingprogrtessscorecategory { get; set; }
        public int? SipMathsprogressscorecategory { get; set; }
        public int? SipWritingprogrtessscorecategory { get; set; }
        public int? SipProgress8scorecategory { get; set; }
        public int? SipEligiblepupilsks2 { get; set; }
        public decimal? SipMeetingexpectedstandardinreading { get; set; }
        public decimal? SipMeetingexpectedstandardinwriting { get; set; }
        public decimal? SipMeetingexpectedstandardinmaths { get; set; }
        public int? SipEligiblepupilsdisadvks2 { get; set; }
        public decimal? SipMeetingexpectedstandardinreadingdisadv { get; set; }
        public decimal? SipMeetingexpectedstandardinwritingdisadv { get; set; }
        public decimal? SipMeetingexpectedstandardinmathsdisadv { get; set; }
        public int? SipEligiblepupilsnotdisadvks2 { get; set; }
        public decimal? SipMeetingexpectedstandardinrwmnotdisadv { get; set; }
        public decimal? SipMeetingexpectedstandardinreadingnotdisadv { get; set; }
        public decimal? SipMeetingexpectedstandardinwritingnotdisadv { get; set; }
        public decimal? SipMeetingexpectedstandardinmathsnotdisadv { get; set; }
        public decimal? SipReadingprogressscorenotdisadv { get; set; }
        public decimal? SipWritingprogressscorenotdisadv { get; set; }
        public decimal? SipMathsprogressscorenotdisadv { get; set; }
        public int? SipEligiblepupilsgirlsks2 { get; set; }
        public decimal? SipMeetingexpectedstandardinrwmgirls { get; set; }
        public decimal? SipReadingprogressgirls { get; set; }
        public decimal? SipWritingprogressgirls { get; set; }
        public decimal? SipMathsprogressgirls { get; set; }
        public int? SipEligiblepupilsboysks2 { get; set; }
        public decimal? SipMeetingexpectedstandardinrwmboys { get; set; }
        public decimal? SipReadingprogressboys { get; set; }
        public decimal? SipWritingprogressboys { get; set; }
        public decimal? SipMathsprogressboys { get; set; }
        public int? SipEligiblepupilsealks2 { get; set; }
        public decimal? SipMeetingexpectedstandardinrwmeal { get; set; }
        public decimal? SipReadingprogresseal { get; set; }
        public decimal? SipWritingprogresseal { get; set; }
        public decimal? SipMathsprogresseal { get; set; }
        public int? SipEligiblepupilsks4 { get; set; }
        public int? SipEligiblep8pupils { get; set; }
        public int? SipEligiblepupilsdisadvks4 { get; set; }
        public int? SipEligiblep8pupilsdisadv { get; set; }
        public int? SipEligiblepupilsnotdisadvks4 { get; set; }
        public decimal? SipGrade5oraboveenglishmathsnotdisadv { get; set; }
        public decimal? SipGrade4oraboveenglishmathsnotdisadv { get; set; }
        public decimal? SipAttainment8scorenotdisadvantaged { get; set; }
        public int? SipEligiblep8pupilsnotdisadvantaged { get; set; }
        public decimal? SipProgress8scorenotdisadvantaged { get; set; }
        public decimal? SipEnteringebaccnotdisadv { get; set; }
        public decimal? SipAchievingebaccatgrade5corabovenotdisadv { get; set; }
        public decimal? SipAchievingebaccatgrade4corabovenotdisadv { get; set; }
        public decimal? SipEligiblepupilsgirlsks4 { get; set; }
        public decimal? SipGrade5oraboveenglishmathsgirls { get; set; }
        public decimal? SipGrade4oraboveenglishmathsgirls { get; set; }
        public decimal? SipAttainment8scoregirls { get; set; }
        public int? SipEligiblep8pupilsgirls { get; set; }
        public decimal? SipProgress8scoregirls { get; set; }
        public decimal? SipEnteringebaccgirls { get; set; }
        public decimal? SipAchievingebaccatgrade5corabovegirls { get; set; }
        public decimal? SipAchievingebaccatgrade4corabovegirls { get; set; }
        public int? SipEligiblepupilsboysks4 { get; set; }
        public decimal? SipGrade5oraboveenglishmathsboys { get; set; }
        public decimal? SipGrade4oraboveenglishmathsboys { get; set; }
        public decimal? SipAttainment8scoreboys { get; set; }
        public int? SipEligiblep8pupilsboys { get; set; }
        public decimal? SipProgress8scoreboys { get; set; }
        public decimal? SipEnteringebaccboys { get; set; }
        public decimal? SipAchievingebaccatgrade5coraboveboys { get; set; }
        public decimal? SipAchievingebaccatgrade4coraboveboys { get; set; }
        public int? SipEligiblepupilsealks4 { get; set; }
        public decimal? SipGrade5oraboveenglishmathseal { get; set; }
        public decimal? SipGrade4oraboveenglishmathseal { get; set; }
        public decimal? SipAttainment8scoreeal { get; set; }
        public int? SipEligiblep8pupilseal { get; set; }
        public decimal? SipProgress8scoreeal { get; set; }
        public decimal? SipAchievingebaccatgrade5coraboveeal { get; set; }
        public decimal? SipEnteringebacceal { get; set; }
        public decimal? SipAchievingebaccatgrade4coraboveeal { get; set; }
        public int? SipAleveleligiblepupils { get; set; }
        public decimal? SipAlevelaveragepspe { get; set; }
        public int? SipAcademiceligiblepupils { get; set; }
        public decimal? SipAcademiclevelaveragepspe { get; set; }
        public int? SipTechleveleligiblepupils { get; set; }
        public decimal? SipTechlevelaveragepspe { get; set; }
        public decimal? SipAppliedgeneralaveragepspe { get; set; }
        public int? SipAppliedeligiblepupils { get; set; }
        public decimal? SipAttainment8scoreenglish { get; set; }
        public decimal? SipAttainment8scoreenglishdisadvantaged { get; set; }
        public decimal? SipAttainment8scoreebacc { get; set; }
        public decimal? SipAttainment8scoreebaccdisadvantaged { get; set; }
        public decimal? SipAttainment8scoremaths { get; set; }
        public decimal? SipAttainment8scoremathsdisadvantaged { get; set; }
        public int? SipNumberofpupilsprogress8 { get; set; }
        public int? SipNumberofpupilsprogress8disadvantaged { get; set; }
        public decimal? SipProgress8upperconfidence { get; set; }
        public decimal? SipProgress8upperconfidencedisadvantaged { get; set; }
        public decimal? SipProgress8lowerconfidence { get; set; }
        public decimal? SipProgress8lowerconfidencedisadvantaged { get; set; }
        public decimal? SipProgress8english { get; set; }
        public decimal? SipProgress8englishdisadvantaged { get; set; }
        public decimal? SipProgress8maths { get; set; }
        public decimal? SipProgress8mathsdisadvantaged { get; set; }
        public decimal? SipProgress8ebacc { get; set; }
        public decimal? SipProgress8ebaccdisadvantaged { get; set; }
        public decimal? SipEbaccaveragepointscorenotdisadv { get; set; }
        public decimal? SipEbaccaveragepointscoregirls { get; set; }
        public decimal? SipEbaccaveragepointscoreboys { get; set; }
        public decimal? SipEbaccaveragepointscoreeal { get; set; }
        public decimal? SipPersistentabsentees { get; set; }
        public bool? SipContainsks5data { get; set; }
        public int? SipNationalcategory { get; set; }
    }
}
