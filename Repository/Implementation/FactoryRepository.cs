using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class FactoryRepository : GenericRepository<Factory>, IFactoryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public FactoryRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Factory By Id
        /// <summary>
        /// Get Factory By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Factory GetFactoryById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get Factory By User Id
        /// <summary>
        /// Get Factory By User Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Factory GetFactoryByGeneralInformationId(int generalInformationId)
        {
            return FindBy(x => x.GeneralInformationId == generalInformationId).FirstOrDefault();
        }
        #endregion

        #region Get All Factory
        /// <summary>
        /// Get All Factory
        /// </summary>
        /// <returns></returns>
        public List<Factory> GetAllFactory()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
