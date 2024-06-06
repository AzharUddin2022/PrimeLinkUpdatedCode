using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class InspectorAllocation
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public int? InspectorId { get; set; }
        public string InspectorName { get; set; }
        public string UserFormName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UserForm UserForm { get; set; }
    }
}
