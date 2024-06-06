using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public class GeneralRemarksListModel
    {
        public int Id { get; set; }
        public bool? IsGeneralRemarks { get; set; }
        public int? ReferenceId { get; set; }
        public string RemarkType { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
