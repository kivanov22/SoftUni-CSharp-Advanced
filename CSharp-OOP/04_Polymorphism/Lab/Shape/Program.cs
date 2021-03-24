using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>()
                {
                    new Circle(2.6),
                    new Circle(12.3),
                    new Rectangle(4.4, 9.3),
                    new Rectangle(1.4, 2.7),
                    
                };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Shape {0}\nPerimeter = {1}\nArea = {2}\n", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
