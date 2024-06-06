using Component;
using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Entity
{
    public partial class InspectorAllocationModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public int? InspectorId { get; set; }
        public string InspectorName { get; set; }
        public string UserFormName { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<DropdownBinderModel> dropdownBinderModel { get; set; }
        public List<DropdownBinderModel> dropdownBinderModel1 { get; set; }
        public List<DropdownBinderModel> dropdownBinderModel2 { get; set; }
        public virtual UserFormModel UserForm { get; set; }
    }
}
