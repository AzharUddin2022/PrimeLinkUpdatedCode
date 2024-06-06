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
    public class ItemRemarkDatumService : GenericServices<ItemRemarkDatumModel, ItemRemarkDatum>, IItemRemarkDatumService
    {
        #region Private variables
        private readonly IItemRemarkDatumRepository _ItemRemarkDatumRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemRemarkDatumService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _ItemRemarkDatumRepository = UnitOfWork.ItemRemarkDatumRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<ItemRemarkDatumModel> GetAllItemRemarkDatums()
        {
            return MapperHelper.MapList<ItemRemarkDatumModel, ItemRemarkDatum>(_ItemRemarkDatumRepository.GetAllItemRemarkDatums());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemRemarkDatumModel GetItemRemarkDatumById(int id)
        {
            return MapperHelper.Map<ItemRemarkDatumModel, ItemRemarkDatum>(_ItemRemarkDatumRepository.GetItemRemarkDatumById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public ItemRemarkDatumModel GetItemRemarkDatumByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<ItemRemarkDatumModel, ItemRemarkDatum>(_ItemRemarkDatumRepository.GetItemRemarkDatumByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateItemRemarkDatum(ItemRemarkDatumModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<ItemRemarkDatum, ItemRemarkDatumModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _ItemRemarkDatumRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<ItemRemarkDatum, ItemRemarkDatumModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _ItemRemarkDatumRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteItemRemarkDatum(long Id, int ItemRemarkDatumId)
        {
            var model = _ItemRemarkDatumRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = ItemRemarkDatumId;
            //model.UpdatedDate = DateTime.Now;
            _ItemRemarkDatumRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
