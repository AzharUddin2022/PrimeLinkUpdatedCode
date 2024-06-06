using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IGeneralRemarksListService : IGenericServices<GeneralRemarksListModel, GeneralRemarksList>
    {
        List<GeneralRemarksListModel> GetAllGeneralRemarksLists();
        GeneralRemarksListModel GetGeneralRemarksListById(int id);
        GeneralRemarksListModel GetGeneralRemarksListByReferenceId(int userFormId);
        void InsertUpdateGeneralRemarksList(GeneralRemarksListModel model);
        void DeleteGeneralRemarksList(long Id, int SampleInformationId);
    }
}
