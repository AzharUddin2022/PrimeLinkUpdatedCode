using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class ItemDatumRepository : GenericRepository<ItemDatum>, IItemDatumRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ItemDatumRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Sampling Information By Id
        /// <summary>
        /// Get Sampling Information By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ItemDatum GetItemDatumById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get Sampling Information By User Form Id
        /// <summary>
        /// Get Sampling Information By User Form Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ItemDatum GetItemDatumByReferenceId(int ReferenceId)
        {
            return FindBy(x => x.ReferenceId == ReferenceId).FirstOrDefault();
        }
        #endregion

        #region Get All Sampling Information
        /// <summary>
        /// Get All Sampling Information
        /// </summary>
        /// <returns></returns>
        public List<ItemDatum> GetAllItemDatums()
        {
            return FindBy(x => x.Id != 0).ToList();
        }
        #endregion
    }
}
