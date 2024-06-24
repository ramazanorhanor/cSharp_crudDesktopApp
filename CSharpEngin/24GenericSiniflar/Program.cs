using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24GenericSiniflar
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("anka","mall");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> customers = utilities.BuildList<Customer>(new Customer() { firstName="ramz"}, new Customer() { firstName = "orhan" });
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.firstName);
            }
            List<int> sonuc = utilities.BuildList<int>(1,2);
            foreach (var item in sonuc)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }

    }
    class Product
    {

    }
    class Customer
    {
        public string firstName { get; set; }
    }
    interface IProductDal:IRepository<Product>
    {

    }
   
    interface ICustomerDal:IRepository<Customer>
    {
        void ABC();
    }
    interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
     class CustomerDal : ICustomerDal
    {
        public void ABC()
        {
            throw new NotImplementedException();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
