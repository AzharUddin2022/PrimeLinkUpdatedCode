using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IAttachmentRepository : IGenericRepository<Attachment>
    {
        Attachment GetAttachmentById(int Id);
        List<Attachment> GetAttachmentBySpecificationsInstructionsId(int Id);
        List<Attachment> GetAllAttachments();
    }
}
