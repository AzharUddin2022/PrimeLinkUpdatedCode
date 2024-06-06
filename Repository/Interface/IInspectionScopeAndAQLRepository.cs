using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IInspectionScopeAndAQLRepository : IGenericRepository<InspectionScopeAndAQL>
    {
        InspectionScopeAndAQL GetInspectionScopeAndAQLById(int Id);
        InspectionScopeAndAQL GetInspectionScopeAndAQLByUserId(int UserId);
        InspectionScopeAndAQL GetInspectionScopeAndAQLByUserFormId(int UserFormId);
        List<InspectionScopeAndAQL> GetAllInspectionScopeAndAQLs();
    }
}
