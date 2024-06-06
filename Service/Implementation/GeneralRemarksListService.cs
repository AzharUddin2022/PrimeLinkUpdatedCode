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
    public class GeneralRemarksListService : GenericServices<GeneralRemarksListModel, GeneralRemarksList>, IGeneralRemarksListService
    {
        #region Private variables
        private readonly IGeneralRemarksListRepository _GeneralRemarksListRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralRemarksListService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _GeneralRemarksListRepository = UnitOfWork.GeneralRemarksListRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<GeneralRemarksListModel> GetAllGeneralRemarksLists()
        {
            return MapperHelper.MapList<GeneralRemarksListModel, GeneralRemarksList>(_GeneralRemarksListRepository.GetAllGeneralRemarksLists());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneralRemarksListModel GetGeneralRemarksListById(int id)
        {
            return MapperHelper.Map<GeneralRemarksListModel, GeneralRemarksList>(_GeneralRemarksListRepository.GetGeneralRemarksListById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public GeneralRemarksListModel GetGeneralRemarksListByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<GeneralRemarksListModel, GeneralRemarksList>(_GeneralRemarksListRepository.GetGeneralRemarksListByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateGeneralRemarksList(GeneralRemarksListModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<GeneralRemarksList, GeneralRemarksListModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _GeneralRemarksListRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<GeneralRemarksList, GeneralRemarksListModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _GeneralRemarksListRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteGeneralRemarksList(long Id, int GeneralRemarksListId)
        {
            var model = _GeneralRemarksListRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = GeneralRemarksListId;
            //model.UpdatedDate = DateTime.Now;
            _GeneralRemarksListRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
