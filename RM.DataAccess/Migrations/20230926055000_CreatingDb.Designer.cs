﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RM.DataAccess.Context;

#nullable disable

namespace RM.DataAccess.Migrations
{
    [DbContext(typeof(RMManagementDbContext))]
    [Migration("20230926055000_CreatingDb")]
    partial class CreatingDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RM.Domain.Entities.Barcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DiscountInPercentage")
                        .HasColumnType("float");

                    b.Property<int>("ShelfTenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelfTenantId");

                    b.ToTable("Barcodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiscountInPercentage = 0.0,
                            ShelfTenantId = 1
                        },
                        new
                        {
                            Id = 2,
                            DiscountInPercentage = 50.0,
                            ShelfTenantId = 1
                        },
                        new
                        {
                            Id = 3,
                            DiscountInPercentage = 0.0,
                            ShelfTenantId = 2
                        },
                        new
                        {
                            Id = 4,
                            DiscountInPercentage = 0.0,
                            ShelfTenantId = 3
                        });
                });

            modelBuilder.Entity("RM.Domain.Entities.Payout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CommissionDeducted")
                        .HasColumnType("float");

                    b.Property<double>("CommissionInPercentage")
                        .HasColumnType("float");

                    b.Property<double>("Fine")
                        .HasColumnType("float");

                    b.Property<int>("ShelfTenantId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPayout")
                        .HasColumnType("float");

                    b.Property<double>("TotalSale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ShelfTenantId");

                    b.ToTable("Payouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommissionDeducted = 0.0,
                            CommissionInPercentage = 15.0,
                            Fine = 0.0,
                            ShelfTenantId = 1,
                            TotalPayout = 0.0,
                            TotalSale = 0.0
                        },
                        new
                        {
                            Id = 2,
                            CommissionDeducted = 0.0,
                            CommissionInPercentage = 15.0,
                            Fine = 350.0,
                            ShelfTenantId = 2,
                            TotalPayout = 0.0,
                            TotalSale = 0.0
                        },
                        new
                        {
                            Id = 3,
                            CommissionDeducted = 0.0,
                            CommissionInPercentage = 15.0,
                            Fine = 0.0,
                            ShelfTenantId = 3,
                            TotalPayout = 0.0,
                            TotalSale = 0.0
                        });
                });

            modelBuilder.Entity("RM.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BarcodeId")
                        .HasColumnType("int");

                    b.Property<double>("DiscountInPercentage")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("PriceOfSale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BarcodeId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarcodeId = 1,
                            DiscountInPercentage = 0.0,
                            Price = 50.0,
                            PriceOfSale = 0.0
                        },
                        new
                        {
                            Id = 2,
                            BarcodeId = 1,
                            DiscountInPercentage = 0.0,
                            Price = 30.0,
                            PriceOfSale = 0.0
                        },
                        new
                        {
                            Id = 3,
                            BarcodeId = 2,
                            DiscountInPercentage = 50.0,
                            Price = 110.0,
                            PriceOfSale = 55.0
                        },
                        new
                        {
                            Id = 4,
                            BarcodeId = 3,
                            DiscountInPercentage = 0.0,
                            Price = 50.5,
                            PriceOfSale = 0.0
                        },
                        new
                        {
                            Id = 5,
                            BarcodeId = 4,
                            DiscountInPercentage = 0.0,
                            Price = 80.299999999999997,
                            PriceOfSale = 0.0
                        });
                });

            modelBuilder.Entity("RM.Domain.Entities.ShelfTenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BankAccountDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShelfTenants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankAccountDetails = "Bank 1234-12345678",
                            Email = "JonDoe@Mail.com",
                            FirstName = "jon",
                            LastName = "Doe",
                            Phone = "12345678"
                        },
                        new
                        {
                            Id = 2,
                            BankAccountDetails = "Bank 1234-22222222",
                            Email = "JaneD@Mail.com",
                            FirstName = "Jane",
                            LastName = "Doe",
                            Phone = "2222222"
                        },
                        new
                        {
                            Id = 3,
                            BankAccountDetails = "Bank 1234-333333333",
                            Email = "Something@Mail.com",
                            FirstName = "Some",
                            LastName = "Thing",
                            Phone = "33333333"
                        });
                });

            modelBuilder.Entity("RM.Domain.Entities.Barcode", b =>
                {
                    b.HasOne("RM.Domain.Entities.ShelfTenant", "ShelfTenant")
                        .WithMany("Barcodes")
                        .HasForeignKey("ShelfTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShelfTenant");
                });

            modelBuilder.Entity("RM.Domain.Entities.Payout", b =>
                {
                    b.HasOne("RM.Domain.Entities.ShelfTenant", "ShelfTenant")
                        .WithMany("Payouts")
                        .HasForeignKey("ShelfTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShelfTenant");
                });

            modelBuilder.Entity("RM.Domain.Entities.Sale", b =>
                {
                    b.HasOne("RM.Domain.Entities.Barcode", "Barcode")
                        .WithMany("Sales")
                        .HasForeignKey("BarcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barcode");
                });

            modelBuilder.Entity("RM.Domain.Entities.Barcode", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("RM.Domain.Entities.ShelfTenant", b =>
                {
                    b.Navigation("Barcodes");

                    b.Navigation("Payouts");
                });
#pragma warning restore 612, 618
        }
    }
}
