using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int OrderNumber { get; set; }

        [ForeignKey("Customer")]
        public int CustomerI { get; set; }

        public virtual Customer Customer { get; set; }

        public string OrderStatus { get; set; }

        public string OrderDate { get; set; }

        public double TotalCost { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<Product> OrderProducts { get; set; }

        public Order()
        {
            OrderProducts = new HashSet<Product>();
        }
    }
}
