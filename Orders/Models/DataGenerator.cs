using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any board games.
                if (context.Products.Any())
                {
                    return;   // Data was already seeded
                }

                context.Products.AddRange(
                    new Product
                    {
                        ProductId = 1,
                        ProductName = "Pizza",
                        Price = 10,
                        Category = "Food",
                        CreatedDate = DateTime.Now.ToShortDateString(),
                        Quantity = 10,
                        Size = "Medium",
                        ProductDescription = "Meaty pizza"
                    },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Chocolat",
                    Price = 20,
                    Category = "Food",
                    CreatedDate = DateTime.Now.ToShortDateString(),
                    Quantity = 20,
                    Size = "Small",
                    ProductDescription = "Milk chocolat"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "HotDog",
                    Price = 15,
                    Category = "Food",
                    CreatedDate = DateTime.Now.ToShortDateString(),
                    Quantity = 15,
                    Size = "Medium"
                }
                );

                if (context.Customers.Any())
                {
                    return;
                }

                context.Customers.AddRange(
                        new Customer
                        {
                            CustomerId = 1,
                            CustomerName = "John Smith",
                            CustomerAddress = "5th Ave, New York",
                            CreatedDate = DateTime.Now.ToShortDateString()
                        },
                        new Customer
                        {
                            CustomerId = 2,
                            CustomerName = "Helen Smith",
                            CustomerAddress = "10th Ave, New York",
                            CreatedDate = DateTime.Now.ToShortDateString()
                        },
                        new Customer
                        {
                            CustomerId = 3,
                            CustomerName = "Adam James",
                            CustomerAddress = "6th Ave, New York",
                            CreatedDate = DateTime.Now.ToShortDateString()
                        }
                    );

                if (context.Orders.Any())
                {
                    return;
                }

                context.Orders.AddRange(
                        new Order
                        {
                            OrderId = 1,
                            OrderNumber = 35972,
                            OrderDate = DateTime.Now.ToShortDateString(),
                            TotalCost = 10,
                            CustomerI = 1,
                            OrderStatus = "New",
                            Comment = "Nothing",

                        },
                        new Order
                        {
                            OrderId = 2,
                            OrderNumber = 35973,
                            OrderDate = DateTime.Now.ToShortDateString(),
                            TotalCost = 30,
                            CustomerI = 3,
                            OrderStatus = "New",
                            Comment = "Nothing"
                        },
                        new Order
                        {
                            OrderId = 3,
                            OrderNumber = 35974,
                            OrderDate = DateTime.Now.ToShortDateString(),
                            TotalCost = 30,
                            CustomerI = 3,
                            OrderStatus = "New"
                        }
                    );
                if (context.OrdersProducts.Any())
                {
                    return;
                }
                context.OrdersProducts.AddRange(
                    new OrdersProducts
                    {
                        OrderNumber = 35973,
                        ProductId = 1
                    },
                    new OrdersProducts
                    { 
                        OrderNumber = 35973,
                        ProductId = 2
                    },
                    new OrdersProducts
                    { 
                        OrderNumber = 35972,
                        ProductId = 1
                    },
                    new OrdersProducts
                    {
                        OrderNumber = 35972,
                        ProductId = 3
                    },
                    new OrdersProducts
                    {
                        OrderNumber = 35974,
                        ProductId = 1
                    }
                    );


                context.SaveChanges();
            }
        }
    }
}
