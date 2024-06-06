using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class InnerPackaging
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string InnerPackagingMarkingsLabeling { get; set; }
        public string InnerPackagingMethodAssortmentResult { get; set; }
    }
}
