using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class Lease_Detail
    {
        public int LeaseId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Lease_status { get; set; }
        public int? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
