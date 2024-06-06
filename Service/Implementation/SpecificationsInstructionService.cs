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
    public class SpecificationsInstructionService : GenericServices<SpecificationsInstructionModel, SpecificationsInstruction>, ISpecificationsInstructionService
    {
        #region Private variables
        private readonly ISpecificationsInstructionRepository _specificationsInstructionRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SpecificationsInstructionService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _specificationsInstructionRepository = UnitOfWork.SpecificationsInstructionRepository;
        }
        #endregion

        #region Get All Specifications Instruction
        /// <summary>
        /// Get All Specifications Instruction
        /// </summary>
        /// <returns></returns>
        public List<SpecificationsInstructionModel> GetAllSpecificationsInstructions()
        {
            return MapperHelper.MapList<SpecificationsInstructionModel, SpecificationsInstruction>(_specificationsInstructionRepository.GetAllSpecificationsInstructions());
        }
        #endregion

        #region Get Specifications Instruction By Id
        /// <summary>
        /// Get Specifications Instruction By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SpecificationsInstructionModel GetSpecificationsInstructionById(int id)
        {
            return MapperHelper.Map<SpecificationsInstructionModel, SpecificationsInstruction>(_specificationsInstructionRepository.GetSpecificationsInstructionById(id));
        }
        #endregion

        #region Get Specifications Instruction By UserId
        /// <summary>
        /// Get Specifications Instruction By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SpecificationsInstructionModel GetSpecificationsInstructionByUserId(int userId)
        {
            return MapperHelper.Map<SpecificationsInstructionModel, SpecificationsInstruction>(_specificationsInstructionRepository.GetSpecificationsInstructionByUserId(userId));
        }
        #endregion

        #region Get Specifications Instruction By UserFormId
        /// <summary>
        /// Get Specifications Instruction By UserFormId
        /// </summary>
        /// <param name="userFormId"></param>
        /// <returns></returns>
        public SpecificationsInstructionModel GetSpecificationsInstructionByUserFormId(int userFormId)
        {
            return MapperHelper.Map<SpecificationsInstructionModel, SpecificationsInstruction>(_specificationsInstructionRepository.GetSpecificationsInstructionByUserFormId(userFormId));
        }
        #endregion

        #region Insert Update Specifications Instruction
        /// <summary>
        /// Insert Update Specifications Instruction
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateSpecificationsInstruction(SpecificationsInstructionModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<SpecificationsInstruction, SpecificationsInstructionModel>(model);
                mapperModel.FinalReportToPerson = model.FinalReportToPerson;
                mapperModel.FinalReportToVendor = model.FinalReportToVendor;
                mapperModel.IsEmailIncluded = model.IsEmailIncluded;
                mapperModel.IsUrgent = model.IsUrgent;
                mapperModel.MeasurementPoints = model.MeasurementPoints;
                mapperModel.Sizes = model.Sizes;
                mapperModel.UserFormId = model.UserFormId;
                mapperModel.UserId = model.UserId;
                mapperModel.CreatedBy = model.CreatedBy;
                mapperModel.CreatedDate = model.CreatedDate;
                mapperModel.IsActive = model.IsActive;
                mapperModel.UpdatedBy = model.UpdatedBy;
                mapperModel.UpdatedDate = DateTime.Now;
                _specificationsInstructionRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var specificationInstructionMapper = MapperHelper.Map<SpecificationsInstruction, SpecificationsInstructionModel>(model);
                //Save
                specificationInstructionMapper.UserFormId = model.UserFormId;
                specificationInstructionMapper.IsActive = true;
                specificationInstructionMapper.CreatedDate = DateTime.Now;
                _specificationsInstructionRepository.Save(specificationInstructionMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteSpecificationsInstruction(long Id, int specificationsInstructionId)
        {
            var model = _specificationsInstructionRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = specificationsInstructionId;
            model.UpdatedDate = DateTime.Now;
            _specificationsInstructionRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
