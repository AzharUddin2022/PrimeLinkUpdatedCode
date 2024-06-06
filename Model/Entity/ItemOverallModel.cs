using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public class ItemOverallModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string ItemOverallDimensionsResult { get; set; }
        public string ItemOverallDimensionsMeasuredData { get; set; }
        public string OtherDimensionsResult { get; set; }
        public string OtherDimensionsMeasuredData { get; set; }
        public string ItemNetWeightResult { get; set; }
        public string ItemNetWeightMeasuredData { get; set; }
        public string ItemColor { get; set; }
        public string GeneralConstructionAndMaterial { get; set; }
    }
}
