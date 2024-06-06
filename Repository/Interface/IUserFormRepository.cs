using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IUserFormRepository : IGenericRepository<UserForm>
    {
        UserForm GetUserFormById(int Id);
        UserForm GetUserFormByUserId(int userId);
        List<UserForm> GetAllUserForms();
    }
}
