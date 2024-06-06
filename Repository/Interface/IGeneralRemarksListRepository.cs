using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IGeneralRemarksListRepository : IGenericRepository<GeneralRemarksList>
    {
        GeneralRemarksList GetGeneralRemarksListById(int Id);
        GeneralRemarksList GetGeneralRemarksListByReferenceId(int ReferenceId);
        List<GeneralRemarksList> GetAllGeneralRemarksLists();
    }
}
