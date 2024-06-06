using Model.Entity;
using Repository.Common.Implementation;
using Repository.Interface;
using Service.Common.Implementation;
using Service.Interface;
using System.Collections.Generic;
using Repository.Entity;
using Service.Common.Helper;

namespace Service.Implementation
{
    public class ApplicationLookupService : GenericServices<ApplicationLookupModel, ApplicationLookup>, IApplicationLookupService
    {
        #region Private variables
        private readonly IApplicationLookupRepository _lookupRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ApplicationLookupService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _lookupRepository = UnitOfWork.ApplicationLookupRepository;
        }
        #endregion

        #region Get All Roles
        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns>List</returns>
        public List<ApplicationLookupModel> GetAllRoles() => MapperHelper.MapList<ApplicationLookupModel, ApplicationLookup>(_lookupRepository.GetAllRoles());
        #endregion
    }
}
