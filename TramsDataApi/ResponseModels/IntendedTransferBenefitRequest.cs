using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class IntendedTransferBenefitRequest
    {
        public List<string> SelectedBenefits { get; set; }
        public string OtherBenefitValue { get; set; }
    }
}