using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ISpecificationsInstructionRepository : IGenericRepository<SpecificationsInstruction>
    {
        SpecificationsInstruction GetSpecificationsInstructionById(int Id);
        SpecificationsInstruction GetSpecificationsInstructionByUserId(int UserId);
        SpecificationsInstruction GetSpecificationsInstructionByUserFormId(int UserFormId);
        List<SpecificationsInstruction> GetAllSpecificationsInstructions();
    }
}
