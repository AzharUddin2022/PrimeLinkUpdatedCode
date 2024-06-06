using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class SampleInformationRepository : GenericRepository<SampleInformation>, ISampleInformationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public SampleInformationRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Sample Information By Id
        /// <summary>
        /// Get Sample Information By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SampleInformation GetSampleInformationById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get Sample Information By User Id
        /// <summary>
        /// Get Sample Information By User Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SampleInformation GetSampleInformationByUserId(int UserId)
        {
            return FindBy(x => x.UserId == UserId).FirstOrDefault();
        }
        #endregion

        #region Get Sample Information By User Form Id
        /// <summary>
        /// Get Sample Information By User Form Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SampleInformation GetSampleInformationByUserFormId(int UserFormId)
        {
            return FindBy(x => x.UserFormId == UserFormId).FirstOrDefault();
        }
        #endregion

        #region Get All Sample Information
        /// <summary>
        /// Get All Sample Information
        /// </summary>
        /// <returns></returns>
        public List<SampleInformation> GetAllSampleInformations()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
