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
    public class ClientAttachmentService : GenericServices<ClientAttachmentModel, ClientAttachment>, IClientAttachmentService
    {
        #region Private variables
        private readonly IClientAttachmentRepository _clientAttachmentRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ClientAttachmentService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _clientAttachmentRepository = UnitOfWork.ClientAttachmentRepository;
        }
        #endregion

        #region Get All Client Attachment
        /// <summary>
        /// Get All Client Attachment
        /// </summary>
        /// <returns></returns>
        public List<ClientAttachmentModel> GetAllClientAttachment()
        {
            return MapperHelper.MapList<ClientAttachmentModel, ClientAttachment>(_clientAttachmentRepository.GetAllClientAttachment());
        }
        #endregion

        #region Get Client Attachment By Id
        /// <summary>
        /// Get Client Attachment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientAttachmentModel GetClientAttachmentById(int id)
        {
            return MapperHelper.Map<ClientAttachmentModel, ClientAttachment>(_clientAttachmentRepository.GetClientAttachmentById(id));
        }
        #endregion

        #region Get Client Attachment By UserFormId
        /// <summary>
        /// Get Client Attachment By UserFormId
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserFormId"></param>
        /// <returns></returns>
        public List<ClientAttachmentModel> GetClientAttachmentByUserFormId(int userFormId)
        {
            return MapperHelper.MapList<ClientAttachmentModel, ClientAttachment>(_clientAttachmentRepository.GetClientAttachmentByUserFormId(userFormId));
        }
        #endregion

        #region Get Client Attachment By UserId and UserFormId
        /// <summary>
        /// Get Client Attachment By UserId and UserFormId
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserFormId"></param>
        /// <returns></returns>
        public List<ClientAttachmentModel> GetClientAttachmentByUserIdAndUserFormId(int userId, int userFormId)
        {
            return MapperHelper.MapList<ClientAttachmentModel, ClientAttachment>(_clientAttachmentRepository.GetClientAttachmentByUserIdAndUserFormId(userId, userFormId));
        }
        #endregion

        #region Insert Update Client Attachment
        /// <summary>
        /// Insert Update Client Attachment
        /// </summary>
        /// <param name="model"></param>
        public void InsertUpdateClientAttachment(List<ClientAttachmentModel> model)
        {
            foreach (var item in model)
            {
                item.CreatedDate = DateTime.Now;
                _clientAttachmentRepository.Save(MapperHelper.Map<ClientAttachment, ClientAttachmentModel>(item));
            }
            UnitOfWork.Commit();
        }

        public void DeleteClientAttachment(int Id, int userId)
        {
            try
            {
                var model = _clientAttachmentRepository.FindById(Id);
                _clientAttachmentRepository.Delete(model);
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
