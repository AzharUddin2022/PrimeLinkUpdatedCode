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
    public class ItemOtherPhotoService : GenericServices<ItemOtherPhotoModel, ItemOtherPhoto>, IItemOtherPhotoService
    {
        #region Private variables
        private readonly IItemOtherPhotoRepository _ItemOtherPhotoRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemOtherPhotoService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _ItemOtherPhotoRepository = UnitOfWork.ItemOtherPhotoRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<ItemOtherPhotoModel> GetAllItemOtherPhotos()
        {
            return MapperHelper.MapList<ItemOtherPhotoModel, ItemOtherPhoto>(_ItemOtherPhotoRepository.GetAllItemOtherPhotos());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemOtherPhotoModel GetItemOtherPhotoById(int id)
        {
            return MapperHelper.Map<ItemOtherPhotoModel, ItemOtherPhoto>(_ItemOtherPhotoRepository.GetItemOtherPhotoById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public ItemOtherPhotoModel GetItemOtherPhotoByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<ItemOtherPhotoModel, ItemOtherPhoto>(_ItemOtherPhotoRepository.GetItemOtherPhotoByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateItemOtherPhoto(ItemOtherPhotoModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<ItemOtherPhoto, ItemOtherPhotoModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _ItemOtherPhotoRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<ItemOtherPhoto, ItemOtherPhotoModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _ItemOtherPhotoRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteItemOtherPhoto(long Id, int ItemOtherPhotoId)
        {
            var model = _ItemOtherPhotoRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = ItemOtherPhotoId;
            //model.UpdatedDate = DateTime.Now;
            _ItemOtherPhotoRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
