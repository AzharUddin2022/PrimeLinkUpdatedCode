using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IOnSiteTestResultService : IGenericServices<OnSiteTestResultModel, OnSiteTestResult>
    {
        List<OnSiteTestResultModel> GetAllOnSiteTestResults();
        OnSiteTestResultModel GetOnSiteTestResultById(int id);
        OnSiteTestResultModel GetOnSiteTestResultByReferenceId(int userFormId);
        void InsertUpdateOnSiteTestResult(OnSiteTestResultModel model);
        void DeleteOnSiteTestResult(long Id, int SampleInformationId);
    }
}
