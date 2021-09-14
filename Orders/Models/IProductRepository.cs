using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetProduct(int id);
        Product Add(Product product);
        Product Update(Product productChange);
        Product Delete(int id);
    }
}
