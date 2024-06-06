using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class Reference
    {
        public int Id { get; set; }
        public int? GeneralInformationId { get; set; }
        public string PO { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public long? Quantity { get; set; }
        public string ProductType { get; set; }
        public int? LevelNo { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual GeneralInformation GeneralInformation { get; set; }
    }
}
