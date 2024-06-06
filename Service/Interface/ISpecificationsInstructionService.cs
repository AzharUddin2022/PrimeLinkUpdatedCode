using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface ISpecificationsInstructionService : IGenericServices<SpecificationsInstructionModel, SpecificationsInstruction>
    {
        List<SpecificationsInstructionModel> GetAllSpecificationsInstructions();
        SpecificationsInstructionModel GetSpecificationsInstructionById(int id);
        SpecificationsInstructionModel GetSpecificationsInstructionByUserId(int userId);
        SpecificationsInstructionModel GetSpecificationsInstructionByUserFormId(int userFormId);
        void InsertUpdateSpecificationsInstruction(SpecificationsInstructionModel model);
        void DeleteSpecificationsInstruction(long Id, int specificationsInstructionId);
    }
}
