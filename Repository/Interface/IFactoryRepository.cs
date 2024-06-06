using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IFactoryRepository : IGenericRepository<Factory>
    {
        Factory GetFactoryById(int Id);
        public Factory GetFactoryByGeneralInformationId(int generalInformationId);
        List<Factory> GetAllFactory();
    }
}
