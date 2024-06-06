using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IUserService : IGenericServices<UserModel, User>
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        bool IsEmailAlreadyExist(string email, int Id);
        bool IsUsernameAlreadyExist(string Username, int Id);
        void InsertUpdateUser(UserModel model);
        void DeleteUser(int Id, int userId);
    }
}
