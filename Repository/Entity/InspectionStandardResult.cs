using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class InspectionStandardResult
    {
        public int? ID { get; set; }
        public string POorModelNo { get; set; }
        public int? PictureNo { get; set; }
        public string PhotoPath { get; set; }
        public string DefectDescription { get; set; }
        public int? Critical { get; set; }
        public int? Major { get; set; }
        public int? Minor { get; set; }
        public int? SampleSizeCritical { get; set; }
        public int? SampleSizeMajor { get; set; }
        public int? SampleSizeMinor { get; set; }
        public int? TotalFoundDefectsCritical { get; set; }
        public int? TotalFoundDefectsMajor { get; set; }
        public int? TotalFoundDefectsMinor { get; set; }
        public int? AQLAllowedDefectsCritical { get; set; }
        public int? AQLAllowedDefectsMajor { get; set; }
        public int? AQLAllowedDefectsMinor { get; set; }
        public string AQLResults { get; set; }
        public string GeneralDefectNotIncludedAQLResultAbove { get; set; }
        public string GeneralDefectDescription { get; set; }
        public string NonConformityFound { get; set; }
        public string NonConformityRemark { get; set; }
    }
}
