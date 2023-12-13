using System.Globalization;
public class Time {
    private DateTime _start;
    private DateTime _end;
   
    

    public Time(string date, string start, string end){
        date = date.Trim();
        start = start.Trim();
        end = end.Trim();
        _start = DateTime.ParseExact($"{date} {start}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

        _end = DateTime.ParseExact($"{date} {end}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
    }

    public bool IsOccupied(List<Time> times){
        foreach (Time time in times){
            if ((_start >= time._start && _start < time._end) || (time._start >= _start && time._start < _start + (_end - _start))){
                return true;
            }
        }
        return false;
    }



}