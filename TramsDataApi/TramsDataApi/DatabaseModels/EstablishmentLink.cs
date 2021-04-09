using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class EstablishmentLink
    {
        public string Urn { get; set; }
        public string LinkUrn { get; set; }
        public string LinkName { get; set; }
        public string LinkType { get; set; }
        public string LinkEstablishedDate { get; set; }
    }
}
