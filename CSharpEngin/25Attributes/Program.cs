using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1,FirstName="ramzan", LastName = "orhan", Age = 40 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }
    [Table("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    class CustomerDal
    {   
        [Obsolete("dont use add , intead of use addNew",false)]   
        public void Add(Customer customer)
        {
            Console.WriteLine("{0}, {1},  {2}, {3}  eklendi...", customer.Id, customer.FirstName, customer.LastName,customer.Age);
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0}, {1},  {2}, {3}  eklendi...", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }
}
