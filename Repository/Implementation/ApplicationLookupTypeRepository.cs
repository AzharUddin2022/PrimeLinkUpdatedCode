using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;

namespace Repository.Implementation
{
    class ApplicationLookupTypeRepository : GenericRepository<ApplicationLookupType>, IApplicationLookupTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ApplicationLookupTypeRepository(DbContext context)
        {
            Context = context;
        }
        #endregion
    }
}
