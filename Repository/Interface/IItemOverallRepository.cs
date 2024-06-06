using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IItemOverallRepository : IGenericRepository<ItemOverall>
    {
        ItemOverall GetItemOverallById(int Id);
        ItemOverall GetItemOverallByReferenceId(int ReferenceId);
        List<ItemOverall> GetAllItemOveralls();
    }
}
