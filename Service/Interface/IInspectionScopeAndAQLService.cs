using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IInspectionScopeAndAQLService : IGenericServices<InspectionScopeAndAQLModel, InspectionScopeAndAQL>
    {
        List<InspectionScopeAndAQLModel> GetAllInspectionScopeAndAQLs();
        InspectionScopeAndAQLModel GetInspectionScopeAndAQLById(int id);
        InspectionScopeAndAQLModel GetInspectionScopeAndAQLByUserId(int userId);
        InspectionScopeAndAQLModel GetInspectionScopeAndAQLByUserFormId(int userFormId);
        void InsertUpdateInspectionScopeAndAQL(InspectionScopeAndAQLModel model);
        void DeleteInspectionScopeAndAQL(long Id, int InspectionScopeAndAQLId);
    }
}
