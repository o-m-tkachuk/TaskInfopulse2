using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }

        
        public string CustomerName { get; set; }


        public string CustomerAddress { get; set; }


        public string CreatedDate { get; set; }
    }
}
