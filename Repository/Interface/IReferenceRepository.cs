using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IReferenceRepository : IGenericRepository<Reference>
    {
        Reference GetReferenceById(int Id);
        List<Reference> GetReferenceByGeneralInformationId(int Id);
        List<Reference> GetAllReferences();
    }
}
