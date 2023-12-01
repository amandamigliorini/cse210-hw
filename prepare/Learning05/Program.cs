using System;

class Program
{
    static void Main(string[] args)
    {
       List<Shape> shapes = new List<Shape>();
       
       Square s1 = new Square("red", 2);
        shapes.Add(s1);

       Circle c1 = new Circle("blue", 3);
        shapes.Add(c1);

       Rectangle r1 = new Rectangle("Pink", 3, 6);
       shapes.Add(r1);

       foreach(Shape shape in shapes){
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}");
            Console.WriteLine();
       }

       



    }
}