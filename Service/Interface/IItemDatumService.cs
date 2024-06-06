using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IItemDatumService : IGenericServices<ItemDatumModel, ItemDatum>
    {
        List<ItemDatumModel> GetAllItemDatums();
        ItemDatumModel GetItemDatumById(int id);
        ItemDatumModel GetItemDatumByReferenceId(int userFormId);
        void InsertUpdateItemDatum(ItemDatumModel model);
        void DeleteItemDatum(long Id, int SampleInformationId);
    }
}
