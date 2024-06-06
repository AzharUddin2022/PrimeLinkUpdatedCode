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
    public class AttachmentService : GenericServices<AttachmentModel, Attachment>, IAttachmentService
    {
        #region Private variables
        private readonly IAttachmentRepository _AttachmentRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AttachmentService()
        {
            UnitOfWork = new UnitOfWork();
            GenericRepository = _AttachmentRepository = UnitOfWork.AttachmentRepository;
        }
        #endregion

        #region Get All Attachment
        /// <summary>
        /// Get All Attachment
        /// </summary>
        /// <returns></returns>
        public List<AttachmentModel> GetAllAttachments()
        {
            return MapperHelper.MapList<AttachmentModel, Attachment>(_AttachmentRepository.GetAllAttachments());
        }
        #endregion

        #region Get Attachment By Id
        /// <summary>
        /// Get Attachment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AttachmentModel GetAttachmentById(int id)
        {
            return MapperHelper.Map<AttachmentModel, Attachment>(_AttachmentRepository.GetAttachmentById(id));
        }
        #endregion

        #region Get Attachment By Specifications Instructions Id
        /// <summary>
        /// Get Attachment By Specifications Instructions Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<AttachmentModel> GetAttachmentBySpecificationsInstructionsId(int id)
        {
            return MapperHelper.MapList<AttachmentModel, Attachment>(_AttachmentRepository.GetAttachmentBySpecificationsInstructionsId(id));
        }
        #endregion

        public void DeleteAttachment(int Id, int AttachmentId)
        {
            var model = _AttachmentRepository.FindById(Id);
            if (model != null) 
            {
                _AttachmentRepository.Delete(model);
            }
            UnitOfWork.Commit();
        }
    }
}
