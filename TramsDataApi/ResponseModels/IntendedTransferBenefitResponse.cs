using System.Collections.Generic;

namespace TramsDataApi.ResponseModels
{
    public class IntendedTransferBenefitResponse
    {
        public List<string> SelectedBenefits { get; set; }
        public string OtherBenefitValue { get; set; }
    }
}