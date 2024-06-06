using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class GeneralInformationModel
    {
        public GeneralInformationModel()
        {
            References = new List<ReferenceModel>();
            UserForms = new List<UserFormModel>();
            Vendor = new VendorModel();
            Factory = new FactoryModel();
            InspectorAllocation = new InspectorAllocationModel();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public string MissionReference { get; set; }
        public string AllocatedTo { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public string ProductLine { get; set; }
        public string ProductCategory { get; set; }
        public long? MinPercentProductToFinish { get; set; }
        public long? MinPercentProductToFinishAndPacked { get; set; }
        public string DestinationCountry { get; set; }
        public string QuantityUnit { get; set; }
        public DateTime? ServiceDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserModel User { get; set; }
        public virtual List<ReferenceModel> References { get; set; }
        public virtual List<UserFormModel> UserForms { get; set; }
        public virtual FactoryModel Factory { get; set; }
        [NotMapped]
        public virtual InspectorAllocationModel InspectorAllocation { get; set; }
        public virtual VendorModel Vendor { get; set; }
    }
}
