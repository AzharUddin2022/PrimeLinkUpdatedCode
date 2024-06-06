using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IGeneralInformationService : IGenericServices<GeneralInformationModel, GeneralInformation>
    {
        List<GeneralInformationModel> GetAllGeneralInformations();
        GeneralInformationModel GetGeneralInformationById(int id);
        GeneralInformationModel GetGeneralInformationByUserId(int userId);
        GeneralInformationModel GetGeneralInformationByUserFormId(int userFormId);
        GeneralInformationModel InsertUpdateGeneralInformation(GeneralInformationModel model);
        void DeleteGeneralInformation(long Id, int GeneralInformationId);
    }
}
