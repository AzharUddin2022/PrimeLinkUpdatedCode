using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IClientAttachmentService : IGenericServices<ClientAttachmentModel, ClientAttachment>
    {
        List<ClientAttachmentModel> GetAllClientAttachment();
        List<ClientAttachmentModel> GetClientAttachmentByUserIdAndUserFormId(int userId, int userFormId);
        List<ClientAttachmentModel> GetClientAttachmentByUserFormId(int userFormId);
        ClientAttachmentModel GetClientAttachmentById(int id);
        void InsertUpdateClientAttachment(List<ClientAttachmentModel> model);
        void DeleteClientAttachment(int Id, int userId);
    }
}
