using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchemasForFarmer.BusinessAccessLayer;

namespace SchemasForFarmer.Repository
{
    public partial class AgricultureContext : DbContext
    {
        public AgricultureContext()
        {
        }

        public AgricultureContext(DbContextOptions<AgricultureContext> options)
            : base(options)
        {
        }

        public DbSet<CropTypeModel> crops { get; set; }

        public virtual DbSet<ApplyForPolicy> ApplyForPolicy { get; set; }
        public virtual DbSet<BankDetails> BankDetails { get; set; }
        public virtual DbSet<BidderWelcomePage> BidderWelcomePage { get; set; }
        public virtual DbSet<Bidding> Bidding { get; set; }
        public virtual DbSet<ClaimInsurance> ClaimInsurance { get; set; }
        public virtual DbSet<CropType> CropType { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<PlaceSellRequest> PlaceSellRequest { get; set; }
        public virtual DbSet<Sell> Sell { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<ViewMarketPlace> ViewMarketPlace { get; set; }
        public virtual DbSet<ViewSoldCropHistory> ViewSoldCropHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Integrated Security=SSIP");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplyForPolicy>(entity =>
            {
                entity.HasKey(e => e.CropName)
                    .HasName("PK__ApplyFor__FE7DE0C4F199F71F");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Area).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InsuranceCompany)
                    .HasColumnName("Insurance_Company")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Season)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SharePremium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SumInsuredperhect).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Year).HasColumnType("date");

                entity.HasOne(d => d.PolicyNoNavigation)
                    .WithMany(p => p.ApplyForPolicy)
                    .HasForeignKey(d => d.PolicyNo)
                    .HasConstraintName("FK__ApplyForP__Polic__76969D2E");
            });

            modelBuilder.Entity<BankDetails>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TraderLicense)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BankDetai__UserI__60A75C0F");
            });

            modelBuilder.Entity<BidderWelcomePage>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Bidammount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentBid).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BidderWel__UserI__6EF57B66");
            });

            modelBuilder.Entity<Bidding>(entity =>
            {
                entity.Property(e => e.BiddingId).ValueGeneratedNever();

                entity.Property(e => e.BidAmt).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BidDate).HasColumnType("date");

                entity.Property(e => e.IsBitStatus).HasColumnName("is_BitStatus");

                entity.HasOne(d => d.Sell)
                    .WithMany(p => p.Bidding)
                    .HasForeignKey(d => d.SellId)
                    .HasConstraintName("FK__Bidding__SellId__7E37BEF6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bidding)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bidding__UserId__7D439ABD");
            });

            modelBuilder.Entity<ClaimInsurance>(entity =>
            {
                entity.HasKey(e => e.PolicyNo)
                    .HasName("PK__ClaimIns__2E1321971B02A4A9");

                entity.Property(e => e.PolicyNo).ValueGeneratedNever();

                entity.Property(e => e.DateOfLoss).HasColumnType("date");

                entity.Property(e => e.InsuranceCompany)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NameOfInsuree)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ParticularsOfInsuree)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<CropType>(entity =>
            {
                entity.Property(e => e.CropTypeId).ValueGeneratedNever();

                entity.Property(e => e.CropType1)
                    .HasColumnName("CropType")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlaceSellRequest>(entity =>
            {
                entity.HasKey(e => e.CropType)
                    .HasName("PK__PlaceSel__60A9B5DFB9789A16");

                entity.Property(e => e.CropType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FertilizerType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SoilPhCertificate).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlaceSellRequest)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PlaceSell__UserI__6383C8BA");
            });

            modelBuilder.Entity<Sell>(entity =>
            {
                entity.Property(e => e.SellId).ValueGeneratedNever();

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FertilizerType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CropType)
                    .WithMany(p => p.Sell)
                    .HasForeignKey(d => d.CropTypeId)
                    .HasConstraintName("FK__Sell__CropTypeId__797309D9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sell)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Sell__UserId__7A672E12");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("PK__UserDeta__40D2D8168FD61829");

                entity.Property(e => e.UserTypeId).ValueGeneratedNever();

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C6A0531A0");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PermittedtoSale)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__UserInfo__UserTy__5EBF139D");
            });

            modelBuilder.Entity<ViewMarketPlace>(entity =>
            {
                entity.HasKey(e => e.CropName)
                    .HasName("PK__ViewMark__FE7DE0C4B0161A1F");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CropType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentBid).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ViewMarketPlace)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ViewMarke__UserI__68487DD7");
            });

            modelBuilder.Entity<ViewSoldCropHistory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Msp)
                    .HasColumnName("MSP")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SolidPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ViewSoldC__UserI__656C112C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
