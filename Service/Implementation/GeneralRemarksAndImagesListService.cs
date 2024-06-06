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
    public class GeneralRemarksAndImagesListService : GenericServices<GeneralRemarksAndImagesListModel, GeneralRemarksAndImagesList>, IGeneralRemarksAndImagesListService
    {
        #region Private variables
        private readonly IGeneralRemarksAndImagesListRepository _GeneralRemarksAndImagesListRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralRemarksAndImagesListService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _GeneralRemarksAndImagesListRepository = UnitOfWork.GeneralRemarksAndImagesListRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<GeneralRemarksAndImagesListModel> GetAllGeneralRemarksAndImagesLists()
        {
            return MapperHelper.MapList<GeneralRemarksAndImagesListModel, GeneralRemarksAndImagesList>(_GeneralRemarksAndImagesListRepository.GetAllGeneralRemarksAndImagesLists());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneralRemarksAndImagesListModel GetGeneralRemarksAndImagesListById(int id)
        {
            return MapperHelper.Map<GeneralRemarksAndImagesListModel, GeneralRemarksAndImagesList>(_GeneralRemarksAndImagesListRepository.GetGeneralRemarksAndImagesListById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public GeneralRemarksAndImagesListModel GetGeneralRemarksAndImagesListByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<GeneralRemarksAndImagesListModel, GeneralRemarksAndImagesList>(_GeneralRemarksAndImagesListRepository.GetGeneralRemarksAndImagesListByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateGeneralRemarksAndImagesList(GeneralRemarksAndImagesListModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<GeneralRemarksAndImagesList, GeneralRemarksAndImagesListModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _GeneralRemarksAndImagesListRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<GeneralRemarksAndImagesList, GeneralRemarksAndImagesListModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _GeneralRemarksAndImagesListRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteGeneralRemarksAndImagesList(long Id, int GeneralRemarksAndImagesListId)
        {
            var model = _GeneralRemarksAndImagesListRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = GeneralRemarksAndImagesListId;
            //model.UpdatedDate = DateTime.Now;
            _GeneralRemarksAndImagesListRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
