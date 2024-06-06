using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IRetailPackagingRepository : IGenericRepository<RetailPackaging>
    {
        RetailPackaging GetRetailPackagingById(int Id);
        RetailPackaging GetRetailPackagingByReferenceId(int ReferenceId);
        List<RetailPackaging> GetAllRetailPackagings();
    }
}
