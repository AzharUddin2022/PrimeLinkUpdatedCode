using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ItemRemarkDatum
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string ItemRemarkStatus { get; set; }
        public string ItemRemarkComments { get; set; }
        public string FilePath { get; set; }
    }
}
