using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IItemAQLDefectsAndRemarkRepository : IGenericRepository<ItemAQLDefectsAndRemark>
    {
        ItemAQLDefectsAndRemark GetItemAQLDefectsAndRemarkById(int Id);
        ItemAQLDefectsAndRemark GetItemAQLDefectsAndRemarkByReferenceId(int ReferenceId);
        List<ItemAQLDefectsAndRemark> GetAllItemAQLDefectsAndRemarks();
    }
}
