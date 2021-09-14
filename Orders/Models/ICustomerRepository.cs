using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        Customer Get(int id);
        IEnumerable GetAllCustomers();
    }
}
