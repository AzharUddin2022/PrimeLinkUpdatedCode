using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Entity
{
    public partial class BookingRequirementsResult
    {
        public int ID { get; set; }
        public int ReferenceId { get; set; }
        public string PONumber { get; set; }
        public int ModelNumber { get; set; }
        public string OrderQtyUnits { get; set; }
        public int UnitOrCartoons { get; set; }
        public int AQFinishedAndPackedUnits { get; set; }
        public int AQFinishedAndPackedCartons { get; set; }
        public int AQFinishedButNotPackedUnits { get; set; }
        public int AQNotFinishedPackedUnits { get; set; }
        public string Results { get; set; }
        public string ResultsORRemarks { get; set; }
        public string FilePath { get; set; }

        public int AQTotalFinishedAndPackedUnits { get; set; }
        public int AQTotalFinishedAndPackedCartons { get; set; }
        public int AQTotalFinishedButNotPackedUnits { get; set; }
        public int AQTotalNotFinishedPackedUnits { get; set; }
        
    }
}
