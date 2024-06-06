using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IItemRemarkDatumService : IGenericServices<ItemRemarkDatumModel, ItemRemarkDatum>
    {
        List<ItemRemarkDatumModel> GetAllItemRemarkDatums();
        ItemRemarkDatumModel GetItemRemarkDatumById(int id);
        ItemRemarkDatumModel GetItemRemarkDatumByReferenceId(int userFormId);
        void InsertUpdateItemRemarkDatum(ItemRemarkDatumModel model);
        void DeleteItemRemarkDatum(long Id, int SampleInformationId);
    }
}
