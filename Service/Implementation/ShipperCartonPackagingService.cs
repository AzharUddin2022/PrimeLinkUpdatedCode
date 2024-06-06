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
    public class ShipperCartonPackagingService : GenericServices<ShipperCartonPackagingModel, ShipperCartonPackaging>, IShipperCartonPackagingService
    {
        #region Private variables
        private readonly IShipperCartonPackagingRepository _shipperCartonPackagingRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ShipperCartonPackagingService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _shipperCartonPackagingRepository = UnitOfWork.ShipperCartonPackagingRepository;
        }
        #endregion

        #region Get All Shipper Carton Packaging
        /// <summary>
        /// Get All Shipper Carton Packaging
        /// </summary>
        /// <returns></returns>
        public List<ShipperCartonPackagingModel> GetAllShipperCartonPackagings()
        {
            return MapperHelper.MapList<ShipperCartonPackagingModel, ShipperCartonPackaging>(_shipperCartonPackagingRepository.GetAllShipperCartonPackagings());
        }
        #endregion

        #region Get Shipper Carton Packaging By Id
        /// <summary>
        /// Get Shipper Carton Packaging By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShipperCartonPackagingModel GetShipperCartonPackagingById(int id)
        {
            return MapperHelper.Map<ShipperCartonPackagingModel, ShipperCartonPackaging>(_shipperCartonPackagingRepository.GetShipperCartonPackagingById(id));
        }
        #endregion

        #region Get Shipper Carton Packaging By UserFormId
        /// <summary>
        /// Get Shipper Carton Packaging By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public ShipperCartonPackagingModel GetShipperCartonPackagingByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<ShipperCartonPackagingModel, ShipperCartonPackaging>(_shipperCartonPackagingRepository.GetShipperCartonPackagingByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Shipper Carton Packaging
        /// <summary>
        /// Insert Update Shipper Carton Packaging
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateShipperCartonPackaging(ShipperCartonPackagingModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<ShipperCartonPackaging, ShipperCartonPackagingModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _shipperCartonPackagingRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<ShipperCartonPackaging, ShipperCartonPackagingModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _shipperCartonPackagingRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteShipperCartonPackaging(long Id, int ShipperCartonPackagingId)
        {
            var model = _shipperCartonPackagingRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = ShipperCartonPackagingId;
            //model.UpdatedDate = DateTime.Now;
            _shipperCartonPackagingRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
