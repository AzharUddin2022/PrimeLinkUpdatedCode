using System;
using System.Collections.Generic;
using Component;
using Model.Common.Utilities;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Common.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class ReferenceService : GenericServices<ReferenceModel, Reference>, IReferenceService
    {
        #region Private variables
        private readonly IReferenceRepository _ReferenceRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ReferenceService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _ReferenceRepository = UnitOfWork.ReferenceRepository;
        }
        #endregion

        #region Get All Reference
        /// <summary>
        /// Get All Reference
        /// </summary>
        /// <returns></returns>
        public List<ReferenceModel> GetAllReferences()
        {
            return MapperHelper.MapList<ReferenceModel, Reference>(_ReferenceRepository.GetAllReferences());
        }
        #endregion

        #region Get Reference By Id
        /// <summary>
        /// Get Reference By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReferenceModel GetReferenceById(int id)
        {
            return MapperHelper.Map<ReferenceModel, Reference>(_ReferenceRepository.GetReferenceById(id));
        }
        #endregion

        #region Get Reference By General Information Id
        /// <summary>
        /// Get Reference By General Information Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ReferenceModel> GetReferenceByGeneralInformationId(int id)
        {
            return MapperHelper.MapList<ReferenceModel, Reference>(_ReferenceRepository.GetReferenceByGeneralInformationId(id));
        }
        #endregion

        #region Insert Update Reference
        /// <summary>
        /// Insert Update Reference
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateReference(ReferenceModel model)
        {
            if (model.Id > 0)
            {
                var reasonModel = _ReferenceRepository.FindById(model.Id);
                reasonModel.Name = model.Name;
                reasonModel.PO = model.PO;
                reasonModel.SKU = model.SKU;
                reasonModel.Quantity = model.Quantity;
                reasonModel.ProductType = model.ProductType;
                reasonModel.CreatedBy = model.CreatedBy;
                reasonModel.CreatedDate = model.CreatedDate;
                reasonModel.CreatedBy = model.CreatedBy;
                reasonModel.IsActive = model.IsActive;
                reasonModel.UpdatedBy = model.UpdatedBy;
                reasonModel.UpdatedDate = DateTime.Now;
                _ReferenceRepository.Update(reasonModel);
            }
            else
            {
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                _ReferenceRepository.Save(MapperHelper.Map<Reference, ReferenceModel>(model));
            }
            UnitOfWork.Commit();
        }

        public void DeleteReference(long Id, int ReferenceId)
        {
            var model = _ReferenceRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = ReferenceId;
            model.UpdatedDate = DateTime.Now;
            _ReferenceRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
