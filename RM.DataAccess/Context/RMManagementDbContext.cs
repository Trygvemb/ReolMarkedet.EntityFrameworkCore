using Microsoft.EntityFrameworkCore;
using RM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.DataAccess.Context
{

    public class RMManagementDbContext : DbContext
    {
        public RMManagementDbContext(DbContextOptions<RMManagementDbContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<ShelfTenant> ShelfTenants { get; set; }
        public DbSet<Payout> Payouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShelfTenant>().HasData(
                new ShelfTenant { Id = 1, FirstName = "jon", LastName = "Doe", Phone = "12345678", Email = "JonDoe@Mail.com", BankAccountDetails = "Bank 1234-12345678" },
                new ShelfTenant { Id = 2, FirstName = "Jane", LastName = "Doe", Phone = "2222222", Email = "JaneD@Mail.com", BankAccountDetails = "Bank 1234-22222222" },
                new ShelfTenant { Id = 3, FirstName = "Some", LastName = "Thing", Phone = "33333333", Email = "Something@Mail.com", BankAccountDetails = "Bank 1234-333333333" }

                );
            modelBuilder.Entity<Barcode>().HasData(
                new Barcode { Id = 1, DiscountInPercentage = 0, ShelfTenantId = 1 },
                new Barcode { Id = 2, DiscountInPercentage = 50, ShelfTenantId = 1 },
                new Barcode { Id = 3, DiscountInPercentage = 0, ShelfTenantId = 2 },
                new Barcode { Id = 4, DiscountInPercentage = 0, ShelfTenantId = 3 }

                );
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, Price = 50, BarcodeId = 1 },
                new Sale { Id = 2, Price = 30, BarcodeId = 1 },
                new Sale { Id = 3, Price = 110, DiscountInPercentage = 50, PriceOfSale = 55, BarcodeId = 2 },
                new Sale { Id = 4, Price = 50.50, BarcodeId = 3 },
                new Sale { Id = 5, Price = 80.30, BarcodeId = 4 }

                );
            modelBuilder.Entity<Payout>().HasData(
                new Payout { Id = 1, Fine = 0, ShelfTenantId = 1 },
                new Payout { Id = 2, Fine = 350, ShelfTenantId = 2 },
                new Payout { Id = 3, Fine = 0, ShelfTenantId = 3 }

                );
        }
    }
}
