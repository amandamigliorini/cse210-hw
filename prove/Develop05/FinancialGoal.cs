public class FinancialGoal : Goal{
    //Exceeding requirements: adding a new goal type, with attributes and behaviors

    private int _amountSaved;
    private int _amountDesired;
    private int _bonus;
    private string _reason;

    public FinancialGoal(string name, string description, int points, int desired, int amountSaved, int bonus, string reason) : base (name, description, points){
        _amountSaved = amountSaved;
        _amountDesired = desired;
        _bonus = bonus;
        _reason = reason;
    }

    public override void RecordEvent()
    {
        Console.Write("What was the amount you saved? ");        
        _amountSaved += int.Parse(Console.ReadLine());
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
        if (_amountSaved >= _amountDesired){
            return true;
        }
        else{
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string details = $"{GetName()} ({GetDescription()} -- Currently completed: ${_amountSaved}/${_amountDesired}) -- (Saving for {_reason})";
        return details;
    }
 
    public override string GetStringRepresentation()
    {
        string representation = $"{GetName()}~~{GetDescription()}~~{GetPoints()}~~{_bonus}~~{_amountDesired}~~{_amountSaved}~~{_reason}";
        return representation;
    }
    public int GetBonus(){
        return _bonus;
    }

}