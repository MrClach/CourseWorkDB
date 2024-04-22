using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using spp3.Data.Models;
using System;

namespace spp3.Data
{
    public partial class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }
        
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommercialOrganization> CommercialOrganizations {  get; set; }
        public DbSet<TradeOutlet> TradeOutlets { get; set; }
        public DbSet<OutletSection> OutletSections { get; set; }
        public DbSet<SectionManager> SectionManagers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BonusCard> BonusCards { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => ur.urId);

                entity.Property(ur => ur.role).IsRequired(true);

                entity.HasMany(ur => ur.Users).WithOne(us => us.UserRole).HasForeignKey(us => us.urId).IsRequired(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(us => us.usId);

                entity.Property(us => us.login).IsRequired(true);
                entity.Property(us => us.password).IsRequired(true);

                entity.HasOne(us => us.UserRole).WithMany(ur => ur.Users).IsRequired(true);
            });

            modelBuilder.Entity<CommercialOrganization>(entity =>
            {
                entity.HasKey(co => co.coId);

                entity.Property(co => co.organizationName).IsRequired(true);

                entity.HasMany(co => co.TradeOutlets).WithOne(to => to.CommercialOrganization).HasForeignKey(to => to.coId).IsRequired(false); ;
            });

            modelBuilder.Entity<TradeOutlet>(entity =>
            {
                entity.HasKey(to => to.toId);

                entity.Property(to => to.outletName).IsRequired(true);
                entity.Property(to => to.outletType).IsRequired(false);
                entity.Property(to => to.size).IsRequired(false);
                entity.Property(to => to.rent).IsRequired(false);
                entity.Property(to => to.counters).IsRequired(false);

                entity.HasOne(to => to.CommercialOrganization).WithMany(co => co.TradeOutlets).IsRequired(true);
                entity.HasMany(to => to.OutletSections).WithOne(os => os.TradeOutlet).HasForeignKey(os => os.toId).IsRequired(false);
            });

            modelBuilder.Entity<OutletSection>(entity =>
            {
                entity.HasKey(os => os.osId);

                entity.Property(os => os.sectionName).IsRequired(true);
                entity.Property(os => os.sectionFloor).IsRequired(false);
                entity.Property(os => os.sectionHall).IsRequired(false);

                entity.HasOne(os => os.TradeOutlet).WithMany(to => to.OutletSections).IsRequired(true);
                entity.HasOne(os => os.SectionManager).WithOne(sm => sm.OutletSection).HasForeignKey<SectionManager>(sm => sm.osId).IsRequired(false);
                entity.HasMany(os => os.Sellers).WithOne(sel => sel.OutletSection).HasForeignKey(sel => sel.osId).IsRequired(false);
            });

            modelBuilder.Entity<SectionManager>(entity =>
            {
                entity.HasKey(sm => sm.smId);

                entity.Property(sm => sm.firstName).IsRequired(true);
                entity.Property(sm => sm.secondName).IsRequired(true);
                entity.Property(sm => sm.patrynomic).IsRequired(false);
                entity.Property(sm => sm.salary).IsRequired(false);
                entity.Property(sm => sm.phoneNumber).IsRequired(true);
                entity.Property(sm => sm.experience).IsRequired(false);

                entity.HasOne(sm => sm.OutletSection).WithOne(os => os.SectionManager).IsRequired(true);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(sel => sel.selId);

                entity.Property(sel => sel.firstName).IsRequired(true);
                entity.Property(sel => sel.secondName).IsRequired(true);
                entity.Property(sel => sel.patrynomic).IsRequired(false);
                entity.Property(sel => sel.salary).IsRequired(false);
                entity.Property(sm => sm.phoneNumber).IsRequired(true);
                entity.Property(sel => sel.endOfContract).IsRequired(false);

                entity.HasOne(sel => sel.OutletSection).WithMany(os => os.Sellers).IsRequired(true);
                entity.HasMany(sel => sel.Deals).WithOne(dl => dl.Seller).HasForeignKey(dl => dl.selId).IsRequired(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(cu => cu.CuId);

                entity.Property(cu => cu.firstName).IsRequired(true);
                entity.Property(cu => cu.secondName).IsRequired(true);
                entity.Property(cu => cu.patrynomic).IsRequired(false);
                entity.Property(cu => cu.age).IsRequired(false);
                entity.Property(cu => cu.gender).IsRequired(false);
                entity.Property(cu => cu.adress).IsRequired(false);
                entity.Property(cu => cu.phoneNumber).IsRequired(true);

                entity.HasOne(cu => cu.BonusCard).WithOne(bc => bc.Customer).HasForeignKey<BonusCard>(bc => bc.cuId).IsRequired(false);
                entity.HasMany(cu => cu.Deals).WithOne(dl => dl.Customer).HasForeignKey(dl => dl.cuId).IsRequired(false);
            });

            modelBuilder.Entity<BonusCard>(entity =>
            {
                entity.HasKey(bc => bc.BcId);

                entity.Property(bc => bc.number).IsRequired(true);
                entity.Property(bc => bc.discount).IsRequired(true);

                entity.HasOne(bc => bc.Customer).WithOne(cu => cu.BonusCard).IsRequired(true);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(pt => pt.ptId);

                entity.Property(pt => pt.name).IsRequired(true);
                entity.Property(pt => pt.ageLimit).IsRequired(false);

                entity.HasMany(pt => pt.Products).WithOne(pr => pr.ProductType).HasForeignKey(pr => pr.ptId).IsRequired(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(pr => pr.prId);

                entity.Property(pr => pr.name).IsRequired(true);
                entity.Property(pr => pr.quantity).IsRequired(false);
                entity.Property(pr => pr.price).IsRequired(false);

                entity.HasOne(pr => pr.ProductType).WithMany(pt => pt.Products);
                entity.HasMany(pr => pr.Deals).WithOne(dl => dl.Product).HasForeignKey(dl => dl.prId).IsRequired(false);
                entity.HasMany(pr => pr.Orders).WithMany(or => or.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductToOrder",
                    or => or.HasOne<Order>().WithMany()
                        .HasForeignKey("OrId")
                        .HasConstraintName("FK__ProductToOrder__orID"),
                    pr => pr.HasOne<Product>().WithMany()
                        .HasForeignKey("PrId")
                        .HasConstraintName("FK__ProductToOrder__prID"),
                    ptoo =>
                    {
                        ptoo.HasKey("PrId", "OrId").HasName("PK__ProductToOrder");
                        ptoo.ToTable("ProductToOrder");
                        ptoo.IndexerProperty<int>("PrId").HasColumnName("prID");
                        ptoo.IndexerProperty<int>("OrId").HasColumnName("orID");
                    });
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(dl => dl.dlId);

                entity.Property(dl => dl.dealMoment).IsRequired(true);

                entity.HasOne(dl => dl.Customer).WithMany(cu => cu.Deals).IsRequired(true);
                entity.HasOne(dl => dl.Seller).WithMany(sel => sel.Deals).IsRequired(true);
                entity.HasOne(dl => dl.Product).WithMany(pr => pr.Deals).IsRequired(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(or => or.orId);

                entity.Property(or => or.orderStatus).IsRequired(true);
                entity.Property(or => or.quantity).IsRequired(true);

                entity.HasMany(or => or.Suppliers).WithMany(su => su.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderToSuppluer",
                    r => r.HasOne<Supplier>().WithMany()
                        .HasForeignKey("SuId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__OrderToSupplier__suID"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__OrderToSupplier__orID"),
                    j =>
                    {
                        j.HasKey("OrId", "SuId").HasName("PK__OrderToSupplier");
                        j.ToTable("OrderToSuppluer");
                        j.IndexerProperty<int>("OrId").HasColumnName("orID");
                        j.IndexerProperty<int>("SuId").HasColumnName("suID");
                    });
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(su => su.suId);

                entity.Property(su => su.supplierName).IsRequired(true);
                entity.Property(su => su.price).IsRequired(true);
                entity.Property(su => su.quantity).IsRequired(true);
            });
        }
    }
}
