using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class User
    {
        public User()
        {
            ClientAttachments = new HashSet<ClientAttachment>();
            GeneralInformations = new HashSet<GeneralInformation>();
            SampleInformations = new HashSet<SampleInformation>();
            SpecificationsInstructions = new HashSet<SpecificationsInstruction>();
            UserForms = new HashSet<UserForm>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Role { get; set; }
        public string Status { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ClientAttachment> ClientAttachments { get; set; }
        public virtual ICollection<GeneralInformation> GeneralInformations { get; set; }
        public virtual ICollection<SampleInformation> SampleInformations { get; set; }
        public virtual ICollection<SpecificationsInstruction> SpecificationsInstructions { get; set; }
        public virtual ICollection<UserForm> UserForms { get; set; }
    }
}
