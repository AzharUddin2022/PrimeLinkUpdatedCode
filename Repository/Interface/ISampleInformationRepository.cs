using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ISampleInformationRepository : IGenericRepository<SampleInformation>
    {
        SampleInformation GetSampleInformationById(int Id);
        SampleInformation GetSampleInformationByUserId(int UserId);
        SampleInformation GetSampleInformationByUserFormId(int UserFormId);
        List<SampleInformation> GetAllSampleInformations();
    }
}
