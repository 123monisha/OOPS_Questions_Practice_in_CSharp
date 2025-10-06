using System;

namespace OOPS_Questions_Practice_in_CSharp
{
    abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();

    }
    class Circle:Shape
    {
        private double radius;
        public Circle(double r)
        {
            radius = r
;        }
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double h,double w)
        {
            height = h;
            width = w;
;
        }
        public override double GetArea()
        {
            return height * width;
        }
        public override double GetPerimeter()
        {
            return 2 * (height * width);
        }
    }
    class Triangle : Shape
    {
        private double a, b, c;  
        public Triangle(double sideA, double sideB, double sideC)
        {
            a = sideA;
            b = sideB;
            c = sideC;
        }
        public override double GetArea()
        {
            double s = (a + b + c) / 2;  
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public override double GetPerimeter()
        {
            return a + b + c;
        }
    }
    internal class Shape_Geometry
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle(5);          // radius = 5
            Rectangle rectangle = new Rectangle(4, 6); // length = 4, width = 6
            Triangle triangle = new Triangle(3, 4, 5); // sides = 3, 4, 5

            // Call and print Circle methods
            Console.WriteLine("Circle:");
            Console.WriteLine("Area: " + circle.GetArea());
            Console.WriteLine("Perimeter: " + circle.GetPerimeter());
            Console.WriteLine();

            // Call and print Rectangle methods
            Console.WriteLine("Rectangle:");
            Console.WriteLine("Area: " + rectangle.GetArea());
            Console.WriteLine("Perimeter: " + rectangle.GetPerimeter());
            Console.WriteLine();

            // Call and print Triangle methods
            Console.WriteLine("Triangle:");
            Console.WriteLine("Area: " + triangle.GetArea());
            Console.WriteLine("Perimeter: " + triangle.GetPerimeter());

        }
    }
}
