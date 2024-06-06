using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IUserFormService : IGenericServices<UserFormModel, UserForm>
    {
        List<UserFormModel> GetAllUserForms();
        UserFormModel GetUserFormById(int id);
        UserFormModel GetUserFormByUserId(int userId);
        UserFormModel InsertUpdateUserForm(UserFormModel model);
        void DeleteUserForm(int Id, int UserFormId);
    }
}
