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
    public class ItemDatumService : GenericServices<ItemDatumModel, ItemDatum>, IItemDatumService
    {
        #region Private variables
        private readonly IItemDatumRepository _ItemDatumRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemDatumService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _ItemDatumRepository = UnitOfWork.ItemDatumRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<ItemDatumModel> GetAllItemDatums()
        {
            return MapperHelper.MapList<ItemDatumModel, ItemDatum>(_ItemDatumRepository.GetAllItemDatums());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemDatumModel GetItemDatumById(int id)
        {
            return MapperHelper.Map<ItemDatumModel, ItemDatum>(_ItemDatumRepository.GetItemDatumById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public ItemDatumModel GetItemDatumByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<ItemDatumModel, ItemDatum>(_ItemDatumRepository.GetItemDatumByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateItemDatum(ItemDatumModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<ItemDatum, ItemDatumModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _ItemDatumRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<ItemDatum, ItemDatumModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _ItemDatumRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteItemDatum(long Id, int ItemDatumId)
        {
            var model = _ItemDatumRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = ItemDatumId;
            //model.UpdatedDate = DateTime.Now;
            _ItemDatumRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
