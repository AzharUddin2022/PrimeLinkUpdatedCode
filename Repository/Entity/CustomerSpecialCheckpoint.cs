using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class CustomerSpecialCheckpoint
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string OverallResult { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
