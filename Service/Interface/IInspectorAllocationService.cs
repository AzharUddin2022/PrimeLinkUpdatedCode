using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IInspectorAllocationService : IGenericServices<InspectorAllocationModel, InspectorAllocation>
    {
        List<InspectorAllocationModel> GetAllInspectorAllocations();
        InspectorAllocationModel GetInspectorAllocationById(int id);
        InspectorAllocationModel GetInspectorAllocationByUserFormId(int userFormId);
        void InsertUpdateInspectorAllocation(InspectorAllocationModel model);
        void DeleteInspectorAllocation(int Id, int InspectorAllocationId);
    }
}
