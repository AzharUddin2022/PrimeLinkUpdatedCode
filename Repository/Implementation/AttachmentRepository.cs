using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AttachmentRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Attachment By Id
        /// <summary>
        /// Get Attachment By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Attachment GetAttachmentById(int Id)
        {
            return FindBy(x => x.Id == Id && x.IsActive == true).FirstOrDefault();
        }
        #endregion

        #region Get Attachment By Specifications Instructions Id
        /// <summary>
        /// Get Attachment By Specifications Instructions Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Attachment> GetAttachmentBySpecificationsInstructionsId(int Id)
        {
            return FindBy(x => x.SpecificationsInstructionsId == Id && x.IsActive == true).ToList();
        }
        #endregion

        #region Get All Attachment
        /// <summary>
        /// Get All Attachment
        /// </summary>
        /// <returns></returns>
        public List<Attachment> GetAllAttachments()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
