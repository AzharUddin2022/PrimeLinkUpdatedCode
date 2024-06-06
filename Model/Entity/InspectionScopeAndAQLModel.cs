using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public partial class InspectionScopeAndAQLModel
    {
        public InspectionScopeAndAQLModel()
        {
            UserForms = new List<UserFormModel>();
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public bool? IsFunctionCheck { get; set; }
        public bool? IsQuantityCheck { get; set; }
        public bool? IsPkgePackShipCheck { get; set; }
        public bool? IsProductLabelCheck { get; set; }
        public bool? IsDimensionCheck { get; set; }
        public bool? IsOnSiteTest { get; set; }
        public int? PiecesInspected { get; set; }
        public string SamplePlan { get; set; }
        public decimal? SampleSize { get; set; }
        public decimal? CriticalDefects { get; set; }
        public decimal? MajorDefects { get; set; }
        public decimal? MinorDefects { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UserModel User { get; set; }
        public virtual List<UserFormModel> UserForms { get; set; }
    }
}
