public class VolunteerAppointment : Appointment{
    private string _place;
    private string _address;

    public VolunteerAppointment(string name, string description, string date, string time, string endTime) : base(name, description, date, time, endTime){
        Console.Write("What is the place of the volunteer activity? ");
        _place = Console.ReadLine();
        Console.Write("What is the address of the volunteer activity? ");
        _address = Console.ReadLine();

    }
    public VolunteerAppointment(string name, string description, string date, string time, string endTime, string place, string address) : base(name, description, date, time, endTime){
        _place = place;
        _address = address;
    }

    public override string GetDetailsString()
    {
        
        return $"Date: {GetDate()}\n Time: {GetStartTime()} - {GetEndTime()}\n{GetName()}\n{GetPlace()} - {GetAddress()}\n{GetDescription()}";
    }

    public override string GetStringRepresentation(){
        return $"{GetName()}~~{GetDate()}~~{GetStartTime()}~~{GetEndTime()}~~{GetPlace()}~~{GetAddress()}~~{GetDescription()}~~{GetFulfillment()}";
    }

    public override bool IsFulfilled()
    {
        return GetFulfillment();
    }

    public string GetPlace(){
        return _place;
    }
      public string GetAddress(){
        return _address;
    }
}