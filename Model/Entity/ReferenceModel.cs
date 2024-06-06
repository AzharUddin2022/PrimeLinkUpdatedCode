using Microsoft.AspNetCore.Http;
using System;

namespace Model.Entity
{
    public class ReferenceModel
    {
        public int Id { get; set; }
        public int? GeneralInformationId { get; set; }
        public string PO { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public long? Quantity { get; set; }
        public string ProductType { get; set; }
        public int? LevelNo { get; set; }
        public int i { get; set; }
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool IsApproved { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual GeneralInformationModel GeneralInformation { get; set; }
    }
}
