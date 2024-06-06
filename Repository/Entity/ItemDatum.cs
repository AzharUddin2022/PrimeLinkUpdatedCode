using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ItemDatum
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string UnitsOrCarton { get; set; }
        public string PackedUnits { get; set; }
        public string PackedCartons { get; set; }
        public string FinishedUnpacked { get; set; }
        public string NotFinishedUnits { get; set; }
        public string OverallResult { get; set; }
    }
}
