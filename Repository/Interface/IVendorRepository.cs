using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IVendorRepository : IGenericRepository<Vendor>
    {
        Vendor GetVendorById(int Id);
        public Vendor GetVendorByGeneralInformationId(int generalInformationId);
        List<Vendor> GetAllVendors();
    }
}
