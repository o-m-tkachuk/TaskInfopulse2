using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public SqlProductRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return null;
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Find(id);

            return product;
        }

        public Product Update(Product productChanges)
        {
            var product = _context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return productChanges;
        }
    }
}
