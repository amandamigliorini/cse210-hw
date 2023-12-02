public class SimpleGoal : Goal{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base (name, description, points){
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");                
    }

    public override bool IsComplete()
    {
        if (_isComplete == true){
            return true;
        }
        else{
            return false;
        }
    } 

    public override string GetStringRepresentation()
    {
        string representation = $"{GetName()}~~{GetDescription()}~~{GetPoints()}~~{IsComplete()}"; 
        return representation;        
    }
    public void SetCompletition(bool isComplete){
        _isComplete = isComplete;
    }
}