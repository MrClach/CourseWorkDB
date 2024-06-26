﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spp3.Data;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20240418231901_DBCreation")]
    partial class DBCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Data.Models.CommercialOrganization", b =>
                {
                    b.Property<int>("coId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("coId"));

                    b.Property<string>("organizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("coId");

                    b.ToTable("CommercialOrganizations");
                });

            modelBuilder.Entity("API.Data.Models.Deal", b =>
                {
                    b.Property<int>("dlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dlId"));

                    b.Property<int>("cuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dealMoment")
                        .HasColumnType("datetime2");

                    b.Property<int>("prId")
                        .HasColumnType("int");

                    b.Property<int>("selId")
                        .HasColumnType("int");

                    b.HasKey("dlId");

                    b.HasIndex("cuId");

                    b.HasIndex("prId");

                    b.HasIndex("selId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("API.Data.Models.Order", b =>
                {
                    b.Property<int>("orId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orId"));

                    b.Property<string>("orderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("orId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Data.Models.OutletSection", b =>
                {
                    b.Property<int>("osId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("osId"));

                    b.Property<string>("sectionFloor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionHall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("toId")
                        .HasColumnType("int");

                    b.HasKey("osId");

                    b.HasIndex("toId");

                    b.ToTable("OutletSections");
                });

            modelBuilder.Entity("API.Data.Models.SectionManager", b =>
                {
                    b.Property<int>("smId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("smId"));

                    b.Property<double?>("experience")
                        .HasColumnType("float");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("osId")
                        .HasColumnType("int");

                    b.Property<string>("patrynomic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("salary")
                        .HasColumnType("float");

                    b.Property<string>("secondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("smId");

                    b.HasIndex("osId")
                        .IsUnique();

                    b.ToTable("SectionManagers");
                });

            modelBuilder.Entity("API.Data.Models.Seller", b =>
                {
                    b.Property<int>("selId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("selId"));

                    b.Property<DateOnly?>("endOfContract")
                        .HasColumnType("date");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("osId")
                        .HasColumnType("int");

                    b.Property<string>("patrynomic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("salary")
                        .HasColumnType("float");

                    b.Property<string>("secondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("selId");

                    b.HasIndex("osId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("API.Data.Models.Supplier", b =>
                {
                    b.Property<int>("suId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("suId"));

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("supplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("suId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("API.Data.Models.TradeOutlet", b =>
                {
                    b.Property<int>("toId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("toId"));

                    b.Property<int>("coId")
                        .HasColumnType("int");

                    b.Property<int?>("counters")
                        .HasColumnType("int");

                    b.Property<string>("outletName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("outletType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("rent")
                        .HasColumnType("float");

                    b.Property<double?>("size")
                        .HasColumnType("float");

                    b.HasKey("toId");

                    b.HasIndex("coId");

                    b.ToTable("tradeOutlets");
                });

            modelBuilder.Entity("API.Data.Models.User", b =>
                {
                    b.Property<int>("usId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("usId"));

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("urId")
                        .HasColumnType("int");

                    b.HasKey("usId");

                    b.HasIndex("urId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Data.Models.UserRole", b =>
                {
                    b.Property<int>("urId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urId"));

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("urId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("OrderToSuppluer", b =>
                {
                    b.Property<int>("OrId")
                        .HasColumnType("int")
                        .HasColumnName("orID");

                    b.Property<int>("SuId")
                        .HasColumnType("int")
                        .HasColumnName("suID");

                    b.HasKey("OrId", "SuId")
                        .HasName("PK__OrderToSupplier");

                    b.HasIndex("SuId");

                    b.ToTable("OrderToSuppluer", (string)null);
                });

            modelBuilder.Entity("ProductToOrder", b =>
                {
                    b.Property<int>("PrId")
                        .HasColumnType("int")
                        .HasColumnName("prID");

                    b.Property<int>("OrId")
                        .HasColumnType("int")
                        .HasColumnName("orID");

                    b.HasKey("PrId", "OrId")
                        .HasName("PK__ProductToOrder");

                    b.HasIndex("OrId");

                    b.ToTable("ProductToOrder", (string)null);
                });

            modelBuilder.Entity("spp3.Data.Models.BonusCard", b =>
                {
                    b.Property<int>("BcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BcId"));

                    b.Property<int>("cuId")
                        .HasColumnType("int");

                    b.Property<float>("discount")
                        .HasColumnType("real");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BcId");

                    b.HasIndex("cuId")
                        .IsUnique();

                    b.ToTable("BonusCards");
                });

            modelBuilder.Entity("spp3.Data.Models.Customer", b =>
                {
                    b.Property<int>("CuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuId"));

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("age")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patrynomic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CuId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("spp3.Data.Models.Product", b =>
                {
                    b.Property<int>("prId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("prId"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("price")
                        .HasColumnType("float");

                    b.Property<int?>("ptId")
                        .HasColumnType("int");

                    b.Property<int?>("quantity")
                        .HasColumnType("int");

                    b.HasKey("prId");

                    b.HasIndex("ptId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("spp3.Data.Models.ProductType", b =>
                {
                    b.Property<int>("ptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ptId"));

                    b.Property<int?>("ageLimit")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ptId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("API.Data.Models.Deal", b =>
                {
                    b.HasOne("spp3.Data.Models.Customer", "Customer")
                        .WithMany("Deals")
                        .HasForeignKey("cuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spp3.Data.Models.Product", "Product")
                        .WithMany("Deals")
                        .HasForeignKey("prId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Models.Seller", "Seller")
                        .WithMany("Deals")
                        .HasForeignKey("selId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("API.Data.Models.OutletSection", b =>
                {
                    b.HasOne("API.Data.Models.TradeOutlet", "TradeOutlet")
                        .WithMany("OutletSections")
                        .HasForeignKey("toId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TradeOutlet");
                });

            modelBuilder.Entity("API.Data.Models.SectionManager", b =>
                {
                    b.HasOne("API.Data.Models.OutletSection", "OutletSection")
                        .WithOne("SectionManager")
                        .HasForeignKey("API.Data.Models.SectionManager", "osId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OutletSection");
                });

            modelBuilder.Entity("API.Data.Models.Seller", b =>
                {
                    b.HasOne("API.Data.Models.OutletSection", "OutletSection")
                        .WithMany("Sellers")
                        .HasForeignKey("osId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OutletSection");
                });

            modelBuilder.Entity("API.Data.Models.TradeOutlet", b =>
                {
                    b.HasOne("API.Data.Models.CommercialOrganization", "CommercialOrganization")
                        .WithMany("TradeOutlets")
                        .HasForeignKey("coId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommercialOrganization");
                });

            modelBuilder.Entity("API.Data.Models.User", b =>
                {
                    b.HasOne("API.Data.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("urId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("OrderToSuppluer", b =>
                {
                    b.HasOne("API.Data.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderToSupplier__orID");

                    b.HasOne("API.Data.Models.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderToSupplier__suID");
                });

            modelBuilder.Entity("ProductToOrder", b =>
                {
                    b.HasOne("API.Data.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ProductToOrder__orID");

                    b.HasOne("spp3.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("PrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ProductToOrder__prID");
                });

            modelBuilder.Entity("spp3.Data.Models.BonusCard", b =>
                {
                    b.HasOne("spp3.Data.Models.Customer", "Customer")
                        .WithOne("BonusCard")
                        .HasForeignKey("spp3.Data.Models.BonusCard", "cuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("spp3.Data.Models.Product", b =>
                {
                    b.HasOne("spp3.Data.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ptId");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("API.Data.Models.CommercialOrganization", b =>
                {
                    b.Navigation("TradeOutlets");
                });

            modelBuilder.Entity("API.Data.Models.OutletSection", b =>
                {
                    b.Navigation("SectionManager");

                    b.Navigation("Sellers");
                });

            modelBuilder.Entity("API.Data.Models.Seller", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("API.Data.Models.TradeOutlet", b =>
                {
                    b.Navigation("OutletSections");
                });

            modelBuilder.Entity("API.Data.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("spp3.Data.Models.Customer", b =>
                {
                    b.Navigation("BonusCard");

                    b.Navigation("Deals");
                });

            modelBuilder.Entity("spp3.Data.Models.Product", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("spp3.Data.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
