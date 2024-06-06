using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class ClientAttachmentRepository : GenericRepository<ClientAttachment>, IClientAttachmentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ClientAttachmentRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Client Attachment By Id
        /// <summary>
        /// Get Client Attachment By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ClientAttachment GetClientAttachmentById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get All Client Attachment
        /// <summary>
        /// Get All Client Attachment
        /// </summary>
        /// <returns></returns>
        public List<ClientAttachment> GetAllClientAttachment()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion

        #region Get All Client Attachment By UserId And UserFormId
        /// <summary>
        /// Get All Client Attachment By UserId And UserFormId
        /// </summary>
        /// <returns></returns>
        public List<ClientAttachment> GetClientAttachmentByUserIdAndUserFormId(int userId, int userFormId)
        {
            return FindBy(x => x.UserId == userId && x.UserFormId == userFormId).ToList();
        }
        #endregion

        #region Get All Client Attachment By UserFormId
        /// <summary>
        /// Get All Client Attachment By UserFormId
        /// </summary>
        /// <returns></returns>
        public List<ClientAttachment> GetClientAttachmentByUserFormId(int userFormId)
        {
            return FindBy(x => x.UserFormId == userFormId).ToList();
        }
        #endregion
    }
}
