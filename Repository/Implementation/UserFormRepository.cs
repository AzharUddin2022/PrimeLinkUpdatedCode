using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class UserFormRepository : GenericRepository<UserForm>, IUserFormRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserFormRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get UserForm By Id
        /// <summary>
        /// Get UserForm By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserForm GetUserFormById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get All UserForm
        /// <summary>
        /// Get All UserForm
        /// </summary>
        /// <returns></returns>
        public List<UserForm> GetAllUserForms()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion

        public UserForm GetUserFormByUserId(int userId)
        {
            return FindBy(x => x.UserId == userId).FirstOrDefault();
        }
        
    }
}
