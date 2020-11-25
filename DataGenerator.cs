using Microsoft.EntityFrameworkCore;
using POS_Demo.Domain;
using POS_Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Demo
{
    public static class DataGenerator
    {
        public static void Initialize(AppDBContext dbContext)
        {
            var initialCreater = "Initial Data";

            var paymentMethod = new PaymentMethods() { PaymentMethodId = 1, MethodName = "Cash", CreatedBy = initialCreater };


            var categories = new List<Categories>() {
                new Categories() { CategoryId = 1, CategoryName = "Food", CreatedBy = initialCreater },
                new Categories() { CategoryId = 2, CategoryName = "Beverages", CreatedBy = initialCreater }
                };

            var orderStatuses = new List<OrderStatuses>() {
                new OrderStatuses() { OrderStatusId = 1, StatusName = "Dining", CreatedBy = initialCreater },
                new OrderStatuses() { OrderStatusId = 2, StatusName = "Paid", CreatedBy = initialCreater }
                };

            var product = new List<Products>() {
                new Products() { ProductId = 1, ProductName = "Water", CategoryId = 2, Available = true, CreatedBy = initialCreater },
                new Products() { ProductId = 2, ProductName = "Roti Canai", CategoryId = 1, Available = true, CreatedBy = initialCreater },
                new Products() { ProductId = 3, ProductName = "Coca-cola", CategoryId = 2, Available = true, CreatedBy = initialCreater },
                new Products() { ProductId = 4, ProductName = "Maggie Goreng", CategoryId = 1, Available = true, CreatedBy = initialCreater },
                new Products() { ProductId = 5, ProductName = "Teh Tarik", CategoryId = 2, Available = true, CreatedBy = initialCreater },
                new Products() { ProductId = 6, ProductName = "Roti Telur", CategoryId = 1, Available = true, CreatedBy = initialCreater }
                };


            var productVariant = new List<ProductVariant>() {
                new ProductVariant() { ProductVariantId = 1, ProductId = 1, VariantName = "Regular", ProductPrice = 0.5, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 2, ProductId = 2, VariantName = "Regular", ProductPrice = 1, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 3, ProductId = 3, VariantName = "Regular", ProductPrice = 2.5, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 4, ProductId = 4, VariantName = "Regular", ProductPrice = 4.5, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 5, ProductId = 4, VariantName = "Double", ProductPrice = 7, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 6, ProductId = 5, VariantName = "Regular", ProductPrice = 2.4, Available = true, CreatedBy = initialCreater },
                new ProductVariant() { ProductVariantId = 7, ProductId = 6, VariantName = "Regular", ProductPrice = 2.5, Available = true, CreatedBy = initialCreater }
                };



            dbContext.PaymentMethods.Add(paymentMethod);
            dbContext.Categories.AddRange(categories);
            dbContext.OrderStatuses.AddRange(orderStatuses);
            dbContext.Products.AddRange(product);
            dbContext.ProductVariants.AddRange(productVariant);

            dbContext.SaveChanges();
        }
    }
}
