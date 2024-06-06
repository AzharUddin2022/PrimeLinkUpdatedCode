using Repository.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Common.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IApplicationLookupRepository ApplicationLookupRepository { get; }
        IApplicationLookupTypeRepository ApplicationLookupTypeRepository { get; }
        IGeneralInformationRepository GeneralInformationRepository { get; }
        IReferenceRepository ReferenceRepository { get; }
        IVendorRepository VendorRepository { get; }
        IFactoryRepository FactoryRepository { get; }
        ISampleInformationRepository SampleInformationRepository { get; }
        ISamplingInformationRepository SamplingInformationRepository { get; }
        ISpecificationsInstructionRepository SpecificationsInstructionRepository { get; }
        IAttachmentRepository AttachmentRepository { get; }
        IInspectionScopeAndAQLRepository InspectionScopeAndAQLRepository { get; }
        IUserFormRepository UserFormRepository { get; }
        IInspectorAllocationRepository InspectorAllocationRepository { get; }
        IClientAttachmentRepository ClientAttachmentRepository { get; }
        IAQLDefectRepository AQLDefectRepository { get; }
        IGeneralRemarksAndImagesListRepository GeneralRemarksAndImagesListRepository { get; }
        IGeneralRemarksListRepository GeneralRemarksListRepository { get; }
        IInnerPackagingRepository InnerPackagingRepository { get; }
        IItemAQLDefectsAndRemarkRepository ItemAQLDefectsAndRemarkRepository { get; }
        IItemDatumRepository ItemDatumRepository { get; }
        IItemOtherPhotoRepository ItemOtherPhotoRepository { get; }
        IItemOverallRepository ItemOverallRepository { get; }
        IItemRemarkDatumRepository ItemRemarkDatumRepository { get; }
        IOnSiteTestResultRepository OnSiteTestResultRepository { get; }
        IRetailPackagingRepository RetailPackagingRepository { get; }
        IShipperCartonPackagingRepository ShipperCartonPackagingRepository { get; }

        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);

    }
}
