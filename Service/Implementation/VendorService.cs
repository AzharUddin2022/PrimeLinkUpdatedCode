using System;
using System.Collections.Generic;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class VendorService : GenericServices<VendorModel, Vendor>, IVendorService
    {
        #region Private variables
        private readonly IVendorRepository _vendorRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VendorService()
        {
            UnitOfWork = new UnitOfWork();
            _vendorRepository = UnitOfWork.VendorRepository;
            GenericRepository = _vendorRepository = UnitOfWork.VendorRepository;
        }
        #endregion

        #region Get All Vendors
        /// <summary>
        /// Get All General Information
        /// </summary>
        /// <returns></returns>
        public List<VendorModel> GetAllVendors()
        {
            return MapperHelper.MapList<VendorModel, Vendor>(_vendorRepository.GetAllVendors());
        }
        #endregion

        #region Get Vendor By Id
        /// <summary>
        /// Get General Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VendorModel GetVendorById(int id)
        {
            return MapperHelper.Map<VendorModel, Vendor>(_vendorRepository.GetVendorById(id));
        }
        #endregion

        #region Get Vendor By UserId
        /// <summary>
        /// Get General Information By UserId
        /// </summary>
        /// <param name="generalInformationId"></param>
        /// <returns></returns>
        public VendorModel GetVendorByGeneralInformationId(int generalInformationId)
        {
            return MapperHelper.Map<VendorModel, Vendor>(_vendorRepository.GetVendorByGeneralInformationId(generalInformationId));
        }
        #endregion

        public void DeleteVendor(long Id, int VendorId)
        {
            var model = _vendorRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = VendorId;
            model.UpdatedDate = DateTime.Now;
            _vendorRepository.Update(model);
            UnitOfWork.Commit();
        }
    }
}
