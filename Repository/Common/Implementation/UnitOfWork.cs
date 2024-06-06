using Microsoft.EntityFrameworkCore;
using Repository.Common.Interface;
using Repository.DatabaseUtil;
using Repository.Implementation;
using Repository.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Common.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = DbContextFactory.GetBackDbContext();

        }

        #region  private Variables 

        private IUserRepository _userRepository;
        private IApplicationLookupRepository _applicationLookupRepository;
        private IApplicationLookupTypeRepository _applicationLookupTypeRepository;
        private IGeneralInformationRepository _generalInformationRepository;
        private IReferenceRepository _referenceRepository;
        private IVendorRepository _vendorRepository;
        private IFactoryRepository _factoryRepository;
        private ISampleInformationRepository _sampleInformationRepository;
        private ISamplingInformationRepository _samplingInformationRepository;
        private ISpecificationsInstructionRepository _specificationsInstructionRepository;
        private IAttachmentRepository _attachmentRepository;
        private IInspectionScopeAndAQLRepository _inspectionScopeAndAQLRepository;
        private IUserFormRepository _userFormRepository;
        private IInspectorAllocationRepository _inspectorAllocationRepository;
        private IClientAttachmentRepository _clientAttachmentRepository;
        private IAQLDefectRepository _aqlDefectRepository;
        private IGeneralRemarksAndImagesListRepository _generalRemarksAndImagesListRepository;
        private IGeneralRemarksListRepository _generalRemarksListRepository;
        private IInnerPackagingRepository _innerPackagingRepository;
        private IItemAQLDefectsAndRemarkRepository _itemAQLDefectsAndRemarkRepository;
        private IItemDatumRepository _itemDatumRepository;
        private IItemOtherPhotoRepository _itemOtherPhotoRepository;
        private IItemOverallRepository _itemOverallRepository;
        private IItemRemarkDatumRepository _itemRemarkDatumRepository;
        private IOnSiteTestResultRepository _onSiteTestResultRepository;
        private IRetailPackagingRepository _retailPackagingRepository;
        private IShipperCartonPackagingRepository _shipperCartonPackagingRepository;

        #endregion


        #region Public variable reference

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_dbContext));
        public IApplicationLookupRepository ApplicationLookupRepository => _applicationLookupRepository ?? (_applicationLookupRepository = new ApplicationLookupRepository(_dbContext));
        public IApplicationLookupTypeRepository ApplicationLookupTypeRepository => _applicationLookupTypeRepository ?? (_applicationLookupTypeRepository = new ApplicationLookupTypeRepository(_dbContext));
        public IReferenceRepository ReferenceRepository => _referenceRepository ?? (_referenceRepository = new ReferenceRepository(_dbContext));

        public IGeneralInformationRepository GeneralInformationRepository => _generalInformationRepository ?? (_generalInformationRepository = new GeneralInformationRepository(_dbContext));
        public IVendorRepository VendorRepository => _vendorRepository ?? (_vendorRepository = new VendorRepository(_dbContext));
        public IFactoryRepository FactoryRepository => _factoryRepository ?? (_factoryRepository = new FactoryRepository(_dbContext));
        public ISpecificationsInstructionRepository SpecificationsInstructionRepository => _specificationsInstructionRepository ?? (_specificationsInstructionRepository = new SpecificationsInstructionRepository(_dbContext));
        public ISampleInformationRepository SampleInformationRepository => _sampleInformationRepository ?? (_sampleInformationRepository = new SampleInformationRepository(_dbContext));
        public ISamplingInformationRepository SamplingInformationRepository => _samplingInformationRepository ?? (_samplingInformationRepository = new SamplingInformationRepository(_dbContext));
        public IAttachmentRepository AttachmentRepository => _attachmentRepository ?? (_attachmentRepository = new AttachmentRepository(_dbContext));
        public IClientAttachmentRepository ClientAttachmentRepository => _clientAttachmentRepository ?? (_clientAttachmentRepository = new ClientAttachmentRepository(_dbContext));
        public IInspectionScopeAndAQLRepository InspectionScopeAndAQLRepository => _inspectionScopeAndAQLRepository ?? (_inspectionScopeAndAQLRepository = new InspectionScopeAndAQLRepository(_dbContext));
        public IUserFormRepository UserFormRepository => _userFormRepository ?? (_userFormRepository = new UserFormRepository(_dbContext));
        public IInspectorAllocationRepository InspectorAllocationRepository => _inspectorAllocationRepository ?? (_inspectorAllocationRepository = new InspectorAllocationRepository(_dbContext));
        public IAQLDefectRepository AQLDefectRepository => _aqlDefectRepository ?? (_aqlDefectRepository = new AQLDefectRepository(_dbContext));
        public IGeneralRemarksAndImagesListRepository GeneralRemarksAndImagesListRepository => _generalRemarksAndImagesListRepository ?? (_generalRemarksAndImagesListRepository = new GeneralRemarksAndImagesListRepository(_dbContext));
        public IGeneralRemarksListRepository GeneralRemarksListRepository => _generalRemarksListRepository ?? (_generalRemarksListRepository = new GeneralRemarksListRepository(_dbContext));
        public IInnerPackagingRepository InnerPackagingRepository => _innerPackagingRepository ?? (_innerPackagingRepository = new InnerPackagingRepository(_dbContext));
        public IItemAQLDefectsAndRemarkRepository ItemAQLDefectsAndRemarkRepository => _itemAQLDefectsAndRemarkRepository ?? (_itemAQLDefectsAndRemarkRepository = new ItemAQLDefectsAndRemarkRepository(_dbContext));
        public IItemDatumRepository ItemDatumRepository => _itemDatumRepository ?? (_itemDatumRepository = new ItemDatumRepository(_dbContext));
        public IItemOtherPhotoRepository ItemOtherPhotoRepository => _itemOtherPhotoRepository ?? (_itemOtherPhotoRepository = new ItemOtherPhotoRepository(_dbContext));
        public IItemOverallRepository ItemOverallRepository => _itemOverallRepository ?? (_itemOverallRepository = new ItemOverallRepository(_dbContext));
        public IItemRemarkDatumRepository ItemRemarkDatumRepository => _itemRemarkDatumRepository ?? (_itemRemarkDatumRepository = new ItemRemarkDatumRepository(_dbContext));
        public IOnSiteTestResultRepository OnSiteTestResultRepository => _onSiteTestResultRepository ?? (_onSiteTestResultRepository = new OnSiteTestResultRepository(_dbContext));
        public IRetailPackagingRepository RetailPackagingRepository => _retailPackagingRepository ?? (_retailPackagingRepository = new RetailPackagingRepository(_dbContext));
        public IShipperCartonPackagingRepository ShipperCartonPackagingRepository => _shipperCartonPackagingRepository ?? (_shipperCartonPackagingRepository = new ShipperCartonPackagingRepository(_dbContext));


        #endregion


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
