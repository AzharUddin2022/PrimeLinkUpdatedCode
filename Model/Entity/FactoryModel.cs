using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public partial class FactoryModel
    {
        public int Id { get; set; }
        public int? GeneralInformationId { get; set; }
        public string FactoryPreset { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string FactoryCompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool? IsFactoryEmailIncluded { get; set; }
        public bool? PayByLC { get; set; }
        public bool IsApproved { get; set; }
        public bool IsFactory { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual GeneralInformationModel GeneralInformation { get; set; }
    }
}
