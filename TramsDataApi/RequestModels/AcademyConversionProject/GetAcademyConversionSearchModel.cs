﻿using System.Collections.Generic;

namespace TramsDataApi.RequestModels.AcademyConversionProject
{
    public class GetAcademyConversionSearchModel
    {
        public int Page { get; set; }
        public int Urn { get; set; }
        public int Count { get; set; }
        public string TitleFilter { get; set; }
        public IEnumerable<string> DeliveryOfficerQueryString { get; set; }
        public IEnumerable<int?> RegionUrnsQueryString { get; set; }
        public IEnumerable<string> StatusQueryString { get; set; }
    }
}
