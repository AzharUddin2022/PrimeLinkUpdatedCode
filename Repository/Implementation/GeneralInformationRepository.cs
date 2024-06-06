using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class GeneralInformationRepository : GenericRepository<GeneralInformation>, IGeneralInformationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public GeneralInformationRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get General Information By Id
        /// <summary>
        /// Get General Information By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GeneralInformation GetGeneralInformationById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get General Information By User Id
        /// <summary>
        /// Get General Information By User Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GeneralInformation GetGeneralInformationByUserId(int UserId)
        {

            return FindBy(x => x.UserId == UserId).Include(x => x.References).Include(x => x.Factory).FirstOrDefault();
        }
        #endregion

        #region Get General Information By User Form Id
        /// <summary>
        /// Get General Information By User Form Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GeneralInformation GetGeneralInformationByUserFormId(int UserFormId)
        {
            return FindBy(x => x.UserFormId == UserFormId).Include(y => y.User).Include(y => y.Vendor).Include(y => y.Factory).FirstOrDefault();
        }
        #endregion

        #region Get All General Information
        /// <summary>
        /// Get All General Information
        /// </summary>
        /// <returns></returns>
        public List<GeneralInformation> GetAllGeneralInformations()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }


        #endregion
    }
}
