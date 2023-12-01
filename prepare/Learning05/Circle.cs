using System.Formats.Asn1;

public class Circle : Shape {
    private double _radius = 0;

    public Circle(string color, double radius){
        SetColor(color);
        _radius = radius;
    }

    public override double GetArea()
    {
        double area = Math.PI * (_radius *_radius);
        return area;
    }
}