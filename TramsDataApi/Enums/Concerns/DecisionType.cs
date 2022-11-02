using System;

namespace TramsDataApi.Enums.Concerns
{
    [Obsolete("This endpoint is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public enum DecisionType
    {
        NoticeToImprove = 1,
        Section128 = 2,
        QualifiedFloatingCharge = 3,
        NonRepayableFinancialSupport = 4,
        RepayableFinancialSupport = 5,
        ShortTermCashAdvance = 6,
        WriteOffRecoverableFunding = 7,
        OtherFinancialSupport = 8,
        EstimatesFundingOrPupilNumberAdjustment = 9,
        EsfaApproval = 10,
        FreedomOfInformationExemptions = 11
    }
}
