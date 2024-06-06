using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public class OnSiteTestResultModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string TestDescription { get; set; }
        public string SampleSize { get; set; }
        public string Results { get; set; }
        public string ResultComments { get; set; }
        public string FilePath { get; set; }
    }
}
