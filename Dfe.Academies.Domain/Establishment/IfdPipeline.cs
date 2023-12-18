using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Dfe.Academies.Domain.Establishment
{
    public class IfdPipeline
    {
        public long? SK { get; set; }
        public string? GeneralDetailsUrn { get; set; }
        public string? DeliveryProcessPFI { get; set; }

        public string? DeliveryProcessPAN { get; set; }

        public string? ProjectTemplateInformationDeficit { get; set; }

        public string? ProjectTemplateInformationViabilityIssue { get; set; }

    }
}
