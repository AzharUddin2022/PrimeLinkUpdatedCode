using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IInnerPackagingService : IGenericServices<InnerPackagingModel, InnerPackaging>
    {
        List<InnerPackagingModel> GetAllInnerPackagings();
        InnerPackagingModel GetInnerPackagingById(int id);
        InnerPackagingModel GetInnerPackagingByReferenceId(int userFormId);
        void InsertUpdateInnerPackaging(InnerPackagingModel model);
        void DeleteInnerPackaging(long Id, int SampleInformationId);
    }
}
