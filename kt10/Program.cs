using System;
using System.Collections.Generic;

namespace kt10
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        void Delete(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
    }

    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string GetInfo()
        {
            return $"Product: {Id}, {Name}, ${Price}";
        }
    }

    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string GetInfo()
        {
            return $"Customer: {Id}, {Name}, {Address}";
        }
    }

    public class ProductRepository : IRepository<Product>
    {
        private List<Product> products = new List<Product>();

        public void Add(Product item)
        {
            products.Add(item);
        }

        public void Delete(Product item)
        {
            products.Remove(item);
        }

        public Product FindById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }
    }

    public class CustomerRepository : IRepository<Customer>
    {
        private List<Customer> customers = new List<Customer>();

        public void Add(Customer item)
        {
            customers.Add(item);
        }

        public void Delete(Customer item)
        {
            customers.Remove(item);
        }

        public Customer FindById(int id)
        {
            return customers.Find(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customers;
        }
    }

    class Program
    {
        static void Main()
        {
            ProductRepository productRepo = new ProductRepository();

            productRepo.Add(new Product { Id = 1, Name = "1", Price = 5 });
            productRepo.Add(new Product { Id = 2, Name = "2", Price = 25 });
            productRepo.Add(new Product { Id = 3, Name = "3", Price = 125 });

            Console.WriteLine("products:");
            foreach (var product in productRepo.GetAll())
            {
                Console.WriteLine(product.GetInfo());
            }

            Console.WriteLine(productRepo.FindById(2).GetInfo());

            CustomerRepository customerRepo = new CustomerRepository();

            customerRepo.Add(new Customer { Id = 1, Name = "max", Address = "1" });
            customerRepo.Add(new Customer { Id = 2, Name = "maxi", Address = "2" });

            Console.WriteLine("\nAll customers ");
            foreach (var customer in customerRepo.GetAll())
            {
                Console.WriteLine(customer.GetInfo());
            }

            Console.ReadLine();
        }
    }
}