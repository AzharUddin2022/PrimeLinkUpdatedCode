using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IInspectorAllocationRepository : IGenericRepository<InspectorAllocation>
    {
        InspectorAllocation GetInspectorAllocationById(int Id);
        InspectorAllocation GetInspectorAllocationByUserFormId(int UserFormId);
        List<InspectorAllocation> GetAllInspectorAllocations();
    }
}
