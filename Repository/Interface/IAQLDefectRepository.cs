using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IAQLDefectRepository : IGenericRepository<AQLDefect>
    {
        AQLDefect GetAQLDefectById(int Id);
        AQLDefect GetAQLDefectByReferenceId(int ReferenceId);
        List<AQLDefect> GetAllAQLDefects();
    }
}
