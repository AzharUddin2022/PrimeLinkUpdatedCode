
using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IItemRemarkDatumRepository : IGenericRepository<ItemRemarkDatum>
    {
        ItemRemarkDatum GetItemRemarkDatumById(int Id);
        ItemRemarkDatum GetItemRemarkDatumByReferenceId(int ReferenceId);
        List<ItemRemarkDatum> GetAllItemRemarkDatums();
    }
}
