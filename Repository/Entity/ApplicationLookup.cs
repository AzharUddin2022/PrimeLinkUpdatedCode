using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ApplicationLookup
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeqKey { get; set; }
        public int? Parent { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
