using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IClientAttachmentRepository : IGenericRepository<ClientAttachment>
    {
        ClientAttachment GetClientAttachmentById(int Id);
        List<ClientAttachment> GetAllClientAttachment();
        List<ClientAttachment> GetClientAttachmentByUserIdAndUserFormId(int userId, int userFormId);
        List<ClientAttachment> GetClientAttachmentByUserFormId(int userFormId);
    }
}
