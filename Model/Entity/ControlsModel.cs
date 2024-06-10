using System;

namespace Model.Entity
{
    public partial class ControlsModel
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeqKey { get; set; }
        public int? Parent { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
