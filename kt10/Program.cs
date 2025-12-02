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