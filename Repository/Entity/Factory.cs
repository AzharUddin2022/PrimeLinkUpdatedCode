using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class Factory
    {
        public int Id { get; set; }
        public int? GeneralInformationId { get; set; }
        public string FactoryPreset { get; set; }
        public string FactoryCompanyName { get; set; }
        public string Email { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool? IsFactoryEmailIncluded { get; set; }
        public bool? PayByLC { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual GeneralInformation GeneralInformation { get; set; }
    }
}
