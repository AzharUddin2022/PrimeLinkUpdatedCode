using Model.Entity;
using Repository.Common.Implementation;
using Repository.Interface;
using Service.Common.Implementation;
using Service.Interface;
using Repository.Entity;

namespace Service.Implementation
{
    public class ApplicationLookupTypeService : GenericServices<ApplicationLookupTypeModel,ApplicationLookupType>, IApplicationLookupTypeService
    {
        #region Private variables
        private readonly IApplicationLookupTypeRepository _lookupTypeRespository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ApplicationLookupTypeService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _lookupTypeRespository = UnitOfWork.ApplicationLookupTypeRepository;
        }
        #endregion

    }
}
