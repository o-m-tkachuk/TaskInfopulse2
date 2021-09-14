using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class OrdersProducts
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
    }
}
