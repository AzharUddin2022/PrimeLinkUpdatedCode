using Repository.Common.Interface;
using Repository.Entity;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IShipperCartonPackagingRepository : IGenericRepository<ShipperCartonPackaging>
    {
        ShipperCartonPackaging GetShipperCartonPackagingById(int Id);
        ShipperCartonPackaging GetShipperCartonPackagingByReferenceId(int ReferenceId);
        List<ShipperCartonPackaging> GetAllShipperCartonPackagings();
    }
}
