using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public SqlCustomerRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public IEnumerable GetAllCustomers()
        {
            var orders = _context.Orders;
            var customers = _context.Customers;

            var customersList = from c in customers
                                select new 
                                { 
                                    customerId = c.CustomerId,
                                customerName = c.CustomerName,
                                customerAddress = c.CustomerAddress,
                                totalCost = orders.Where(o => o.CustomerI == c.CustomerId).Sum( o => o.TotalCost),
                                orderCount = orders.Where(o => o.CustomerI == c.CustomerId).Count()
                                };

            return customersList;
        }
    }
}
