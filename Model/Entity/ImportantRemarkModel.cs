using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ImportantRemarkModel
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
