using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IAttachmentService : IGenericServices<AttachmentModel, Attachment>
    {
        List<AttachmentModel> GetAllAttachments();
        AttachmentModel GetAttachmentById(int id);
        List<AttachmentModel> GetAttachmentBySpecificationsInstructionsId(int id);
        void DeleteAttachment(int Id, int AttachmentId);
    }
}
