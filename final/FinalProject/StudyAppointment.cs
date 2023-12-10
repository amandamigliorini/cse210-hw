using System.Text.Encodings.Web;

public class StudyAppointment : Appointment
{
    private string _course;
    private string _instructor;



    public StudyAppointment(string name, string description, string date, string time, string endTime){
        Console.Write("What is the name of the course? ");
        _course = Console.ReadLine();
        Console.Write("What is the name of the instructor? ");
        _instructor = Console.ReadLine();


    }


    public override string GetDetailsString()
    {
        
        return $" ";
    }
        public override void FulfillAppointment(){

    }
        public override string GetStringRepresentation(){
        return $"";
    }

    public override bool IsFulfilled()
    {
        return false;
    }
}

