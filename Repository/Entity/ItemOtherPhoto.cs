using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ItemOtherPhoto
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string FilePath { get; set; }
    }
}
