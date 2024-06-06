using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class YourProduct
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string Path { get; set; }
    }
}
