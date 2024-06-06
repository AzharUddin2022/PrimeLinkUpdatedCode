using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class GeneralRemarksAndImagesList
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string Seqkey { get; set; }
        public string RemarkType { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int? Critical { get; set; }
        public int? Major { get; set; }
        public int? Minor { get; set; }
        public int? Percentage { get; set; }
        public int? SampleSize { get; set; }
        public string Result { get; set; }
        public string Comments { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
