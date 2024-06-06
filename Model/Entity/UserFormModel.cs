using System;

namespace Model.Entity
{
    public partial class UserFormModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string InspectorName { get; set; }
        public string ClientName { get; set; }
        public string MissionReference { get; set; }
        public bool? IsAdmin { get; set; }
        public int? AssignedTo { get; set; }
        public string ProductLine { get; set; }
        public string ProductCategory { get; set; }
        public string DestinationCountry { get; set; }
        public string QuantityUnit { get; set; }
        public DateTime? ServiceDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public bool? IsApproved { get; set; }
        public string Approved { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserModel User { get; set; }
    }
}
