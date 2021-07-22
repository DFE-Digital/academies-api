using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class ViewAcademyConversionResponseFactory
    {
        public static ViewAcademyConversionResponse Create(ViewAcademyConversions viewAcademyConversions)
        {
            if (viewAcademyConversions == null)
            {
                return null;
            }

            return new ViewAcademyConversionResponse
            {
                Deficit = viewAcademyConversions.ProjectTemplateInformationDeficit,
                ViabilityIssue = viewAcademyConversions.ProjectTemplateInformationViabilityIssue,
                PAN = viewAcademyConversions.DeliveryProcessPan,
                PFI = viewAcademyConversions.DeliveryProcessPfi
            };
        }
    }
}
