public class PersonalAppointment : Appointment{

    public PersonalAppointment(string name, string description, string date, string time, string endTime){ 
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