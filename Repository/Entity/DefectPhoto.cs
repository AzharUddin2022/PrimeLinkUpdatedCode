using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class DefectPhoto
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string Path { get; set; }
        public string DefectType { get; set; }
        public string LevelName { get; set; }
        public int? LevelNo { get; set; }
    }
}
