using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.Utilities
{
    public class APIResponseModel
    {
        public string cdnUri { get; set; }
        public string origFileName { get; set; }
        public string uploadedFileName { get; set; }
        public string filePath { get; set; }
        public string fileSize { get; set; }
    }
}
