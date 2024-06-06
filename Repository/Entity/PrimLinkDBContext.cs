using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Entity
{
    public partial class PrimLinkDBContext : DbContext
    {
        public PrimLinkDBContext()
        {
        }

        public PrimLinkDBContext(DbContextOptions<PrimLinkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AQLDefect> AQLDefects { get; set; }
        public virtual DbSet<ApplicationLookup> ApplicationLookups { get; set; }
        public virtual DbSet<ApplicationLookupType> ApplicationLookupTypes { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<ClientAttachment> ClientAttachments { get; set; }
        public virtual DbSet<CustomerSpecialCheckpoint> CustomerSpecialCheckpoints { get; set; }
        public virtual DbSet<DefectPhoto> DefectPhotos { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<GeneralInformation> GeneralInformations { get; set; }
        public virtual DbSet<GeneralRemarksAndImagesList> GeneralRemarksAndImagesLists { get; set; }
        public virtual DbSet<GeneralRemarksList> GeneralRemarksLists { get; set; }
        public virtual DbSet<ImportantRemark> ImportantRemarks { get; set; }
        public virtual DbSet<InnerPackaging> InnerPackagings { get; set; }
        public virtual DbSet<InspectionScopeAndAQL> InspectionScopeAndAQLs { get; set; }
        public virtual DbSet<InspectorAllocation> InspectorAllocations { get; set; }
        public virtual DbSet<ItemAQLDefectsAndRemark> ItemAQLDefectsAndRemarks { get; set; }
        public virtual DbSet<ItemDatum> ItemData { get; set; }
        public virtual DbSet<ItemMappingList> ItemMappingLists { get; set; }
        public virtual DbSet<ItemOtherPhoto> ItemOtherPhotos { get; set; }
        public virtual DbSet<ItemOverall> ItemOveralls { get; set; }
        public virtual DbSet<ItemRemarkDatum> ItemRemarkData { get; set; }
        public virtual DbSet<OnSiteTestResult> OnSiteTestResults { get; set; }
        public virtual DbSet<ProductInformationVerification> ProductInformationVerifications { get; set; }
        public virtual DbSet<QuantityCheckResult> QuantityCheckResults { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<RetailPackaging> RetailPackagings { get; set; }
        public virtual DbSet<SampleInformation> SampleInformations { get; set; }
        public virtual DbSet<SamplingInformation> SamplingInformations { get; set; }
        public virtual DbSet<ShipperCartonPackaging> ShipperCartonPackagings { get; set; }
        public virtual DbSet<SpecificationsInstruction> SpecificationsInstructions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserForm> UserForms { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<YourProduct> YourProducts { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-42OIRKH; Database=PrimLinkDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AQLDefect>(entity =>
            {
                entity.Property(e => e.Critical).HasMaxLength(250);

                entity.Property(e => e.Defects).HasMaxLength(250);

                entity.Property(e => e.Filename).HasMaxLength(250);

                entity.Property(e => e.Major).HasMaxLength(250);

                entity.Property(e => e.Minor).HasMaxLength(250);

                entity.Property(e => e.RemarkContent).HasMaxLength(250);
            });

            modelBuilder.Entity<ApplicationLookup>(entity =>
            {
                entity.ToTable("ApplicationLookup");

                entity.HasIndex(e => e.SeqKey, "UQ__Applicat__3819D4D3C1D04C15")
                    .IsUnique();

                entity.HasIndex(e => e.SeqKey, "UQ__Applicat__3819D4D3E0067CB0")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationLookupType>(entity =>
            {
                entity.ToTable("ApplicationLookupType");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.SpecificationsInstructions)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.SpecificationsInstructionsId)
                    .HasConstraintName("FK_Attachments_SpecificationsInstructions");
            });

            modelBuilder.Entity<ClientAttachment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserForm)
                    .WithMany(p => p.ClientAttachments)
                    .HasForeignKey(d => d.UserFormId)
                    .HasConstraintName("FK_ClientAttachments_UserForms");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClientAttachments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ClientAttachments_User");
            });

            modelBuilder.Entity<CustomerSpecialCheckpoint>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OverallResult)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DefectPhoto>(entity =>
            {
                entity.Property(e => e.DefectType)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LevelName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(1500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.ToTable("Factory");

                entity.HasIndex(e => e.GeneralInformationId, "UQ__Factory__9D6BCEE4FC1D1B1C")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FactoryCompanyName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FactoryPreset)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GeneralInformation)
                    .WithOne(p => p.Factory)
                    .HasForeignKey<Factory>(d => d.GeneralInformationId)
                    .HasConstraintName("FK__Factory__General__5D95E53A");
            });

            modelBuilder.Entity<GeneralInformation>(entity =>
            {
                entity.ToTable("GeneralInformation");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationCountry)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MissionReference).HasMaxLength(250);

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.QuantityUnit)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceDate).HasColumnType("datetime");

                entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GeneralInformations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GeneralInformation_User");
            });

            modelBuilder.Entity<GeneralRemarksAndImagesList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GeneralRemarksAndImagesList");

                entity.Property(e => e.Comments)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RemarkType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Seqkey)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralRemarksList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GeneralRemarksList");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RemarkType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImportantRemark>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RemarkType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InnerPackaging>(entity =>
            {
                entity.ToTable("InnerPackaging");

                entity.Property(e => e.InnerPackagingMarkingsLabeling).HasMaxLength(250);

                entity.Property(e => e.InnerPackagingMethodAssortmentResult).HasMaxLength(250);
            });

            modelBuilder.Entity<InspectionScopeAndAQL>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InspectionScopeAndAQL");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CriticalDefects).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MajorDefects).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinorDefects).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SamplePlan)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SampleSize).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InspectorAllocation>(entity =>
            {
                entity.ToTable("InspectorAllocation");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InspectorName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserFormName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserForm)
                    .WithMany(p => p.InspectorAllocations)
                    .HasForeignKey(d => d.UserFormId)
                    .HasConstraintName("FK_InspectorAllocation_UserForms");
            });

            modelBuilder.Entity<ItemAQLDefectsAndRemark>(entity =>
            {
                entity.Property(e => e.AQLCritical).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.AQLMajor).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.AQLMinor).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.AQLResult)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InspectionLevel)
                    .HasMaxLength(1500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemDatum>(entity =>
            {
                entity.Property(e => e.FinishedUnpacked).HasMaxLength(250);

                entity.Property(e => e.NotFinishedUnits).HasMaxLength(250);

                entity.Property(e => e.OverallResult).HasMaxLength(250);

                entity.Property(e => e.PackedCartons).HasMaxLength(250);

                entity.Property(e => e.PackedUnits).HasMaxLength(250);

                entity.Property(e => e.UnitsOrCarton).HasMaxLength(250);
            });

            modelBuilder.Entity<ItemMappingList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ItemMappingList");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ItemOtherPhoto>(entity =>
            {
                entity.Property(e => e.FilePath).HasMaxLength(250);
            });

            modelBuilder.Entity<ItemOverall>(entity =>
            {
                entity.ToTable("ItemOverall");

                entity.Property(e => e.GeneralConstructionAndMaterial).HasMaxLength(250);

                entity.Property(e => e.ItemColor).HasMaxLength(250);

                entity.Property(e => e.ItemNetWeightMeasuredData).HasMaxLength(250);

                entity.Property(e => e.ItemNetWeightResult).HasMaxLength(250);

                entity.Property(e => e.ItemOverallDimensionsMeasuredData).HasMaxLength(250);

                entity.Property(e => e.ItemOverallDimensionsResult).HasMaxLength(250);

                entity.Property(e => e.OtherDimensionsMeasuredData).HasMaxLength(250);

                entity.Property(e => e.OtherDimensionsResult).HasMaxLength(250);
            });

            modelBuilder.Entity<ItemRemarkDatum>(entity =>
            {
                entity.Property(e => e.FilePath).HasMaxLength(250);

                entity.Property(e => e.ItemRemarkComments).HasMaxLength(250);

                entity.Property(e => e.ItemRemarkStatus).HasMaxLength(250);
            });

            modelBuilder.Entity<OnSiteTestResult>(entity =>
            {
                entity.ToTable("OnSiteTestResult");

                entity.Property(e => e.FilePath).HasMaxLength(250);

                entity.Property(e => e.ResultComments).HasMaxLength(250);

                entity.Property(e => e.Results).HasMaxLength(250);

                entity.Property(e => e.SampleSize).HasMaxLength(250);

                entity.Property(e => e.TestDescription).HasMaxLength(250);
            });

            modelBuilder.Entity<ProductInformationVerification>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductInformationVerification");

                entity.Property(e => e.AQLCritical).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.AQLMajor).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.AQLMinor).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.AQLResult)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InspectionLevel)
                    .HasMaxLength(1500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuantityCheckResult>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FilePath).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ModelNumber)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderQtyUnits)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.PONumber)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.ResultORRemarksDesc).IsUnicode(false);

                entity.Property(e => e.Results)
                    .HasMaxLength(1500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PO)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SKU)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GeneralInformation)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.GeneralInformationId)
                    .HasConstraintName("FK_References_GeneralInformation");
            });

            modelBuilder.Entity<RetailPackaging>(entity =>
            {
                entity.ToTable("RetailPackaging");

                entity.Property(e => e.RetailPackagingMethods).HasMaxLength(250);

                entity.Property(e => e.RetailPackagingPrintings).HasMaxLength(250);

                entity.Property(e => e.RetailPackagingUserInstructions).HasMaxLength(250);
            });

            modelBuilder.Entity<SampleInformation>(entity =>
            {
                entity.ToTable("SampleInformation");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CourierAccountNumber)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CourierCompanyName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SendingDestination)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ToDoAfterInspection)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingNumber)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SampleInformations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SampleInformation_User");
            });

            modelBuilder.Entity<SamplingInformation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SamplingInformation");

                entity.Property(e => e.FactoryAllowsDrawingSamples)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InspectedCartonCTN).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InspectedCartonNumber)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.ModelNumber)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.PONumber)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.QuantityAvailableForSampling)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.SampleSizeFromFinishedUnPacked).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SampleSizeFromPackedCTNS).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ShipperCartonPackaging>(entity =>
            {
                entity.ToTable("ShipperCartonPackaging");

                entity.Property(e => e.PackagingMethodAssortmentResult).HasMaxLength(250);

                entity.Property(e => e.ShipperCartonDimensionsMeasuredData).HasMaxLength(250);

                entity.Property(e => e.ShipperCartonDimensionsResult).HasMaxLength(250);

                entity.Property(e => e.ShipperCartonMarkingsLabelingResult).HasMaxLength(250);

                entity.Property(e => e.ShipperCartonWeightMeasuredData).HasMaxLength(250);

                entity.Property(e => e.ShipperCartonWeightResult).HasMaxLength(250);
            });

            modelBuilder.Entity<SpecificationsInstruction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SpecificationsInstructions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SpecificationsInstructions_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Company)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timezone)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserForm>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserForms)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserForms_UserForms");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.HasIndex(e => e.GeneralInformationId, "UQ__Vendor__9D6BCEE47BA819E5")
                    .IsUnique();

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NatureOfVendor)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VendorCompanyName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VendorPreset)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.GeneralInformation)
                    .WithOne(p => p.Vendor)
                    .HasForeignKey<Vendor>(d => d.GeneralInformationId)
                    .HasConstraintName("FK__Vendor__GeneralI__5AB9788F");
            });

            modelBuilder.Entity<YourProduct>(entity =>
            {
                entity.ToTable("YourProduct");

                entity.Property(e => e.Path)
                    .HasMaxLength(1500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
