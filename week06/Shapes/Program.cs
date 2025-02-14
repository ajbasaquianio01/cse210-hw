using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Yellow", 6);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Purple", 8, 10);
        shapes.Add(s2);

        Circle s3 = new Circle("White", 12);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}