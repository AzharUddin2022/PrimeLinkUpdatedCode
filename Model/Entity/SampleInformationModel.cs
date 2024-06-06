using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public partial class SampleInformationModel
    {
        public SampleInformationModel()
        {
            UserForms = new List<UserFormModel>();
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserFormId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public bool? IsReferSample { get; set; }
        public string SendingDestination { get; set; }
        public string CourierCompanyName { get; set; }
        public string CourierAccountNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactPerson { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public string TrackingNumber { get; set; }
        public string ToDoAfterInspection { get; set; }
        public bool? IsCollectSample { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UserModel User { get; set; }
        public virtual List<UserFormModel> UserForms { get; set; }
    }
}
