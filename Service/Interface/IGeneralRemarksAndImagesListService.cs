using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IGeneralRemarksAndImagesListService : IGenericServices<GeneralRemarksAndImagesListModel, GeneralRemarksAndImagesList>
    {
        List<GeneralRemarksAndImagesListModel> GetAllGeneralRemarksAndImagesLists();
        GeneralRemarksAndImagesListModel GetGeneralRemarksAndImagesListById(int id);
        GeneralRemarksAndImagesListModel GetGeneralRemarksAndImagesListByReferenceId(int userFormId);
        void InsertUpdateGeneralRemarksAndImagesList(GeneralRemarksAndImagesListModel model);
        void DeleteGeneralRemarksAndImagesList(long Id, int SampleInformationId);
    }
}
