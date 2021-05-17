using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class AcademyTransferProjectIntendedTransferBenefits
    {
        public int Id { get; set; }
        public int? FkAcademyTransferProjectUrn { get; set; }
        public string SelectedBenefit { get; set; }

        public virtual AcademyTransferProjects FkAcademyTransferProjectUrnNavigation { get; set; }
    }
}
