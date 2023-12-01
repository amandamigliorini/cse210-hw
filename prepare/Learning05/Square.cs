using System.Formats.Asn1;

public class Square : Shape {
    private double _side = 0;

    public Square(string color, double side){
        SetColor(color);
        _side = side;
    }

    public override double GetArea()
    {
        double area = _side * _side;
        return area;
    }
}