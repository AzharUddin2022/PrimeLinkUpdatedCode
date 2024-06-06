using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class ReferenceRepository : GenericRepository<Reference>, IReferenceRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ReferenceRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Reference By Id
        /// <summary>
        /// Get Reference By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Reference GetReferenceById(int Id)
        {
            return FindBy(x => x.Id == Id && x.IsActive == true).FirstOrDefault();
        }
        #endregion

        #region Get Reference By General Information Id
        /// <summary>
        /// Get Reference By General Information Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Reference> GetReferenceByGeneralInformationId(int Id)
        {
            return FindBy(x => x.GeneralInformationId == Id && x.IsActive == true).ToList();
        }
        #endregion

        #region Get All Reference
        /// <summary>
        /// Get All Reference
        /// </summary>
        /// <returns></returns>
        public List<Reference> GetAllReferences()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
