using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IApplicationLookupRepository : IGenericRepository<ApplicationLookup>
    {
        List<ApplicationLookup> GetAllRoles();
    }
}
