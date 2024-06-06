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
    public class SampleInformationService : GenericServices<SampleInformationModel, SampleInformation>, ISampleInformationService
    {
        #region Private variables
        private readonly ISampleInformationRepository _sampleInformationRepository;
        private readonly IUserFormRepository _userFormRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SampleInformationService()
        {
            UnitOfWork = new UnitOfWork();
            _userFormRepository = UnitOfWork.UserFormRepository;
            GenericRepository = _sampleInformationRepository = UnitOfWork.SampleInformationRepository;
        }
        #endregion

        #region Get All Sample Information
        /// <summary>
        /// Get All Sample Information
        /// </summary>
        /// <returns></returns>
        public List<SampleInformationModel> GetAllSampleInformations()
        {
            return MapperHelper.MapList<SampleInformationModel, SampleInformation>(_sampleInformationRepository.GetAllSampleInformations());
        }
        #endregion

        #region Get Sample Information By Id
        /// <summary>
        /// Get Sample Information By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SampleInformationModel GetSampleInformationById(int id)
        {
            return MapperHelper.Map<SampleInformationModel, SampleInformation>(_sampleInformationRepository.GetSampleInformationById(id));
        }
        #endregion

        #region Get Sample Information By UserId
        /// <summary>
        /// Get Sample Information By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SampleInformationModel GetSampleInformationByUserId(int userId)
        {
            return MapperHelper.Map<SampleInformationModel, SampleInformation>(_sampleInformationRepository.GetSampleInformationByUserId(userId));
        }
        #endregion

        #region Get Sample Information By UserFormId
        /// <summary>
        /// Get Sample Information By UserFormId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SampleInformationModel GetSampleInformationByUserFormId(int userFormId)
        {
            return MapperHelper.Map<SampleInformationModel, SampleInformation>(_sampleInformationRepository.GetSampleInformationByUserFormId(userFormId));
        }
        #endregion

        #region Insert Update Sample Information
        /// <summary>
        /// Insert Update Sample Information
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateSampleInformation(SampleInformationModel model)
        {

            if (model.Id > 0)
            {
                var mapperModel = MapperHelper.Map<SampleInformation, SampleInformationModel>(model);
                mapperModel.Comment = model.Comment;
                mapperModel.ContactPerson = model.ContactPerson;
                mapperModel.CourierAccountNumber = model.CourierAccountNumber;
                mapperModel.CourierCompanyName = model.CourierCompanyName;
                mapperModel.DeliveryAddress = model.DeliveryAddress;
                mapperModel.Email = model.Email;
                mapperModel.IsCollectSample = model.IsCollectSample;
                mapperModel.IsReferSample = model.IsReferSample;
                mapperModel.PhoneNumber = model.PhoneNumber;
                mapperModel.SendingDestination = model.SendingDestination;
                mapperModel.ToDoAfterInspection = model.ToDoAfterInspection;
                mapperModel.TrackingNumber = model.TrackingNumber;
                mapperModel.UserFormId = model.UserFormId;
                mapperModel.UserId = model.UserId;
                mapperModel.CreatedBy = model.CreatedBy;
                mapperModel.CreatedDate = model.CreatedDate;
                mapperModel.IsActive = model.IsActive;
                mapperModel.UpdatedBy = model.UpdatedBy;
                mapperModel.UpdatedDate = DateTime.Now;
                _sampleInformationRepository.Update(mapperModel);
                UnitOfWork.Commit();
            }
            else
            {
                var generalInfoMapper = MapperHelper.Map<SampleInformation, SampleInformationModel>(model);
                //Save
                generalInfoMapper.UserFormId = model.UserFormId;
                generalInfoMapper.IsActive = true;
                generalInfoMapper.CreatedDate = DateTime.Now;
                _sampleInformationRepository.Save(generalInfoMapper);
                UnitOfWork.Commit();
            }
        }

        public void DeleteSampleInformation(long Id, int SampleInformationId)
        {
            var model = _sampleInformationRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = SampleInformationId;
            model.UpdatedDate = DateTime.Now;
            _sampleInformationRepository.Update(model);
            UnitOfWork.Commit();
        }
        #endregion
    }
}
