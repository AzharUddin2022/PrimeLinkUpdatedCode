using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IFactoryService : IGenericServices<FactoryModel, Factory>
    {
        List<FactoryModel> GetAllFactory();
        FactoryModel GetFactoryById(int id);
        public FactoryModel GetFactoryByGeneralInformationId(int generalInformationId);
        void DeleteFactory(long Id, int FactoryId);
    }
}
