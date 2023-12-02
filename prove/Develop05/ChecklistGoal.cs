public class ChecklistGoal : Goal{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base (name, description, points){
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted ++;
        if (IsComplete() == false){
            Console.WriteLine();
            Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");  
        }
        else if (IsComplete() == true){
            Console.WriteLine();
            Console.WriteLine($"Congratulations! You have earned {GetPoints() + _bonus} points!");  
        }      
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target){
            return true;
        }
        else{
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string details = $"{GetName()} ({GetDescription()} -- Currently completed: {_amountCompleted}/{_target})";
        return details;
    }
 
    public override string GetStringRepresentation()
    {
        string representation = $"{GetName()}~~{GetDescription()}~~{GetPoints()}~~{_bonus}~~{_target}~~{_amountCompleted}";
        return representation;
    }
    public int GetBonus(){
        return _bonus;
    }
    public void SetAmountCompleted(int amountCompleted){
        _amountCompleted = amountCompleted;
    }
}