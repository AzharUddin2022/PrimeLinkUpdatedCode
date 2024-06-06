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
    public class ItemOverallService : GenericServices<ItemOverallModel, ItemOverall>, IItemOverallService
    {
        #region Private variables
        private readonly IItemOverallRepository _ItemOverallRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemOverallService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _ItemOverallRepository = UnitOfWork.ItemOverallRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<ItemOverallModel> GetAllItemOveralls()
        {
            return MapperHelper.MapList<ItemOverallModel, ItemOverall>(_ItemOverallRepository.GetAllItemOveralls());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemOverallModel GetItemOverallById(int id)
        {
            return MapperHelper.Map<ItemOverallModel, ItemOverall>(_ItemOverallRepository.GetItemOverallById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public ItemOverallModel GetItemOverallByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<ItemOverallModel, ItemOverall>(_ItemOverallRepository.GetItemOverallByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateItemOverall(ItemOverallModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<ItemOverall, ItemOverallModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _ItemOverallRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<ItemOverall, ItemOverallModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _ItemOverallRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteItemOverall(long Id, int ItemOverallId)
        {
            var model = _ItemOverallRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = ItemOverallId;
            //model.UpdatedDate = DateTime.Now;
            _ItemOverallRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
