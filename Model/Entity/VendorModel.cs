using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public partial class VendorModel
    {
        public int Id { get; set; }
        public int? GeneralInformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string VendorPreset { get; set; }
        public string VendorCompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string NatureOfVendor { get; set; }
        public bool? IsVendorEmailIncluded { get; set; }
        public bool IsApproved { get; set; }
        public bool IsVendor { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual GeneralInformationModel GeneralInformation { get; set; }
    }
}
