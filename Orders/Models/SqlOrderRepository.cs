using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public SqlOrderRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public IEnumerable GetAllOrders()
        {
            var orders = from order in _context.Orders
                        join customer in _context.Customers on order.CustomerI equals customer.CustomerId
                        select new 
                        { 
                            OrderId = order.OrderId,
                            OrderNumber = order.OrderNumber,
                            CustomerName = customer.CustomerName,
                            CustomerAddress = customer.CustomerAddress,
                            TotalCost = order.TotalCost,
                            Status = order.OrderStatus
                        };

            return orders;
        }

        public Order GetOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.Customer = _context.Customers.Find(order.CustomerI);
            var products2 = from p in _context.Products
                            join oP in _context.OrdersProducts on p.ProductId equals oP.ProductId
                            where oP.OrderNumber == order.OrderNumber
                            select p;
            order.OrderProducts = products2.ToHashSet();
            return order;
        }

        public Order Update(Order orderChanges)
        {
            var order = _context.Orders.Attach(orderChanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return orderChanges;
        }
    }
}
