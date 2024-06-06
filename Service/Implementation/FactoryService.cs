using System;
using System.Collections.Generic;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Entity;
using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class FactoryService : GenericServices<FactoryModel, Factory>, IFactoryService
    {
        #region Private variables
        private readonly IFactoryRepository _factoryRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FactoryService()
        {
            UnitOfWork = new UnitOfWork();
            _factoryRepository = UnitOfWork.FactoryRepository;
            GenericRepository = _factoryRepository = UnitOfWork.FactoryRepository;
        }
        #endregion

        #region Get All Factory
        /// <summary>
        /// Get All Factory
        /// </summary>
        /// <returns></returns>
        public List<FactoryModel> GetAllFactory()
        {
            return MapperHelper.MapList<FactoryModel, Factory>(_factoryRepository.GetAllFactory());
        }
        #endregion

        #region Get Factory By Id
        /// <summary>
        /// Get Factory By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FactoryModel GetFactoryById(int id)
        {
            return MapperHelper.Map<FactoryModel, Factory>(_factoryRepository.GetFactoryById(id));
        }
        #endregion

        #region Get Factory By UserId
        /// <summary>
        /// Get Factory By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FactoryModel GetFactoryByGeneralInformationId(int FactoryId)
        {
            return MapperHelper.Map<FactoryModel, Factory>(_factoryRepository.GetFactoryByGeneralInformationId(FactoryId));
        }
        #endregion

        public void DeleteFactory(long Id, int FactoryId)
        {
            var model = _factoryRepository.FindById(Id);
            model.IsActive = false;
            model.UpdatedBy = FactoryId;
            model.UpdatedDate = DateTime.Now;
            _factoryRepository.Update(model);
            UnitOfWork.Commit();
        }
    }
}
