using System;
using System.Collections.Generic;
using Model.Common.Utilities;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class UserService : GenericServices<UserModel, User>, IUserService
    {
        #region Private variables
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _userRepository = UnitOfWork.UserRepository;
        }
        #endregion

        #region Get All User
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetAllUsers()
        {
            return MapperHelper.MapList<UserModel, User>(_userRepository.GetAllUsers());
        }
        #endregion

        #region Get User By Id
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(int id)
        {
            return MapperHelper.Map<UserModel, User>(_userRepository.GetUserById(id));
        }
        #endregion

        #region Return bool if email already exist
        /// <summary>
        /// Return bool if email already exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsEmailAlreadyExist(string email, int Id)
        {
            return _userRepository.IsEmailAlreadyExist(email, Id);
        }
        #endregion

        #region Return bool if username already exist
        /// <summary>
        /// Return bool if username already exist
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsUsernameAlreadyExist(string Username, int Id)
        {
            return _userRepository.IsUsernameAlreadyExist(Username, Id);
        }
        #endregion

        #region Insert Update User
        /// <summary>
        /// Insert Update User
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateUser(UserModel model)
        {
            if (model.Id > 0)
            {
                var reasonModel = _userRepository.FindById(model.Id);
                reasonModel.FirstName = model.FirstName;
                reasonModel.LastName = model.LastName;
                reasonModel.Role = model.Role;
                reasonModel.Password = EncryptionHelper.Encrypt(model.Password);
                reasonModel.PhoneNumber = model.PhoneNumber;
                reasonModel.Timezone = model.Timezone;
                reasonModel.UserName = model.UserName;
                reasonModel.Email = model.Email;
                reasonModel.IsApproved = model.IsApproved;
                reasonModel.CreatedBy = model.CreatedBy;
                reasonModel.CreatedDate = model.CreatedDate;
                reasonModel.IsActive = true;
                reasonModel.Status = model.Status;
                reasonModel.UpdatedBy = model.UpdatedBy;
                reasonModel.UpdatedDate = DateTime.Now;
                _userRepository.Update(reasonModel);
            }
            else
            {
                model.Password = EncryptionHelper.Encrypt(model.Password);
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                _userRepository.Save(MapperHelper.Map<User, UserModel>(model));
            }
            UnitOfWork.Commit();
        }

        public void DeleteUser(int Id, int userId)
        {
            try
            {
                var model = _userRepository.FindById(Id);
                model.Status = "Rejected";
                model.IsActive = false;
                model.UpdatedBy = userId;
                model.UpdatedDate = DateTime.Now;
                _userRepository.Update(model);
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
