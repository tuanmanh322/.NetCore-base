using Microsoft.EntityFrameworkCore;
using QRCODE_API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Inventory
{
    public class InventoryContext : DbContext
    {
        public InventoryContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().ToTable("role");
            modelBuilder.Entity<CodeSetting>().ToTable("codesetting");
            modelBuilder.Entity<UserLogin>().ToTable("user_login");
            modelBuilder.Entity<CustomerInfo>().ToTable("customer_info");
            modelBuilder.Entity<QrCodeImage>().ToTable("qrcode_image");
            modelBuilder.Entity<QrcodeInfo>().ToTable("qrcode_info");
            modelBuilder.Entity<User>().ToTable("user");
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<CodeSetting> CodeSettings { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<QrCodeImage> QrCodeImages { get; set; }
        public DbSet<QrcodeInfo> QrcodeInfos { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
