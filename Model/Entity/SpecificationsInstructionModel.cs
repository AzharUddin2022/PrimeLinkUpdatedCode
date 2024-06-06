using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public partial class SpecificationsInstructionModel
    {
        public SpecificationsInstructionModel()
        {
            Attachments = new List<AttachmentModel>();
            UserForms = new List<UserFormModel>();
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
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

        public virtual UserModel User { get; set; }
        public virtual List<AttachmentModel> Attachments { get; set; }
        public virtual List<UserFormModel> UserForms { get; set; }
    }
}
