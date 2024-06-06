using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IReferenceService : IGenericServices<ReferenceModel, Reference>
    {
        List<ReferenceModel> GetAllReferences();
        ReferenceModel GetReferenceById(int id);
        List<ReferenceModel> GetReferenceByGeneralInformationId(int id);
        void InsertUpdateReference(ReferenceModel model);
        void DeleteReference(long Id, int ReferenceId);
    }
}
