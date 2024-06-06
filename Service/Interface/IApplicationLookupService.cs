using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IApplicationLookupService : IGenericServices<ApplicationLookupModel, ApplicationLookup>
    {
        List<ApplicationLookupModel> GetAllRoles();


    }
}
