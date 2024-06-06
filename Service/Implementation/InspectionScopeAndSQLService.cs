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
    public class InspectionScopeAndAQLService : GenericServices<InspectionScopeAndAQLModel, InspectionScopeAndAQL>, IInspectionScopeAndAQLService
    {
        #region Private variables
        private readonly IInspectionScopeAndAQLRepository _inspectionScopeAndAQLRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InspectionScopeAndAQLService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _inspectionScopeAndAQLRepository = UnitOfWork.InspectionScopeAndAQLRepository;
        }
        #endregion

        #region Get All Sample Information
        /// <summary>
        /// Get All Sample Information
        /// </summary>
        /// <returns></returns>
        public List<InspectionScopeAndAQLModel> GetAllInspectionScopeAndAQLs()
        {
            return MapperHelper.MapList<InspectionScopeAndAQLModel, InspectionScopeAndAQL>(_inspectionScopeAndAQLRepository.GetAllInspectionScopeAndAQLs());
        }
        #endregion

        #region Get Sample Information By Id
        /// <summary>
        /// Get Sample Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InspectionScopeAndAQLModel GetInspectionScopeAndAQLById(int id)
        {
            return MapperHelper.Map<InspectionScopeAndAQLModel, InspectionScopeAndAQL>(_inspectionScopeAndAQLRepository.GetInspectionScopeAndAQLById(id));
        }
        #endregion

        #region Get Sample Information By UserId
        /// <summary>
        /// Get Sample Information By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InspectionScopeAndAQLModel GetInspectionScopeAndAQLByUserId(int userId)
        {
            return MapperHelper.Map<InspectionScopeAndAQLModel, InspectionScopeAndAQL>(_inspectionScopeAndAQLRepository.GetInspectionScopeAndAQLByUserId(userId));
        }
        #endregion

        #region Get Sample Information By UserFormId
        /// <summary>
        /// Get Sample Information By UseFormrId
        /// </summary>
        /// <param name="userFormId"></param>
        /// <returns></returns>
        public InspectionScopeAndAQLModel GetInspectionScopeAndAQLByUserFormId(int userFormId)
        {
            return MapperHelper.Map<InspectionScopeAndAQLModel, InspectionScopeAndAQL>(_inspectionScopeAndAQLRepository.GetInspectionScopeAndAQLByUserFormId(userFormId));
        }
        #endregion

        #region Insert Update Sample Information
        /// <summary>
        /// Insert Update Sample Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateInspectionScopeAndAQL(InspectionScopeAndAQLModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<InspectionScopeAndAQL, InspectionScopeAndAQLModel>(model);
                mapperModel.IsFunctionCheck = model.IsFunctionCheck;
                mapperModel.IsQuantityCheck = model.IsQuantityCheck;
                mapperModel.IsPkgePackShipCheck = model.IsPkgePackShipCheck;
                mapperModel.IsProductLabelCheck = model.IsProductLabelCheck;
                mapperModel.IsDimensionCheck = model.IsDimensionCheck;
                mapperModel.PiecesInspected = model.PiecesInspected;
                mapperModel.SamplePlan = model.SamplePlan;
                mapperModel.SampleSize = model.SampleSize;
                mapperModel.CriticalDefects = model.CriticalDefects;
                mapperModel.MajorDefects = model.MajorDefects;
                mapperModel.MinorDefects = model.MinorDefects;
                mapperModel.UserFormId = model.UserFormId;
                mapperModel.UserId = model.UserId;
                mapperModel.CreatedBy = model.CreatedBy;
                mapperModel.CreatedDate = model.CreatedDate;
                mapperModel.IsActive = model.IsActive;
                mapperModel.UpdatedBy = model.UpdatedBy;
                mapperModel.UpdatedDate = DateTime.Now;
                _inspectionScopeAndAQLRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<InspectionScopeAndAQL, InspectionScopeAndAQLModel>(model);
                //Save

                generalInfoMapper.UserFormId = model.UserFormId;
                generalInfoMapper.IsActive = true;
                generalInfoMapper.CreatedDate = DateTime.Now;
                _inspectionScopeAndAQLRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteInspectionScopeAndAQL(long Id, int InspectionScopeAndAQLId)
        {
            var model = _inspectionScopeAndAQLRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = InspectionScopeAndAQLId;
            model.UpdatedDate = DateTime.Now;
            _inspectionScopeAndAQLRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
