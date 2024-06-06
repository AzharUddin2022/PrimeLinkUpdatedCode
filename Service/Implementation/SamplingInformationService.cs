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
    public class SamplingInformationService : GenericServices<SamplingInformationModel, SamplingInformation>, ISamplingInformationService
    {
        #region Private variables
        private readonly ISamplingInformationRepository _samplingInformationRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SamplingInformationService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _samplingInformationRepository = UnitOfWork.SamplingInformationRepository;
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<SamplingInformationModel> GetAllSamplingInformations()
        {
            return MapperHelper.MapList<SamplingInformationModel, SamplingInformation>(_samplingInformationRepository.GetAllSamplingInformations());
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SamplingInformationModel GetSamplingInformationById(int id)
        {
            return MapperHelper.Map<SamplingInformationModel, SamplingInformation>(_samplingInformationRepository.GetSamplingInformationById(id));
        }
        #endregion

        #region Get Sampling Information By UserFormId
        /// <summary>
        /// Get Sampling Information By UserFormId
        /// </summary>
        /// <param name="ReferenceId"></param>
        /// <returns></returns>
        public SamplingInformationModel GetSamplingInformationByReferenceId(int ReferenceId)
        {
            return MapperHelper.Map<SamplingInformationModel, SamplingInformation>(_samplingInformationRepository.GetSamplingInformationByReferenceId(ReferenceId));
        }
        #endregion

        #region Insert Update Sampling Information
        /// <summary>
        /// Insert Update Sampling Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateSamplingInformation(SamplingInformationModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<SamplingInformation, SamplingInformationModel>(model);
                //mapperModel.Comment = model.Comment;
                //mapperModel.ContactPerson = model.ContactPerson;
                _samplingInformationRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<SamplingInformation, SamplingInformationModel>(model);
                //Save
                //generalInfoMapper.UserFormId = model.UserFormId;
                //generalInfoMapper.IsActive = true;
                //generalInfoMapper.CreatedDate = DateTime.Now;
                _samplingInformationRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteSamplingInformation(long Id, int SamplingInformationId)
        {
            var model = _samplingInformationRepository.FindById(Id);
            //model.IsActive = false;
            //model.UpdatedBy = SamplingInformationId;
            //model.UpdatedDate = DateTime.Now;
            _samplingInformationRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
