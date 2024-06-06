using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IGeneralInformationRepository : IGenericRepository<GeneralInformation>
    {
        GeneralInformation GetGeneralInformationById(int Id);
        GeneralInformation GetGeneralInformationByUserId(int UserId);
        GeneralInformation GetGeneralInformationByUserFormId(int UserFormId);
        List<GeneralInformation> GetAllGeneralInformations();
    }
}
