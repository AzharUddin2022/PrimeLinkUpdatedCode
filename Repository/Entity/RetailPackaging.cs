using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class RetailPackaging
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string RetailPackagingPrintings { get; set; }
        public string RetailPackagingUserInstructions { get; set; }
        public string RetailPackagingMethods { get; set; }
    }
}
