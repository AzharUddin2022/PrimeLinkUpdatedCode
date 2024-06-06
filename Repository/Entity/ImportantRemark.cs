﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class ImportantRemark
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string RemarkType { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
