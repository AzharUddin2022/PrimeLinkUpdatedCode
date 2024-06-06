using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class InspectorAllocationRepository : GenericRepository<InspectorAllocation>, IInspectorAllocationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public InspectorAllocationRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get InspectorAllocation By Id
        /// <summary>
        /// Get InspectorAllocation By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public InspectorAllocation GetInspectorAllocationById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get InspectorAllocation By UserFormId
        /// <summary>
        /// Get InspectorAllocation By UserFormId
        /// </summary>
        /// <param name="UserFormId"></param>
        /// <returns></returns>
        public InspectorAllocation GetInspectorAllocationByUserFormId(int UserFormId)
        {
            return FindBy(x => x.UserFormId == UserFormId).FirstOrDefault();
        }
        #endregion

        #region Get All InspectorAllocation
        /// <summary>
        /// Get All InspectorAllocation
        /// </summary>
        /// <returns></returns>
        public List<InspectorAllocation> GetAllInspectorAllocations()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }


        //public InspectorAllocation GetInspectorNameByID(int id)
        //{
        //    return FindBy(x => x.UserId == id).Include(x => x.InspectorName).FirstOrDefault();

        //    //var result = from user in user
        //    //             join inspectorAllocation in inspectorAllocations
        //    //             on user.id equals inspectorAllocation.inspectorId
        //    //             where user.userid = id
        //    //             select user.Firstname;

        //    //return result;

        //}
        #endregion
    }
}
