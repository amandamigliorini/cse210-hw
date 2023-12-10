public class VolunteerAppointment : Appointment{
    private string _place;
    private string _address;

    public VolunteerAppointment(string name, string description, string date, string time, string endTime){
        Console.Write("What is the place of the volunteer activity? ");
        _place = Console.ReadLine();
        Console.Write("What is the address of the volunteer activity? ");
        _address = Console.ReadLine();

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