using System.Formats.Asn1;

public class Rectangle : Shape {
    private double _length = 0;
    private double _width = 0;

    public Rectangle(string color, double length, double width){
        SetColor(color);
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        double area = _length * _width;
        return area;
    }
}