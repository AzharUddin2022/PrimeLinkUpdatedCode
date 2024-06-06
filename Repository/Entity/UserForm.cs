using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class UserForm
    {
        public UserForm()
        {
            ClientAttachments = new HashSet<ClientAttachment>();
            InspectorAllocations = new HashSet<InspectorAllocation>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AssignedTo { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ClientAttachment> ClientAttachments { get; set; }
        public virtual ICollection<InspectorAllocation> InspectorAllocations { get; set; }
    }
}
