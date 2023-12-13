public class PersonalAppointment : Appointment{

    public PersonalAppointment(string name, string description, string date, string time, string endTime) : base(name, description, date, time, endTime){ 
    }

    public override string GetDetailsString(){
        
        return $"Date: {GetDate()}\n Time: {GetStartTime()} - {GetEndTime()}\n{GetName()}\n{GetDescription()}";
    }
    public override string GetStringRepresentation(){
        return $"{GetName()}~~{GetDate()}~~{GetStartTime()}~~{GetEndTime()}~~{GetDescription()}~~{GetFulfillment()}";
    }

    public override bool IsFulfilled(){
        return GetFulfillment();
    }

}