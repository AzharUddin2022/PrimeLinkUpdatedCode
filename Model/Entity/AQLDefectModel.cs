using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public partial class AQLDefectModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string Defects { get; set; }
        public string RemarkContent { get; set; }
        public string Major { get; set; }
        public string Critical { get; set; }
        public string Minor { get; set; }
        public string Filename { get; set; }
    }
}
