using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IItemDatumRepository : IGenericRepository<ItemDatum>
    {
        ItemDatum GetItemDatumById(int Id);
        ItemDatum GetItemDatumByReferenceId(int ReferenceId);
        List<ItemDatum> GetAllItemDatums();
    }
}
