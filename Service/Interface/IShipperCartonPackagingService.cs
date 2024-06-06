using Model.Entity;
using Repository.Entity;
using Service.Common.Interface;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IShipperCartonPackagingService : IGenericServices<ShipperCartonPackagingModel, ShipperCartonPackaging>
    {
        List<ShipperCartonPackagingModel> GetAllShipperCartonPackagings();
        ShipperCartonPackagingModel GetShipperCartonPackagingById(int id);
        ShipperCartonPackagingModel GetShipperCartonPackagingByReferenceId(int userFormId);
        void InsertUpdateShipperCartonPackaging(ShipperCartonPackagingModel model);
        void DeleteShipperCartonPackaging(long Id, int SampleInformationId);
    }
}
