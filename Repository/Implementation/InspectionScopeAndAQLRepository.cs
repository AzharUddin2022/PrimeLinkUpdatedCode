using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class InspectionScopeAndAQLRepository : GenericRepository<InspectionScopeAndAQL>, IInspectionScopeAndAQLRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public InspectionScopeAndAQLRepository(DbContext context)
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
        public InspectionScopeAndAQL GetInspectionScopeAndAQLById(int Id)
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
        public InspectionScopeAndAQL GetInspectionScopeAndAQLByUserId(int UserId)
        {
            return FindBy(x => x.UserId == UserId).FirstOrDefault();
        }
        #endregion

        #region Get Sample Information By User Form Id
        /// <summary>
        /// Get Sample Information By User Form Id
        /// </summary>
        /// <param name="UserFormId"></param>
        /// <returns></returns>
        public InspectionScopeAndAQL GetInspectionScopeAndAQLByUserFormId(int UserFormId)
        {
            return FindBy(x => x.UserFormId == UserFormId).FirstOrDefault();
        }
        #endregion

        #region Get All Sample Information
        /// <summary>
        /// Get All Sample Information
        /// </summary>
        /// <returns></returns>
        public List<InspectionScopeAndAQL> GetAllInspectionScopeAndAQLs()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
