using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserById(int Id);
        List<User> GetAllUsers();
        bool IsEmailAlreadyExist(string email, int Id);
        bool IsUsernameAlreadyExist(string Username, int Id);
    }
}
