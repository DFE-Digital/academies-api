using System.Collections.Generic;

namespace TramsDataApi.RequestModels
{
    public class IntendedTransferBenefitRequest
    {
        public List<string> SelectedBenefits { get; set; }
        public string OtherBenefitValue { get; set; }
    }
}