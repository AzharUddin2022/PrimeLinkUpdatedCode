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
    public class ItemAQLDefectsAndRemarkService : GenericServices<ItemAQLDefectsAndRemarkModel, ItemAQLDefectsAndRemark>, IItemAQLDefectsAndRemarkService
    {
        #region Private variables
        private readonly IItemAQLDefectsAndRemarkRepository _ItemAQLDefectsAndRemarkRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemAQLDefectsAndRemarkService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _ItemAQLDefectsAndRemarkRepository = UnitOfWork.ItemAQLDefectsAndRemarkRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<ItemAQLDefectsAndRemarkModel> GetAllItemAQLDefectsAndRemarks()
        {
            return MapperHelper.MapList<ItemAQLDefectsAndRemarkModel, ItemAQLDefectsAndRemark>(_ItemAQLDefectsAndRemarkRepository.GetAllItemAQLDefectsAndRemarks());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemAQLDefectsAndRemarkModel GetItemAQLDefectsAndRemarkById(int id)
        {
            return MapperHelper.Map<ItemAQLDefectsAndRemarkModel, ItemAQLDefectsAndRemark>(_ItemAQLDefectsAndRemarkRepository.GetItemAQLDefectsAndRemarkById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public ItemAQLDefectsAndRemarkModel GetItemAQLDefectsAndRemarkByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<ItemAQLDefectsAndRemarkModel, ItemAQLDefectsAndRemark>(_ItemAQLDefectsAndRemarkRepository.GetItemAQLDefectsAndRemarkByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateItemAQLDefectsAndRemark(ItemAQLDefectsAndRemarkModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<ItemAQLDefectsAndRemark, ItemAQLDefectsAndRemarkModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _ItemAQLDefectsAndRemarkRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<ItemAQLDefectsAndRemark, ItemAQLDefectsAndRemarkModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _ItemAQLDefectsAndRemarkRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteItemAQLDefectsAndRemark(long Id, int ItemAQLDefectsAndRemarkId)
        {
            var model = _ItemAQLDefectsAndRemarkRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = ItemAQLDefectsAndRemarkId;
            //model.UpdatedDate = DateTime.Now;
            _ItemAQLDefectsAndRemarkRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
