using Component;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class UserModel
    {
        public UserModel()
        {
            GeneralInformations = new List<GeneralInformationModel>();
            InspectionScopeAndAQLs = new List<InspectionScopeAndAQLModel>();
            SampleInformations = new List<SampleInformationModel>();
            SpecificationsInstructions = new List<SpecificationsInstructionModel>();
            UserForms = new List<UserFormModel>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdminName { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int? Role { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsInspector { get; set; }
        public int IsNew { get; set; }
        public int UserFormId { get; set; }
        public bool IsApproved { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<DropdownBinderModel> dropdownBinderModel { get; set; }
        public List<DropdownBinderModel> dropdownBinderModel1 { get; set; }
        public virtual List<UserFormModel> UserForms { get; set; }
        public virtual List<GeneralInformationModel> GeneralInformations { get; set; }
        public virtual List<InspectionScopeAndAQLModel> InspectionScopeAndAQLs { get; set; }
        public virtual List<SampleInformationModel> SampleInformations { get; set; }
        public virtual List<SpecificationsInstructionModel> SpecificationsInstructions { get; set; }
    }
}
