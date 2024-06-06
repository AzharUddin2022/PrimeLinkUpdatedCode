using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class SamplingInformation
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string PONumber { get; set; }
        public string ModelNumber { get; set; }
        public decimal? SampleSizeFromPackedCTNS { get; set; }
        public decimal? SampleSizeFromFinishedUnPacked { get; set; }
        public decimal? InspectedCartonCTN { get; set; }
        public string InspectedCartonNumber { get; set; }
        public int? TotalSampleSizePackedCTNS { get; set; }
        public int? TotalSampleSizeFinishedUnpacked { get; set; }
        public int? TotalInspectedCartonCTN { get; set; }
        public string FactoryAllowsDrawingSamples { get; set; }
        public string QuantityAvailableForSampling { get; set; }
    }
}
