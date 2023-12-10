public class Time {
    private string _start="";
    private string _end ="";
    private bool _isOccupied = false;
    List <Time> _times = new List<Time>();

    public Time(string start, string end){
        _start = start;
        _end = end;
        

    }

    public bool IsOccupied(){
        // not finished 
        return _isOccupied;
    }



}