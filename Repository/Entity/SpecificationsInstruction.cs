using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class SpecificationsInstruction
    {
        public SpecificationsInstruction()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public int? MeasurementPoints { get; set; }
        public int? Sizes { get; set; }
        public bool? IsEmailIncluded { get; set; }
        public bool? FinalReportToPerson { get; set; }
        public bool? FinalReportToVendor { get; set; }
        public bool? IsUrgent { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
