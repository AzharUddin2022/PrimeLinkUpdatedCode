using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get User By Id
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUserById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get All User
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion

        #region Return bool if email already exist
        /// <summary>
        /// Return bool if email already exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsEmailAlreadyExist(string email, int Id)
        {
            if (email == null)
            {
                return true;
            }
            return !FindBy(x => x.Id != Id && x.Email == email && x.IsActive == true).Any();
        }
        #endregion

        #region Return bool if Username already exist
        /// <summary>
        /// Return bool if Username already exist
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool IsUsernameAlreadyExist(string Username, int Id)
        {
            if (Username == null)
            {
                return true;
            }
            return !FindBy(x => x.Id != Id && x.UserName == Username && x.IsActive == true).Any();
        }
        #endregion
    }
}
