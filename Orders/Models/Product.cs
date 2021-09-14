using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        //public int OrderId { get; set; }
        public string ProductName { get; set; }

        public string Category { get; set; }

        public string Size { get; set; }

        public int Quantity { get; set; }
        
        public double Price { get; set; }

        public string CreatedDate { get; set; }

        public string ProductDescription { get; set; }
        public virtual ICollection<Order> orders { get; set; }

    }
}
