using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IOnSiteTestResultRepository : IGenericRepository<OnSiteTestResult>
    {
        OnSiteTestResult GetOnSiteTestResultById(int Id);
        OnSiteTestResult GetOnSiteTestResultByReferenceId(int ReferenceId);
        List<OnSiteTestResult> GetAllOnSiteTestResults();
    }
}
