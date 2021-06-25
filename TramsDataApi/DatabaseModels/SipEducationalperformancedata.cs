using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class SipEducationalperformancedata
    {
        public Guid Id { get; set; }
        public string SipName { get; set; }
        public decimal? SipMeetingexpectedstandardinrwm { get; set; }
        public decimal? SipMeetingexpectedstandardinrwmdisadv { get; set; }
        public decimal? SipMeetinghigherstandardinrwm { get; set; }
        public decimal? SipMeetinghigherstandardrwmdisadv { get; set; }
        public decimal? SipProgress8score { get; set; }
        public decimal? SipProgress8scoredisadvantaged { get; set; }
        public Guid? SipParentaccountid { get; set; }
        public decimal? SipReadingprogressscore { get; set; }
        public decimal? SipReadingprogressscoredisadv { get; set; }
        public decimal? SipWritingprogressscoredisadv { get; set; }
        public decimal? SipWritingprogressscore { get; set; }
        public decimal? SipMathsprogressscore { get; set; }
        public decimal? SipMathsprogressscoredisadv { get; set; }
    }
}
