using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public class SamplingInformationModel
    {
        public int Id { get; set; }
        public int? ReferenceId { get; set; }
        public string TotalCartonsNum { get; set; }
        public string SelectedCartonsNum { get; set; }
    }
}
