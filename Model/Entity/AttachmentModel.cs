
using System;

namespace Model.Entity
{
    public partial class AttachmentModel
    {
        public int Id { get; set; }
        public int? SpecificationsInstructionsId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public bool IsApproved { get; set; }
        public int i { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual SpecificationsInstructionModel SpecificationsInstructions { get; set; }
    }
}
