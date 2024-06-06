using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Interface;
using System.Collections.Generic;
using Repository.Entity;
using Model.Common.Helper;
using System.Linq;

namespace Repository.Implementation
{
    public class ApplicationLookupRepository : GenericRepository<ApplicationLookup>, IApplicationLookupRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ApplicationLookupRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get All Roles
        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public List<ApplicationLookup> GetAllRoles()
        {
            return FindBy(lookup => (lookup.IsActive == true) && (lookup.TypeId == 1))
                .Select(model => new ApplicationLookup
                {
                    Name = model.Name,
                    SeqKey = model.SeqKey
                }).ToList();
        }
        #endregion
    }
}
