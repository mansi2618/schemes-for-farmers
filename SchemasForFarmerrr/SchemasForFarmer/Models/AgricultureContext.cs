using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Models
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
                optionsBuilder.UseSqlServer("integrated security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplyForPolicy>(entity =>
            {
                entity.HasKey(e => e.CropName)
                    .HasName("PK__ApplyFor__FE7DE0C4350AA1A6");

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
                    .HasConstraintName("FK__ApplyForP__Polic__70DDC3D8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplyForPolicy)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ApplyForP__UserI__6FE99F9F");
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
                    .HasConstraintName("FK__BankDetai__UserI__3C69FB99");
            });

            modelBuilder.Entity<BidderWelcomePage>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Bidamount).HasColumnType("decimal(18, 2)");

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
                    .HasConstraintName("FK__BidderWel__UserI__4AB81AF0");
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
                    .HasConstraintName("FK__Bidding__SellId__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bidding)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bidding__UserId__534D60F1");
            });

            modelBuilder.Entity<ClaimInsurance>(entity =>
            {
                entity.HasKey(e => e.PolicyNo)
                    .HasName("PK__ClaimIns__2E132197D84D7744");

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

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LoginInfo__UserI__02084FDA");

                entity.HasOne(d => d.UserType)
                    .WithMany()
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__LoginInfo__UserT__02FC7413");
            });

            modelBuilder.Entity<PlaceSellRequest>(entity =>
            {
                entity.HasKey(e => e.CropType)
                    .HasName("PK__PlaceSel__60A9B5DFEC3C97FB");

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
                    .HasConstraintName("FK__PlaceSell__UserI__3F466844");
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
                    .HasConstraintName("FK__Sell__CropTypeId__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sell)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Sell__UserId__5070F446");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("PK__UserDeta__40D2D816DB23ADF0");

                entity.Property(e => e.UserTypeId).ValueGeneratedNever();

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C9D1D94CA");

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
                    .HasConstraintName("FK__UserInfo__UserTy__3A81B327");
            });

            modelBuilder.Entity<ViewMarketPlace>(entity =>
            {
                entity.HasKey(e => e.CropName)
                    .HasName("PK__ViewMark__FE7DE0C4325AB236");

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
                    .HasConstraintName("FK__ViewMarke__UserI__440B1D61");
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
                    .HasConstraintName("FK__ViewSoldC__UserI__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
