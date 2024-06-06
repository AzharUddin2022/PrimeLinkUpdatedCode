using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IItemOtherPhotoRepository : IGenericRepository<ItemOtherPhoto>
    {
        ItemOtherPhoto GetItemOtherPhotoById(int Id);
        ItemOtherPhoto GetItemOtherPhotoByReferenceId(int ReferenceId);
        List<ItemOtherPhoto> GetAllItemOtherPhotos();
    }
}
