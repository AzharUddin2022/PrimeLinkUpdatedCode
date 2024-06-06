using System;
using System.Collections.Generic;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class UserFormService : GenericServices<UserFormModel, UserForm>, IUserFormService
    {
        #region Private variables
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserFormService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _userFormRepository = UnitOfWork.UserFormRepository;
        }
        #endregion

        #region Get All UserForm
        /// <summary>
        /// Get All UserForm
        /// </summary>
        /// <returns></returns>
        public List<UserFormModel> GetAllUserForms()
        {
            return MapperHelper.MapList<UserFormModel, UserForm>(_userFormRepository.GetAllUserForms());
        }
        #endregion

        #region Get UserForm By Id
        /// <summary>
        /// Get UserForm By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserFormModel GetUserFormById(int id)
        {
            return MapperHelper.Map<UserFormModel, UserForm>(_userFormRepository.GetUserFormById(id));
        }
        #endregion

        #region Insert Update UserForm
        /// <summary>
        /// Insert Update UserForm
        /// </summary>
        /// <param name="model"></param>
        public UserFormModel InsertUpdateUserForm(UserFormModel model)
        {
            if (model.Id > 0)
            {
                var reasonModel = _userFormRepository.FindById(model.Id);
                reasonModel.UserId = model.UserId;
                reasonModel.IsApproved = model.IsApproved;
                reasonModel.CreatedBy = model.CreatedBy;
                reasonModel.CreatedDate = model.CreatedDate;
                reasonModel.IsActive = true;
                reasonModel.UpdatedBy = model.UpdatedBy;
                reasonModel.UpdatedDate = DateTime.Now;
                _userFormRepository.Update(reasonModel);
                UnitOfWork.Commit();
                return MapperHelper.Map<UserFormModel, UserForm>(reasonModel);
            }
            else
            {
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                var entityModel = MapperHelper.Map<UserForm, UserFormModel>(model);
                _userFormRepository.Save(entityModel);
                UnitOfWork.Commit();
                return MapperHelper.Map<UserFormModel, UserForm>(entityModel);
            }
        }
        #endregion
        public void DeleteUserForm(int Id, int UserFormId)
        {
            try
            {
                var model = _userFormRepository.FindById(Id);
                model.IsActive = false;
                model.UpdatedBy = UserFormId;
                model.UpdatedDate = DateTime.Now;
                _userFormRepository.Update(model);
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public UserFormModel GetUserFormByUserId(int userId)
        {
            return MapperHelper.Map<UserFormModel, UserForm>(_userFormRepository.GetUserFormByUserId(userId));
        }
        
    }
}
