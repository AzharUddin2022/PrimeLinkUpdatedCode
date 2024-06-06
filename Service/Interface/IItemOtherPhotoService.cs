using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IItemOtherPhotoService : IGenericServices<ItemOtherPhotoModel, ItemOtherPhoto>
    {
        List<ItemOtherPhotoModel> GetAllItemOtherPhotos();
        ItemOtherPhotoModel GetItemOtherPhotoById(int id);
        ItemOtherPhotoModel GetItemOtherPhotoByReferenceId(int userFormId);
        void InsertUpdateItemOtherPhoto(ItemOtherPhotoModel model);
        void DeleteItemOtherPhoto(long Id, int SampleInformationId);
    }
}
