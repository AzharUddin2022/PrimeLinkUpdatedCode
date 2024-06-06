using System;
using System.Collections.Generic;
using System.Text;

namespace Component
{
    public class DropdownBinderModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public bool IsFilterable { get; set; }
    }
}
