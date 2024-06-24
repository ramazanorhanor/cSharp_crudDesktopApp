using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace _22EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETrade_BtkContext context = new ETrade_BtkContext())
            {
                return context.Products.ToList();
            }

        }

        public List<Product> GetByName(string key)
        {
            using (ETrade_BtkContext context=new ETrade_BtkContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETrade_BtkContext context = new ETrade_BtkContext())
            {
                var result = context.Products.Where(p => p.UnitPrice >= price).ToList();
                return result;
            }
        }
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (ETrade_BtkContext context = new ETrade_BtkContext())
            {
                var result = context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
                return result;
            }
        }
        public Product GetById(int id)
        {
            using (ETrade_BtkContext context=new ETrade_BtkContext())
            {
                var result = context.Products.SingleOrDefault(p => p.Id == id);
                return result;
            }
        }
        public void Add(Product product)
        {
            using (ETrade_BtkContext context = new ETrade_BtkContext())
            {
                // context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (ETrade_BtkContext context = new ETrade_BtkContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Product product)
        {
            using (ETrade_BtkContext context = new ETrade_BtkContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
