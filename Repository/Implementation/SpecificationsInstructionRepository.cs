using Microsoft.EntityFrameworkCore;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementation
{
    public class SpecificationsInstructionRepository : GenericRepository<SpecificationsInstruction>, ISpecificationsInstructionRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public SpecificationsInstructionRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Get Specifications Instruction By Id
        /// <summary>
        /// Get Specifications Instruction By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SpecificationsInstruction GetSpecificationsInstructionById(int Id)
        {
            return FindBy(x => x.Id == Id).FirstOrDefault();
        }
        #endregion

        #region Get Specifications Instruction By User Id
        /// <summary>
        /// Get Specifications Instruction By User Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SpecificationsInstruction GetSpecificationsInstructionByUserId(int UserId)
        {
            return FindBy(x => x.UserId == UserId).FirstOrDefault();
        }
        #endregion

        #region Get Specifications Instruction By User Form Id
        /// <summary>
        /// Get Specifications Instruction By User Form Id
        /// </summary>
        /// <param name="UserFormId"></param>
        /// <returns></returns>
        public SpecificationsInstruction GetSpecificationsInstructionByUserFormId(int UserFormId)
        {
            return FindBy(x => x.UserFormId == UserFormId).FirstOrDefault();
        }
        #endregion

        #region Get All Specifications Instruction
        /// <summary>
        /// Get All Specifications Instruction
        /// </summary>
        /// <returns></returns>
        public List<SpecificationsInstruction> GetAllSpecificationsInstructions()
        {
            return FindBy(x => (bool)x.IsActive).ToList();
        }
        #endregion
    }
}
