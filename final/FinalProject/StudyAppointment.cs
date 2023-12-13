using System.Text.Encodings.Web;

public class StudyAppointment : Appointment
{
    private string _course;
    



    public StudyAppointment(string name, string description, string date, string time, string endTime) : base(name, description, date, time, endTime){
        Console.Write("What is the name of the course? ");
        _course = Console.ReadLine();   
    }
     public StudyAppointment(string name, string description, string date, string time, string endTime, string course) : base(name, description, date, time, endTime){
        _course = course;
        
     }

    public override string GetDetailsString()
    {
        
        return  $"Date: {GetDate()}\n Time: {GetStartTime()} - {GetEndTime()}\n{GetName()}\n{_course}\n{GetDescription()}";
    }

    public override string GetStringRepresentation(){
        return  $"{GetName()}~~{GetDate()}~~{GetStartTime()}~~{GetEndTime()}~~{_course}~~{GetDescription()}~~{GetFulfillment()}";
    }

    public override bool IsFulfilled(){
        return GetFulfillment();
    }
    public string GetCourse(){
        return _course;
    }
}

