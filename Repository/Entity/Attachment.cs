using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public int? SpecificationsInstructionsId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual SpecificationsInstruction SpecificationsInstructions { get; set; }
    }
}
