using AutoMapper;
using Model.Entity;
using Repository.Entity;

namespace Service.Common.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<User, UserModel>();
            CreateMap<Reference, ReferenceModel>();
            CreateMap<Attachment, AttachmentModel>();
            CreateMap<ClientAttachment, ClientAttachmentModel>();
            CreateMap<GeneralInformation, GeneralInformationModel>();
            CreateMap<Factory, FactoryModel>();
            CreateMap<Vendor, VendorModel>();

            CreateMap<UserModel, User>();
            CreateMap<ReferenceModel, Reference>();
            CreateMap<AttachmentModel, Attachment>();
            CreateMap<ClientAttachmentModel, ClientAttachment>();
            CreateMap<GeneralInformationModel, GeneralInformation>();
            CreateMap<FactoryModel, Factory>();
            CreateMap<VendorModel, Vendor>();
            CreateMap<InspectorAllocationModel, InspectorAllocation>();
        }
    }
}
