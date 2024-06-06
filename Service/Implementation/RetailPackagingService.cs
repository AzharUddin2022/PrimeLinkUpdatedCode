using System;
using System.Collections.Generic;
using System.Linq;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class RetailPackagingService : GenericServices<RetailPackagingModel, RetailPackaging>, IRetailPackagingService
    {
        #region Private variables
        private readonly IRetailPackagingRepository _retailPackagingRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RetailPackagingService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _retailPackagingRepository = UnitOfWork.RetailPackagingRepository;
        }
        #endregion

        #region Get All Retail Packaging
        /// <summary>
        /// Get All Retail Packaging
        /// </summary>
        /// <returns></returns>
        public List<RetailPackagingModel> GetAllRetailPackagings()
        {
            return MapperHelper.MapList<RetailPackagingModel, RetailPackaging>(_retailPackagingRepository.GetAllRetailPackagings());
        }
        #endregion

        #region Get Retail Packaging By Id
        /// <summary>
        /// Get Retail Packaging By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RetailPackagingModel GetRetailPackagingById(int id)
        {
            return MapperHelper.Map<RetailPackagingModel, RetailPackaging>(_retailPackagingRepository.GetRetailPackagingById(id));
        }
        #endregion

        #region Get Retail Packaging By ReferenceId
        /// <summary>
        /// Get Retail Packaging By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public RetailPackagingModel GetRetailPackagingByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<RetailPackagingModel, RetailPackaging>(_retailPackagingRepository.GetRetailPackagingByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Retail Packaging
        /// <summary>
        /// Insert Update Retail Packaging
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateRetailPackaging(RetailPackagingModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<RetailPackaging, RetailPackagingModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _retailPackagingRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<RetailPackaging, RetailPackagingModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _retailPackagingRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteRetailPackaging(long Id, int RetailPackagingId)
        {
            var model = _retailPackagingRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = RetailPackagingId;
            //model.UpdatedDate = DateTime.Now;
            _retailPackagingRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
