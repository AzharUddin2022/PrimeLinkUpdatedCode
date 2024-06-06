using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IAQLDefectService : IGenericServices<AQLDefectModel, AQLDefect>
    {
        List<AQLDefectModel> GetAllAQLDefects();
        AQLDefectModel GetAQLDefectById(int id);
        AQLDefectModel GetAQLDefectByReferenceId(int userFormId);
        void InsertUpdateAQLDefect(AQLDefectModel model);
        void DeleteAQLDefect(long Id, int SampleInformationId);
    }
}
