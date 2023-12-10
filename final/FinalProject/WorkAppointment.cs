public class WorkAppointment : Appointment{
    private string _projectName;
    private int _steps;
    private int _stepsDone;

    public WorkAppointment(string name, string description, string date, string time, string endTime){
        Console.Write("What is the name of the project? ");
        _projectName = Console.ReadLine();
        Console.Write("What is the the quantity of steps of the project? ");
        _steps = int.Parse(Console.ReadLine());
        Console.Write("What is the the quantity of steps already done of the project? ");
        _stepsDone = int.Parse(Console.ReadLine());

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