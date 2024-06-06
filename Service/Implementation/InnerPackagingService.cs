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
    public class InnerPackagingService : GenericServices<InnerPackagingModel, InnerPackaging>, IInnerPackagingService
    {
        #region Private variables
        private readonly IInnerPackagingRepository _InnerPackagingRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InnerPackagingService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _InnerPackagingRepository = UnitOfWork.InnerPackagingRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<InnerPackagingModel> GetAllInnerPackagings()
        {
            return MapperHelper.MapList<InnerPackagingModel, InnerPackaging>(_InnerPackagingRepository.GetAllInnerPackagings());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InnerPackagingModel GetInnerPackagingById(int id)
        {
            return MapperHelper.Map<InnerPackagingModel, InnerPackaging>(_InnerPackagingRepository.GetInnerPackagingById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public InnerPackagingModel GetInnerPackagingByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<InnerPackagingModel, InnerPackaging>(_InnerPackagingRepository.GetInnerPackagingByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateInnerPackaging(InnerPackagingModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<InnerPackaging, InnerPackagingModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _InnerPackagingRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<InnerPackaging, InnerPackagingModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _InnerPackagingRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteInnerPackaging(long Id, int InnerPackagingId)
        {
            var model = _InnerPackagingRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = InnerPackagingId;
            //model.UpdatedDate = DateTime.Now;
            _InnerPackagingRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
