/*

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

*/

/*
 
using System;

namespace kt10
{
    public interface IClonable<T> where T : class
    {
        T Clone();
    }

    public class Point : IClonable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(Point other)
        {
            X = other.X;
            Y = other.Y;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Clone()
        {
            return new Point(this);
        }

        public string GetInfo()
        {
            return $"Point({X}, {Y})";
        }
    }

    public class Rectangle : IClonable<Rectangle>
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(Rectangle other)
        {
            Width = other.Width;
            Height = other.Height;
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Rectangle Clone()
        {
            return new Rectangle(this);
        }

        public string GetInfo()
        {
            return $"Rectangle({Width}x{Height})";
        }
    }

    class Program
    {
        public static T CreateClone<T>(T obj) where T : class, IClonable<T>
        {
            return obj.Clone();
        }

        static void Main()
        {
            Point point1 = new Point(5, 10);
            Point point2 = CreateClone(point1);

            Console.WriteLine("original " + point1.GetInfo());
            Console.WriteLine("clone " + point2.GetInfo());
            Console.WriteLine("different " + (point1 != point2));

            Console.WriteLine();

            Rectangle rect1 = new Rectangle(25, 5);
            Rectangle rect2 = CreateClone(rect1);

            Console.WriteLine("original " + rect1.GetInfo());
            Console.WriteLine("clone " + rect2.GetInfo());
            Console.WriteLine("different " + (rect1 != rect2));

            Console.ReadLine();
        }
    }
}

*/

using System;

namespace kt10
{
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }

    public struct ComplexNumber : IComparable<ComplexNumber>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public int CompareTo(ComplexNumber other)
        {
            double magnitude1 = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            double magnitude2 = Math.Sqrt(other.Real * other.Real + other.Imaginary * other.Imaginary);

            if (magnitude1 < magnitude2) return -1;
            if (magnitude1 > magnitude2) return 1;
            return 0;
        }

        public string GetInfo()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    public struct RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int CompareTo(RationalNumber other)
        {
            double value1 = (double)Numerator / Denominator;
            double value2 = (double)other.Numerator / other.Denominator;

            if (value1 < value2) return -1;
            if (value1 > value2) return 1;
            return 0;
        }

        public string GetInfo()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    class Program
    {
        static void Main()
        {
            ComplexNumber complex1 = new ComplexNumber(3, 4);
            ComplexNumber complex2 = new ComplexNumber(1, 2);

            Console.WriteLine("complex Numbers");
            Console.WriteLine("number 1 " + complex1.GetInfo());
            Console.WriteLine("number 2 " + complex2.GetInfo());
            Console.WriteLine("compare result " + complex1.CompareTo(complex2));

            Console.WriteLine();

            RationalNumber rational1 = new RationalNumber(3, 4);
            RationalNumber rational2 = new RationalNumber(1, 2);

            Console.WriteLine("rational Numbers:");
            Console.WriteLine("number 1 " + rational1.GetInfo());
            Console.WriteLine("number 2 " + rational2.GetInfo());
            Console.WriteLine("compare " + rational1.CompareTo(rational2));

            Console.ReadLine();
        }
    }
}