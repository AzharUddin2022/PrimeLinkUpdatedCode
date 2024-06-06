using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public partial class InnerPackagingModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string InnerPackagingMarkingsLabeling { get; set; }
        public string InnerPackagingMethodAssortmentResult { get; set; }
    }
}
