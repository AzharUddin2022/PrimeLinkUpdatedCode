using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IInnerPackagingRepository : IGenericRepository<InnerPackaging>
    {
        InnerPackaging GetInnerPackagingById(int Id);
        InnerPackaging GetInnerPackagingByReferenceId(int ReferenceId);
        List<InnerPackaging> GetAllInnerPackagings();
    }
}
