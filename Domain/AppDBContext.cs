using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using POS_Demo.Domain.Model;

namespace POS_Demo.Domain
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
         
        public AppDBContext(DbContextOptions options) : base(options) => ChangeTracker.LazyLoadingEnabled = false;

        #region DB Table
        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatuses> OrderStatuses { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }        
        public virtual DbSet<Tables> Tables { get; set; }


        public virtual DbSet<Bundle_ProductVariant> Bundle_ProductVariants { get; set; }
        public virtual DbSet<Orders_ProductVariant> Orders_ProductVariants { get; set; }
        #endregion

        #region Data type
        private const string _datetimeDefaultValue = "CURRENT_TIMESTAMP";

        private const string _nameDataType = "varchar(200) CHARACTER SET 'utf8mb4'";
        private const string _remarkDataType = "varchar(400) CHARACTER SET 'utf8mb4'";
        private const string _moneyDataType = "DECIMAL(13, 4)";
        private const string _datetimeDataType = "datetime";
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Bundle>().HasKey(x => x.BundleId);
            modelBuilder.Entity<Bundle>().Property(x => x.BundleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Bundle>().Property(x => x.BundleName).HasColumnType(_nameDataType);
            modelBuilder.Entity<Bundle>().Property(x => x.OriginalPrice).HasColumnType(_moneyDataType);
            modelBuilder.Entity<Bundle>().Property(x => x.BundlePrice).HasColumnType(_moneyDataType);
            modelBuilder.Entity<Bundle>().Property(x => x.Available).HasDefaultValue(true);
            modelBuilder.Entity<Bundle>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<Bundle>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<Bundle>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Bundle>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<Bundle>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);



            modelBuilder.Entity<Categories>().HasKey(x => x.CategoryId);
            modelBuilder.Entity<Categories>().Property(x => x.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Categories>().Property(x => x.CategoryName).HasColumnType(_nameDataType);
            modelBuilder.Entity<Categories>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<Categories>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<Categories>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Categories>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<Categories>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);



            modelBuilder.Entity<Orders>().HasKey(x => x.OrderId);
            modelBuilder.Entity<Orders>().Property(x => x.TotalPrice).HasColumnType(_moneyDataType);
            modelBuilder.Entity<Orders>().Property(x => x.PaidAmount).HasColumnType(_moneyDataType);
            modelBuilder.Entity<Orders>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<Orders>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<Orders>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Orders>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<Orders>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Orders>().HasOne(x => x.OrderStatuses).WithMany(x => x.Orders).HasForeignKey(x => x.OrderStatusId);
            modelBuilder.Entity<Orders>().HasOne(x => x.Tables).WithMany(x => x.Orders).HasForeignKey(x => x.TableNumber);
            modelBuilder.Entity<Orders>().HasOne(x => x.PaymentMethods).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentMethodId);




            modelBuilder.Entity<OrderStatuses>().HasKey(x => x.OrderStatusId);
            modelBuilder.Entity<OrderStatuses>().Property(x => x.OrderStatusId).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderStatuses>().Property(x => x.StatusName).HasColumnType(_nameDataType);
            modelBuilder.Entity<OrderStatuses>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<OrderStatuses>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<OrderStatuses>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<OrderStatuses>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<OrderStatuses>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);



            modelBuilder.Entity<PaymentMethods>().HasKey(x => x.PaymentMethodId);
            modelBuilder.Entity<PaymentMethods>().Property(x => x.PaymentMethodId).ValueGeneratedOnAdd();
            modelBuilder.Entity<PaymentMethods>().Property(x => x.MethodName).HasColumnType(_nameDataType);
            modelBuilder.Entity<PaymentMethods>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<PaymentMethods>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<PaymentMethods>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<PaymentMethods>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<PaymentMethods>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);



            modelBuilder.Entity<Products>().HasKey(x => x.ProductId);
            modelBuilder.Entity<Products>().Property(x => x.ProductId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Products>().Property(x => x.ProductName).HasColumnType(_nameDataType);
            modelBuilder.Entity<Products>().Property(x => x.Available).HasDefaultValue(true);
            modelBuilder.Entity<Products>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<Products>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<Products>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Products>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<Products>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Products>().HasOne(x => x.Categories).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);



            modelBuilder.Entity<ProductVariant>().HasKey(x => x.ProductVariantId);
            modelBuilder.Entity<ProductVariant>().Property(x => x.ProductVariantId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductVariant>().Property(x => x.VariantName).HasColumnType(_nameDataType);
            modelBuilder.Entity<ProductVariant>().Property(x => x.ProductPrice).HasColumnType(_moneyDataType);
            modelBuilder.Entity<ProductVariant>().Property(x => x.Available).HasDefaultValue(true);
            modelBuilder.Entity<ProductVariant>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<ProductVariant>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<ProductVariant>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<ProductVariant>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<ProductVariant>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<ProductVariant>().HasOne(x => x.Products).WithMany(x => x.ProductVariants).HasForeignKey(x => x.ProductId);



            modelBuilder.Entity<Tables>().HasKey(x => x.TableNumber);
            modelBuilder.Entity<Tables>().Property(x => x.isEmpty).HasDefaultValue(true);
            modelBuilder.Entity<Tables>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<Tables>().Property(x => x.CreatedAt).HasColumnType(_datetimeDataType).HasDefaultValueSql(_datetimeDefaultValue);
            modelBuilder.Entity<Tables>().Property(x => x.CreatedBy).HasColumnType(_nameDataType);
            modelBuilder.Entity<Tables>().Property(x => x.UpdatedAt).HasColumnType(_datetimeDataType);
            modelBuilder.Entity<Tables>().Property(x => x.UpdatedBy).HasColumnType(_nameDataType);



            modelBuilder.Entity<Bundle_ProductVariant>().HasKey(x => new { x.BundleId, x.ProductVariantId });
            modelBuilder.Entity<Bundle_ProductVariant>().HasOne(x => x.Bundle).WithMany(x => x.Bundle_ProductVariants).HasForeignKey(x => x.BundleId);
            modelBuilder.Entity<Bundle_ProductVariant>().HasOne(x => x.ProductVariant).WithMany(x => x.Bundle_ProductVariants).HasForeignKey(x => x.ProductVariantId);


            modelBuilder.Entity<Orders_ProductVariant>().HasKey(x => new { x.OrderId, x.ProductVariantId });
            modelBuilder.Entity<Orders_ProductVariant>().Property(x => x.ProductPrice).HasColumnType(_moneyDataType);
            modelBuilder.Entity<Orders_ProductVariant>().Property(x => x.Remark).HasColumnType(_remarkDataType);
            modelBuilder.Entity<Orders_ProductVariant>().HasOne(x => x.Orders).WithMany(x => x.Orders_ProductVariants).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<Orders_ProductVariant>().HasOne(x => x.ProductVariant).WithMany(x => x.Orders_ProductVariants).HasForeignKey(x => x.ProductVariantId);

            modelBuilder = SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private ModelBuilder SeedData(ModelBuilder modelBuilder) {
            var initialCreater = "Initial Data";

            modelBuilder.Entity<PaymentMethods>().HasData(
                new PaymentMethods() { PaymentMethodId = 1, MethodName = "Cash", CreatedBy = initialCreater }
                );

            modelBuilder.Entity<Categories>().HasData(
                new Categories() { CategoryId=1, CategoryName="Food", CreatedBy= initialCreater },
                new Categories() { CategoryId=2, CategoryName= "Beverages", CreatedBy= initialCreater }
                );

            modelBuilder.Entity<OrderStatuses>().HasData(
                new OrderStatuses() { OrderStatusId = 1, StatusName = "Dining", CreatedBy = initialCreater },
                new OrderStatuses() { OrderStatusId = 2, StatusName = "Paid", CreatedBy = initialCreater }
                );

            modelBuilder.Entity<Products>().HasData(
                new Products() { ProductId = 1, ProductName = "Water", CategoryId = 2, Available = true, CreatedBy = initialCreater},
                new Products() { ProductId = 2, ProductName = "Roti Canai", CategoryId = 1, Available = true, CreatedBy = initialCreater},
                new Products() { ProductId = 3, ProductName = "Coca-cola", CategoryId = 2, Available = true, CreatedBy = initialCreater},
                new Products() { ProductId = 4, ProductName = "Maggie Goreng", CategoryId = 1, Available = true, CreatedBy = initialCreater},
                new Products() { ProductId = 5, ProductName = "Teh Tarik", CategoryId = 2, Available = true, CreatedBy = initialCreater},
                new Products() { ProductId = 6, ProductName = "Roti Telur", CategoryId = 1, Available = true, CreatedBy = initialCreater}
                );


            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant() { ProductVariantId = 1, ProductId = 1, VariantName = "Regular", ProductPrice = 0.5, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 2, ProductId = 2, VariantName = "Regular", ProductPrice = 1, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 3, ProductId = 3, VariantName = "Regular", ProductPrice = 2.5, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 4, ProductId = 4, VariantName = "Regular", ProductPrice = 4.5, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 5, ProductId = 4, VariantName = "Double", ProductPrice = 7, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 6, ProductId = 5, VariantName = "Regular", ProductPrice = 2.4, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 7, ProductId = 6, VariantName = "Regular", ProductPrice = 2.5, Available = true, CreatedBy = initialCreater }
                );


            return modelBuilder;
        }

        
    }
}
