public abstract class Appointment{
    private string _name = " ";
    private string _description = " ";
    private string _date = " ";
    private string _time = " ";
    private string _endTime = " ";
    private bool _isFulfilled;

    public  Appointment(string name, string description, string date, string time, string endTime){
        _name = name;
        _description = description;
        _date = date;
        _time = time;
        _endTime = endTime;


    }

    public virtual void FulfillAppointment(){
         //This method is the method that each child class will use to mark a appointment as complete.
        SetFulfillment(true);
    }
   

    public abstract bool IsFulfilled();
    //This method should return true if the appointment is completed. 
    
 
    public abstract string GetDetailsString();
        //This method should return the details of a appointment that could be shown in a list. 
        //The string should include the checkbox, the name, and description and whatever is necessary for each appointment. 
    public abstract string GetStringRepresentation();
    //This method should provide all of the details of a appointment in a way that is easy to save to a file load later.

    public string GetName(){
        return _name;
    }
    public string GetDescription(){
        return _description;
    }

    public void SetFulfillment(bool fulfillment){
        _isFulfilled = fulfillment;
    }
    public bool GetFulfillment (){
        return _isFulfilled;
    }
    public string GetDate(){
        return _date;
    }
    public string GetStartTime(){
        return _time;
    }
    public string GetEndTime(){
        return _endTime;
    }

}