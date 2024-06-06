using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public VendorRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Vendor By Id
        /// <summary>
        /// Get Vendor By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Vendor GetVendorById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get Vendor By User Id
        /// <summary>
        /// Get Vendor By User Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Vendor GetVendorByGeneralInformationId(int generalInformationId)
        {
            return FindBy(x => x.GeneralInformationId == generalInformationId).FirstOrDefault();
        }
        #endregion

        #region Get All Vendor
        /// <summary>
        /// Get All Vendor
        /// </summary>
        /// <returns></returns>
        public List<Vendor> GetAllVendors()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
