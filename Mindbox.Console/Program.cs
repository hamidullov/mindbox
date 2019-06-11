using System;
using Mindbox.Tools.Abstract;
using Mindbox.Tools.Shapes;

namespace Mindbox.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new IShape[]
            {
                new Circle(51),
                new Triangle(3, 4, 5),
                new Triangle(10, 24, 26),
                new Triangle(17, 15, 8),
                new Circle(2),
            };

            foreach (var shape in shapes)
            {
                System.Console.WriteLine($"{shape}\twith square {shape.Square}");
            }

            System.Console.ReadLine();
        }
    }
}
