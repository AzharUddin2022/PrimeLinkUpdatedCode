using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IItemOverallService : IGenericServices<ItemOverallModel, ItemOverall>
    {
        List<ItemOverallModel> GetAllItemOveralls();
        ItemOverallModel GetItemOverallById(int id);
        ItemOverallModel GetItemOverallByReferenceId(int userFormId);
        void InsertUpdateItemOverall(ItemOverallModel model);
        void DeleteItemOverall(long Id, int SampleInformationId);
    }
}
