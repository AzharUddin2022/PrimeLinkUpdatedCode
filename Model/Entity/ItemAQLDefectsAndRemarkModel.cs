using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public partial class ItemAQLDefectsAndRemarkModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public int? LotSize { get; set; }
        public string InspectionLevel { get; set; }
        public int? SampleSizeCritical { get; set; }
        public int? SampleSizeMajor { get; set; }
        public int? SampleSizeMinor { get; set; }
        public decimal? AQLCritical { get; set; }
        public decimal? AQLMajor { get; set; }
        public decimal? AQLMinor { get; set; }
        public int? MaxDefectsAllowedCritical { get; set; }
        public int? MaxDefectsAllowedMajor { get; set; }
        public int? MaxDefectsAllowedMinor { get; set; }
        public int? DefectsAllowedCritical { get; set; }
        public int? DefectsAllowedMajor { get; set; }
        public int? DefectsAllowedMinor { get; set; }
        public string AQLResult { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
