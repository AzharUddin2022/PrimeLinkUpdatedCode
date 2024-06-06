using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ItemMappingList
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public int? UnitsPerCarton { get; set; }
        public int? PackedUnits { get; set; }
        public int? PackedCartons { get; set; }
        public int? FinishedUnpacked { get; set; }
        public int? NotFinishedUnits { get; set; }
        public int? TotalCartonsNo { get; set; }
        public int? SelectedCartonNo { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
