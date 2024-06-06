using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IGeneralRemarksAndImagesListRepository : IGenericRepository<GeneralRemarksAndImagesList>
    {
        GeneralRemarksAndImagesList GetGeneralRemarksAndImagesListById(int Id);
        GeneralRemarksAndImagesList GetGeneralRemarksAndImagesListByReferenceId(int ReferenceId);
        List<GeneralRemarksAndImagesList> GetAllGeneralRemarksAndImagesLists();
    }
}
