public class EternalGoal : Goal{

    public EternalGoal(string name, string description, int points) : base (name, description, points){

    }

    public override void RecordEvent()
    {
        Console.WriteLine();
        Console.WriteLine($"Congratulations! You have earned {GetPoints()} points!");      
    }

    public override bool IsComplete()
    {
        bool completed = false;
        return completed;
        
    }

    public override string GetStringRepresentation()
    {
        string representation = $"{GetName()}~~{GetDescription()}~~{GetPoints()}";
        return representation;
    }
 
}