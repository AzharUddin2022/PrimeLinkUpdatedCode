using Repository.Entity;
using System.Collections.Generic;

namespace PrimLink.Helper
{
    public class ReportModel
    {
        public List<ImportantRemark> listImportantRemark { get; set; }
        public List<CustomerSpecialCheckpoint> listCustomerSpecialCheckpoint { get; set; }
        public List<SamplingInformation> listSamplingInformation { get; set; }
        public List<InspectionStandardResult> listInspectionStandardResult { get; set; }
        public List<YourProduct> listYourProduct { get; set; }

    }
}
