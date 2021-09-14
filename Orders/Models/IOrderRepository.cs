using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order GetOrder(int orderNumber);
        IEnumerable GetAllOrders();
        Order Update(Order orderChanges);


    }
}
