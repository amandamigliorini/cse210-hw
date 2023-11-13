public class Fraction 
{
    private int _top;
    private int _bottom;

    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

    public Fraction (int wholeNumber){
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction (int top, int bottom){
        _top = top;
        _bottom = bottom;
    }

    public void SetTop(int top){
        _top = top;
    }

    public int GetTop(){
        return _top;
    }

    public void SetBottom(int bottom){
    _bottom = bottom;
    }

    public int GetBottom(){
        return _bottom;
    }

    public string GetFractionString(){
        string top = _top.ToString();
        string bottom = _bottom.ToString();
        string fractionString = ($"{top}/{bottom}");
        return fractionString;
    }

    public double GetDecimalValue(){
        return (double)_top/(double)_bottom;
    }



}