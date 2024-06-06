using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IVendorService : IGenericServices<VendorModel, Vendor>
    {
        List<VendorModel> GetAllVendors();
        VendorModel GetVendorById(int id);
        public VendorModel GetVendorByGeneralInformationId(int userId);
        void DeleteVendor(long Id, int VendorId);
    }
}
