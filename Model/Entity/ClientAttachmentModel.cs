using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ClientAttachmentModel
    {
        public int Id { get; set; }
        public int? UserFormId { get; set; }
        public int? UserId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UserModel User { get; set; }
        public virtual UserFormModel UserForm { get; set; }
    }
}
