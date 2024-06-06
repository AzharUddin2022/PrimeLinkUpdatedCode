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
    public class OnSiteTestResultService : GenericServices<OnSiteTestResultModel, OnSiteTestResult>, IOnSiteTestResultService
    {
        #region Private variables
        private readonly IOnSiteTestResultRepository _onSiteTestResultRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OnSiteTestResultService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _onSiteTestResultRepository = UnitOfWork.OnSiteTestResultRepository;
        }
        #endregion

        #region Get All OnSite Test Results
        /// <summary>
        /// Get All OnSite Test Results
        /// </summary>
        /// <returns></returns>
        public List<OnSiteTestResultModel> GetAllOnSiteTestResults()
        {
            return MapperHelper.MapList<OnSiteTestResultModel, OnSiteTestResult>(_onSiteTestResultRepository.GetAllOnSiteTestResults());
        }
        #endregion

        #region Get OnSite Test Results By Id
        /// <summary>
        /// Get OnSite Test Results By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OnSiteTestResultModel GetOnSiteTestResultById(int id)
        {
            return MapperHelper.Map<OnSiteTestResultModel, OnSiteTestResult>(_onSiteTestResultRepository.GetOnSiteTestResultById(id));
        }
        #endregion

        #region Get OnSite Test Results By UserFormId
        /// <summary>
        /// Get OnSite Test Results By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public OnSiteTestResultModel GetOnSiteTestResultByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<OnSiteTestResultModel, OnSiteTestResult>(_onSiteTestResultRepository.GetOnSiteTestResultByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update OnSite Test Results
        /// <summary>
        /// Insert Update OnSite Test Results
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateOnSiteTestResult(OnSiteTestResultModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<OnSiteTestResult, OnSiteTestResultModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _onSiteTestResultRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<OnSiteTestResult, OnSiteTestResultModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _onSiteTestResultRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteOnSiteTestResult(long Id, int OnSiteTestResultId)
        {
            var model = _onSiteTestResultRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = OnSiteTestResultId;
            //model.UpdatedDate = DateTime.Now;
            _onSiteTestResultRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
