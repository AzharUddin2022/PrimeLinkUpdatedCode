using System;
using System.Collections.Generic;
using Model.Common.Utilities;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class InspectorAllocationService : GenericServices<InspectorAllocationModel, InspectorAllocation>, IInspectorAllocationService
    {
        #region Private variables
        private readonly IInspectorAllocationRepository _inspectorAllocationRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InspectorAllocationService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _inspectorAllocationRepository = UnitOfWork.InspectorAllocationRepository;
        }
        #endregion

        #region Get All InspectorAllocation
        /// <summary>
        /// Get All InspectorAllocation
        /// </summary>
        /// <returns></returns>
        public List<InspectorAllocationModel> GetAllInspectorAllocations()
        {
            return MapperHelper.MapList<InspectorAllocationModel, InspectorAllocation>(_inspectorAllocationRepository.GetAllInspectorAllocations());
        }
        #endregion

        #region Get InspectorAllocation By Id
        /// <summary>
        /// Get InspectorAllocation By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InspectorAllocationModel GetInspectorAllocationById(int id)
        {
            return MapperHelper.Map<InspectorAllocationModel, InspectorAllocation>(_inspectorAllocationRepository.GetInspectorAllocationById(id));
        }
        #endregion

        #region Get InspectorAllocation By UserFormId
        /// <summary>
        /// Get InspectorAllocation By UserFormId
        /// </summary>
        /// <param name="userFormId"></param>
        /// <returns></returns>
        public InspectorAllocationModel GetInspectorAllocationByUserFormId(int userFormId)
        {
            return MapperHelper.Map<InspectorAllocationModel, InspectorAllocation>(_inspectorAllocationRepository.GetInspectorAllocationByUserFormId(userFormId));
        }
        #endregion

        #region Insert Update InspectorAllocation
        /// <summary>
        /// Insert Update InspectorAllocation
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateInspectorAllocation(InspectorAllocationModel model)
        {
            if (model.Id > 0)
            {
                var reasonModel = _inspectorAllocationRepository.FindById(model.Id);
                reasonModel.InspectorId = model.InspectorId;
                reasonModel.UserFormId = model.UserFormId;
                reasonModel.UserId = model.UserId;
                reasonModel.InspectorName = model.InspectorName;
                reasonModel.UserFormName = model.UserFormName;
                reasonModel.CreatedBy = model.CreatedBy;
                reasonModel.CreatedDate = model.CreatedDate;
                reasonModel.IsActive = true;
                reasonModel.UpdatedBy = model.UpdatedBy;
                reasonModel.UpdatedDate = DateTime.Now;
                _inspectorAllocationRepository.Update(reasonModel);
            }
            else
            {
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                _inspectorAllocationRepository.Save(MapperHelper.Map<InspectorAllocation, InspectorAllocationModel>(model));
            }
            UnitOfWork.Commit();
        }

        public void DeleteInspectorAllocation(int Id, int InspectorAllocationId)
        {
            try
            {
                var model = _inspectorAllocationRepository.FindById(Id);
                model.IsActive = false;
                model.UpdatedBy = InspectorAllocationId;
                model.UpdatedDate = DateTime.Now;
                _inspectorAllocationRepository.Update(model);
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
