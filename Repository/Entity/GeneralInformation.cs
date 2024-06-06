using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class GeneralInformation
    {
        public GeneralInformation()
        {
            References = new HashSet<Reference>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public string MissionReference { get; set; }
        public string ProductLine { get; set; }
        public string ProductCategory { get; set; }
        public long? MinPercentProductToFinish { get; set; }
        public long? MinPercentProductToFinishAndPacked { get; set; }
        public string DestinationCountry { get; set; }
        public string QuantityUnit { get; set; }
        public DateTime? ServiceDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}
