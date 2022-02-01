﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class AcademyTransferProjects
    {
        public AcademyTransferProjects()
        {
            AcademyTransferProjectIntendedTransferBenefits = new HashSet<AcademyTransferProjectIntendedTransferBenefits>();
            TransferringAcademies = new HashSet<TransferringAcademies>();
        }
        
        public int Id { get; set; }
        public int Urn { get; set; }
        
        public string ProjectReference { get; set; }
        public string OutgoingTrustUkprn { get; set; }
        public string WhoInitiatedTheTransfer { get; set; }
        public bool? RddOrEsfaIntervention { get; set; }
        public string RddOrEsfaInterventionDetail { get; set; }
        public string TypeOfTransfer { get; set; }
        public string OtherTransferTypeDescription { get; set; }
        public DateTime? TransferFirstDiscussed { get; set; }
        public DateTime? TargetDateForTransfer { get; set; }
        public DateTime? HtbDate { get; set; }
        public bool? HasTransferFirstDiscussedDate { get; set; }
        public bool? HasTargetDateForTransfer { get; set; }
        public bool? HasHtbDate { get; set; }
        public string ProjectRationale { get; set; }
        public string TrustSponsorRationale { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public bool? HighProfileShouldBeConsidered { get; set; }
        public string HighProfileFurtherSpecification { get; set; }
        public bool? ComplexLandAndBuildingShouldBeConsidered { get; set; }
        public string ComplexLandAndBuildingFurtherSpecification { get; set; }
        public bool? FinanceAndDebtShouldBeConsidered { get; set; }
        public string FinanceAndDebtFurtherSpecification { get; set; }
        public string OtherBenefitValue { get; set; }
        public string Author { get; set; }
        public string Recommendation { get; set; }
        public string AcademyPerformanceAdditionalInformation { get; set; }
        public string PupilNumbersAdditionalInformation { get; set; }
        public string LatestOfstedJudgementAdditionalInformation { get; set; }
        public string KeyStage2PerformanceAdditionalInformation { get; set; }
        public string KeyStage4PerformanceAdditionalInformation { get; set; }
        public string KeyStage5PerformanceAdditionalInformation { get; set; }

        public virtual ICollection<AcademyTransferProjectIntendedTransferBenefits> AcademyTransferProjectIntendedTransferBenefits { get; set; }
        public virtual ICollection<TransferringAcademies> TransferringAcademies { get; set; }
    }
}
