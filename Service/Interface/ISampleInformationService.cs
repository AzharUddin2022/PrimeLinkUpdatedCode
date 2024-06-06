using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface ISampleInformationService : IGenericServices<SampleInformationModel, SampleInformation>
    {
        List<SampleInformationModel> GetAllSampleInformations();
        SampleInformationModel GetSampleInformationById(int id);
        SampleInformationModel GetSampleInformationByUserId(int userId);
        SampleInformationModel GetSampleInformationByUserFormId(int userFormId);
        void InsertUpdateSampleInformation(SampleInformationModel model);
        void DeleteSampleInformation(long Id, int SampleInformationId);
    }
}
