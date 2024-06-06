using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface ISamplingInformationService : IGenericServices<SamplingInformationModel, SamplingInformation>
    {
        List<SamplingInformationModel> GetAllSamplingInformations();
        SamplingInformationModel GetSamplingInformationById(int id);
        SamplingInformationModel GetSamplingInformationByReferenceId(int userFormId);
        void InsertUpdateSamplingInformation(SamplingInformationModel model);
        void DeleteSamplingInformation(long Id, int SampleInformationId);
    }
}
