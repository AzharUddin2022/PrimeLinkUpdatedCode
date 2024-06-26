﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ShipperCartonPackaging
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string ShipperCartonDimensionsResult { get; set; }
        public string ShipperCartonDimensionsMeasuredData { get; set; }
        public string ShipperCartonWeightResult { get; set; }
        public string ShipperCartonWeightMeasuredData { get; set; }
        public string ShipperCartonMarkingsLabelingResult { get; set; }
        public string PackagingMethodAssortmentResult { get; set; }
    }
}
