using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public class ItemRemarkDatumModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string ItemRemarkStatus { get; set; }
        public string ItemRemarkComments { get; set; }
        public string FilePath { get; set; }
    }
}
