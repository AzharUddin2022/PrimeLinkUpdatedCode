using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IRetailPackagingService : IGenericServices<RetailPackagingModel, RetailPackaging>
    {
        List<RetailPackagingModel> GetAllRetailPackagings();
        RetailPackagingModel GetRetailPackagingById(int id);
        RetailPackagingModel GetRetailPackagingByReferenceId(int userFormId);
        void InsertUpdateRetailPackaging(RetailPackagingModel model);
        void DeleteRetailPackaging(long Id, int SampleInformationId);
    }
}
