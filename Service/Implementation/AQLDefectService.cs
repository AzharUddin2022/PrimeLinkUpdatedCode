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
    public class AQLDefectService : GenericServices<AQLDefectModel, AQLDefect>, IAQLDefectService
    {
        #region Private variables
        private readonly IAQLDefectRepository _AQLDefectRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AQLDefectService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _AQLDefectRepository = UnitOfWork.AQLDefectRepository;
        }
        #endregion

        #region Get All AQL Defect
        /// <summary>
        /// Get All AQL Defect
        /// </summary>
        /// <returns></returns>
        public List<AQLDefectModel> GetAllAQLDefects()
        {
            return MapperHelper.MapList<AQLDefectModel, AQLDefect>(_AQLDefectRepository.GetAllAQLDefects());
        }
        #endregion

        #region Get AQL Defect By Id
        /// <summary>
        /// Get AQL Defect By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AQLDefectModel GetAQLDefectById(int id)
        {
            return MapperHelper.Map<AQLDefectModel, AQLDefect>(_AQLDefectRepository.GetAQLDefectById(id));
        }
        #endregion

        #region Get AQL Defect By ReferenceId
        /// <summary>
        /// Get AQL Defect By ReferenceId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public AQLDefectModel GetAQLDefectByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<AQLDefectModel, AQLDefect>(_AQLDefectRepository.GetAQLDefectByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update AQL Defect
        /// <summary>
        /// Insert Update AQL Defect
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateAQLDefect(AQLDefectModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<AQLDefect, AQLDefectModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _AQLDefectRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<AQLDefect, AQLDefectModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _AQLDefectRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteAQLDefect(long Id, int AQLDefectId)
        {
            var model = _AQLDefectRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = AQLDefectId;
            //model.UpdatedDate = DateTime.Now;
            _AQLDefectRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
