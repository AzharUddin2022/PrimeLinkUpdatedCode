using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IItemAQLDefectsAndRemarkService : IGenericServices<ItemAQLDefectsAndRemarkModel, ItemAQLDefectsAndRemark>
    {
        List<ItemAQLDefectsAndRemarkModel> GetAllItemAQLDefectsAndRemarks();
        ItemAQLDefectsAndRemarkModel GetItemAQLDefectsAndRemarkById(int id);
        ItemAQLDefectsAndRemarkModel GetItemAQLDefectsAndRemarkByReferenceId(int userFormId);
        void InsertUpdateItemAQLDefectsAndRemark(ItemAQLDefectsAndRemarkModel model);
        void DeleteItemAQLDefectsAndRemark(long Id, int SampleInformationId);
    }
}
