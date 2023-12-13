public class WorkAppointment : Appointment{
    private string _projectName;
    private int _steps;
    private int _stepsDone;

    public WorkAppointment(string name, string description, string date, string time, string endTime) : base(name, description, date, time, endTime){
        Console.Write("What is the name of the project? ");
        _projectName = Console.ReadLine();
        Console.Write("What is the the quantity of steps of the project? ");
        _steps = int.Parse(Console.ReadLine());
        Console.Write("What is the the quantity of steps already done of the project? ");
        _stepsDone = int.Parse(Console.ReadLine());

    }
    public WorkAppointment(string name, string description, string date, string time, string endTime, string projectName, int steps, int stepsDone) : base(name, description, date, time, endTime){
        _projectName = projectName;
        _steps = steps;
        _stepsDone = stepsDone;
        
    }
    public override string GetDetailsString()
    {
        
        return $"Date: {GetDate()}\n Time: {GetStartTime()} - {GetEndTime()}\n{GetName()}\n{GetProject()}\n{GetDescription()}\n{GetStepsDone()} of {GetSteps()} steps done.";
    }

    public override string GetStringRepresentation(){
        return $"{GetName()}~~{GetDate()}~~{GetStartTime()}~~{GetEndTime()}~~{GetProject()}~~{GetDescription()}~~{GetSteps()}~~{GetStepsDone()}~~{GetFulfillment()}";
    }

    public override bool IsFulfilled()
    {
        if (_stepsDone == _steps){
            SetFulfillment(true);
            return true;
        }
        else{
            return false;
        }
    }

    public override void FulfillAppointment()
    {
        Console.WriteLine("How many steps of the project did you fulfilled?");
        _stepsDone = int.Parse(Console.ReadLine());
    }

    public string GetProject(){
        return _projectName;
    }
    public int GetSteps(){
        return _steps;
    }
     public int GetStepsDone(){
        return _stepsDone;
    }
}