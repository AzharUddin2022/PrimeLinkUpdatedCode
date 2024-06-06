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
    public class GeneralInformationService : GenericServices<GeneralInformationModel, GeneralInformation>, IGeneralInformationService
    {
        #region Private variables
        private readonly IGeneralInformationRepository _generalInformationRepository;
        private readonly IReferenceRepository _referenceRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IFactoryRepository _factoryRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralInformationService()
        {
            UnitOfWork = new UnitOfWork();
            _referenceRepository = UnitOfWork.ReferenceRepository;
            _vendorRepository = UnitOfWork.VendorRepository;
            _factoryRepository = UnitOfWork.FactoryRepository;
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _generalInformationRepository = UnitOfWork.GeneralInformationRepository;
        }
        #endregion

        #region Get All General Information
        /// <summary>
        /// Get All General Information
        /// </summary>
        /// <returns></returns>
        public List<GeneralInformationModel> GetAllGeneralInformations()
        {
            return MapperHelper.MapList<GeneralInformationModel, GeneralInformation>(_generalInformationRepository.GetAllGeneralInformations());
        }
        #endregion

        #region Get General Information By Id
        /// <summary>
        /// Get General Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneralInformationModel GetGeneralInformationById(int id)
        {
            return MapperHelper.Map<GeneralInformationModel, GeneralInformation>(_generalInformationRepository.GetGeneralInformationById(id));
        }
        #endregion

        #region Get General Information By UserId
        /// <summary>
        /// Get General Information By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneralInformationModel GetGeneralInformationByUserId(int userId)
        {
            return MapperHelper.Map<GeneralInformationModel, GeneralInformation>(_generalInformationRepository.GetGeneralInformationByUserId(userId));
        }
        #endregion

        #region Get General Information By UserFormId
        /// <summary>
        /// Get General Information By UserFormId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneralInformationModel GetGeneralInformationByUserFormId(int userFormId)
        {
            return MapperHelper.Map<GeneralInformationModel, GeneralInformation>(_generalInformationRepository.GetGeneralInformationByUserFormId(userFormId));
        }
        #endregion

        #region Insert Update General Information
        /// <summary>
        /// Insert Update General Information
        /// </summary>
        /// <param name="model"></param>
        public GeneralInformationModel InsertUpdateGeneralInformation(GeneralInformationModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<GeneralInformation, GeneralInformationModel>(model);

                
                mapperModel.References = new List<Reference>();
                mapperModel.DestinationCountry = model.DestinationCountry;
                mapperModel.UserFormId = model.UserFormId;
                mapperModel.MinPercentProductToFinish = model.MinPercentProductToFinish;
                mapperModel.MinPercentProductToFinishAndPacked = model.MinPercentProductToFinishAndPacked;
                mapperModel.ProductCategory = model.ProductCategory;
                mapperModel.ProductLine = model.ProductLine;
                mapperModel.QuantityUnit = model.QuantityUnit;
                mapperModel.ServiceDate = model.ServiceDate;
                mapperModel.ShipmentDate = model.ShipmentDate;
                mapperModel.UserId = model.UserId;
                mapperModel.CreatedBy = model.CreatedBy;
                mapperModel.CreatedDate = model.CreatedDate;
                mapperModel.IsActive = model.IsActive;
                mapperModel.UpdatedBy = model.UpdatedBy;
                mapperModel.UpdatedDate = DateTime.Now;
                _generalInformationRepository.Update(mapperModel);
                _factoryRepository.Update(mapperModel.Factory);
                _vendorRepository.Update(mapperModel.Vendor);
                UnitOfWork.Commit();

                if (model.References != null && model.References.Count > 0)
                {
                    var getReference = _referenceRepository.GetReferenceByGeneralInformationId(model.Id);
                    if (getReference.Count > 0)
                    {
                        foreach (var item in getReference)
                        {
                            //item.IsActive = false;
                            _referenceRepository.Delete(item);
                        }
                    }
                    foreach (var item in model.References)
                    {
                        var reference = new ReferenceModel();
                        reference.IsActive = true;
                        reference.CreatedBy = mapperModel.CreatedBy;
                        reference.CreatedDate = mapperModel.CreatedDate;
                        reference.GeneralInformationId = mapperModel.Id;
                        reference.LevelNo = item.LevelNo;
                        reference.PO = item.PO;
                        reference.SKU = item.SKU;
                        reference.Quantity = item.Quantity;
                        reference.ProductType = item.ProductType;
                        reference.Name = item.Name;
                        _referenceRepository.Save(MapperHelper.Map<Reference, ReferenceModel>(reference));
                    }
                }
                else
                {
                    var getReference = _referenceRepository.GetReferenceByGeneralInformationId(model.Id);
                    if (getReference.Count > 0)
                    {
                        foreach (var item in getReference)
                        {
                            item.IsActive = false;
                            _referenceRepository.Update(item);
                        }
                    }
                }

                UnitOfWork.Commit();

                return MapperHelper.Map<GeneralInformationModel, GeneralInformation>(mapperModel);
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<GeneralInformation, GeneralInformationModel>(model);
                var referenceMapper = MapperHelper.MapList<Reference, ReferenceModel>(model.References);
                //Save

                generalInfoMapper.IsActive = true;
                generalInfoMapper.CreatedDate = DateTime.Now;
                referenceMapper.ForEach(item =>
                {
                    item.IsActive = true;
                    item.CreatedBy = model.CreatedBy;
                    item.CreatedDate = DateTime.Now;
                });
                generalInfoMapper.References = referenceMapper;
                generalInfoMapper.UserFormId = model.UserFormId;
                _generalInformationRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();

                return MapperHelper.Map<GeneralInformationModel, GeneralInformation>(generalInfoMapper);
            }
        }

        public void DeleteGeneralInformation(long Id, int GeneralInformationId)
        {
            var model = _generalInformationRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = GeneralInformationId;
            model.UpdatedDate = DateTime.Now;
            _generalInformationRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
