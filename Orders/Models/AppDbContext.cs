using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasData(

            //    new Product
            //    {
            //        ProductId = 1,
            //        ProductName = "Pizza",
            //        Price = 10,
            //        Category = "Food",
            //        CreatedDate = DateTime.Now,
            //        Quantity = 10,
            //        Size = "Medium",
            //        ProductDescription = "Meaty pizza"
            //    },
            //    new Product
            //    {
            //        ProductId = 2,
            //        ProductName = "Chocolat",
            //        Price = 20,
            //        Category = "Food",
            //        CreatedDate = DateTime.Now,
            //        Quantity = 20,
            //        Size = "Small",
            //        ProductDescription = "Milk chocolat"
            //    }
            //);

            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer
            //    {
            //        CustomerId = 1,
            //        CustomerName = "John Smith",
            //        CustomerAddress = "5th Avenue",
            //        CreatedDate = DateTime.Now
            //    },
            //    new Customer
            //    {
            //        CustomerId = 2,
            //        CustomerName = "Helen Smith",
            //        CustomerAddress = "6th Avenue",
            //        CreatedDate = DateTime.Now
            //    }
            //    );

            //modelBuilder.Entity<Order>().HasData(
            //    new Order
            //    {
            //        OrderId = 1,
            //        OrderNumber = 35972,
            //        OrderDate = DateTime.Now,
            //        TotalCost = 150,
            //        CustomerId = 1,
            //        OrderStatus = "New",
            //        Comment = "Nothing",
                    
            //    },
            //    new Order
            //    {
            //        OrderId = 2,
            //        OrderNumber = 35973,
            //        OrderDate = DateTime.Now,
            //        TotalCost = 120,
            //        CustomerId = 1,
            //        OrderStatus = "New",
            //        Comment = "Nothing"
            //    }

            //    );

            //modelBuilder.Entity<OrdersProducts>().HasData(
            //    new OrdersProducts
            //    {
            //        OrderId = 1,
            //        ProductId = 1
            //    },
            //    new OrdersProducts
            //    {
            //        OrderId = 1,
            //        ProductId = 2
            //    }
            //    );
            //modelBuilder.Entity<OrdersProducts>().HasNoKey();
            //modelBuilder.Entity<Order>().HasMany(o => o.OrderProducts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
