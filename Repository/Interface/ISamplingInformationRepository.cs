using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ISamplingInformationRepository : IGenericRepository<SamplingInformation>
    {
        SamplingInformation GetSamplingInformationById(int Id);
        SamplingInformation GetSamplingInformationByReferenceId(int ReferenceId);
        List<SamplingInformation> GetAllSamplingInformations();
    }
}
