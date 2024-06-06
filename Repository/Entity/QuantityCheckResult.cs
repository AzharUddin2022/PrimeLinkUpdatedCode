using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class QuantityCheckResult
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string PONumber { get; set; }
        public string ModelNumber { get; set; }
        public string OrderQtyUnits { get; set; }
        public int? UnitsORCarton { get; set; }
        public int? FinishedAndPackedUnits { get; set; }
        public int? FinishedAndPackedCartons { get; set; }
        public int? FinishedButNotPackedUnits { get; set; }
        public int? NotFinishedUnits { get; set; }
        public string Results { get; set; }
        public int? TotalFinishedAndPackedUnits { get; set; }
        public int? TotalFinishedAndPackedCartons { get; set; }
        public int? TotalFinishedButNotPackedUnits { get; set; }
        public int? TotalNotFinishedUnits { get; set; }
        public string ResultORRemarksDesc { get; set; }
        public string FilePath { get; set; }
    }
}
