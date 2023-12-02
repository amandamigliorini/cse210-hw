public class GoalManager{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager(){
        //Initializes and empty list of goals and sets the player's score to be 0.
        _score = 0;   
    }

    public void Start(){
        //This is the "main" function for this class. It is called by Program.cs, and then runs the menu loop.        
        string choice = "";
        while (choice != "6"){
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: "); 
            choice = Console.ReadLine();
            
            if (choice == "1"){
                CreateGoal();
            }
            else if (choice == "2"){
                ListGoalDetails();
            }
            else if (choice == "3"){
                SaveGoals();
            }
            else if (choice == "4"){                
                LoadGoals();
            }
            else if (choice == "5"){
                RecordEvent();
            }
            else if (choice == "6"){
                Console.WriteLine("Thank you");
            }
            // exceeding requirement: preventing error in case the user types a wrong choice
            else {
                Console.WriteLine("Please select a valid option");
                Console.Write("Select a choice from the menu: "); 
                choice = Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo(){
        //Displays the players current score.
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points");
        Console.WriteLine();
    }

    public void ListGoalNames(){
        //Lists the names of each of the goals.
        int i = 1;
        foreach (Goal goal in _goals){
            Console.WriteLine($"{i}. {goal.GetName()}.");
            i ++;     
        } 
        Console.WriteLine();       
    }

    public void ListGoalDetails(){
        //Lists the details of each goal (including the checkbox of whether it is complete).
        Console.Clear();
        int i = 1;
        foreach (Goal goal in _goals){
            if (goal.IsComplete() == false){
                Console.WriteLine($"{i}. [ ] {goal.GetDetailsString()}.");
                i ++;
            }
            else if (goal.IsComplete() == true){
                Console.WriteLine($"{i}. [X] {goal.GetDetailsString()}.");
                i ++;
            }     
        }
        DisplayPlayerInfo();
    }

    public void CreateGoal(){
        //Asks the user for the information about a new goal. Then, creates the goal and adds it to the list.
        string choice = "";
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklists Goal");
        Console.WriteLine(" 4. Financial Goal");
        Console.Write("Which type of goal would you like to create? ");
        choice = Console.ReadLine();
        if (choice == "1"){
            SimpleGoal simpleGoal = new SimpleGoal(DefineName(), DefineDescription(), DefinePoints());
            _goals.Add(simpleGoal);
        }
        else if (choice == "2"){
            EternalGoal eternalGoal = new EternalGoal(DefineName(), DefineDescription(), DefinePoints());
            _goals.Add(eternalGoal);
        }
        else if (choice == "3"){            
            ChecklistGoal checklistGoal = new ChecklistGoal(DefineName(), DefineDescription(), DefinePoints(), DefineTarget(), DefineBonus());
            _goals.Add(checklistGoal);
        }
        else if (choice == "4"){
            FinancialGoal financialGoal = new FinancialGoal(DefineName(), DefineDescription(), DefinePoints(), DefineAmountDesired(), DefineAmountSaved(), DefineBonus(), DefineReason());
            _goals.Add(financialGoal);
        }
    }

    public void RecordEvent(){
        //Asks the user which goal they have done and then records the event by calling the RecordEvent method on that goal.
        Console.Clear();
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());
        int index = choice - 1;
        
        // exceeding requirement: preventing error in case the user types a wrong choice
        while (_goals.Count < choice){
            Console.WriteLine("Couldn't find this goal");
            Console.Write("Which goal did you accomplish? ");
            choice = int.Parse(Console.ReadLine());
            index = choice - 1;
        }
        
        //calls RecordEvent from the goal
        _goals[index].RecordEvent();
        //verify if the goal is a checklist goal because this goal has a bonus in case of the goal is complete.
        if (_goals[index] is ChecklistGoal checklistGoal){
            //verify if the goal is complete, if it is then the bonus is added to the score as well as the points
            if (_goals[index].IsComplete()){
                _score += _goals[index].GetPoints();
                _score += checklistGoal.GetBonus();
            }
            //if the goal is not complete only add the points to the score
            else{
                _score += _goals[index].GetPoints();
            }
        }
         //verify if the goal is complete, if it is then the bonus is added to the score as well as the points
        if (_goals[index] is FinancialGoal financialGoal){
            //verify if the goal is complete, if it is then the bonus is added to the score as well as the points
            if (_goals[index].IsComplete()){
                _score += _goals[index].GetPoints();
                _score += financialGoal.GetBonus();
            }
            //if the goal is not complete only add the points to the score
            else{
                _score += _goals[index].GetPoints();
            }
        }
        // if is not a checklist goal, just add the points to the score
        else{
            _score += _goals[index].GetPoints();
        }
        DisplayPlayerInfo();
    }

    public void SaveGoals(){
        //Saves the list of goals to a file.
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"{_score}");
            foreach (Goal goal in _goals) {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }     
        }
        //Exceeding requirements: Adding a follow-up to the user about saving their goals.
        Thread.Sleep(1000);
        Console.WriteLine();
        Console.WriteLine("File saved");

    }
    public void LoadGoals(){
        //Loads the list of goals to a file.
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        _goals.Clear();

        foreach (string line in lines){
            string[] parts = line.Split("~~");
            if (parts.Count() == 1){
                _score = int.Parse(parts[0]);
            }
            else if (parts.Count() == 3){
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
            }
            else if (parts.Count() == 4){
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                bool completition = bool.Parse(parts[3]);
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                simpleGoal.SetCompletition(completition);
                _goals.Add(simpleGoal);
            }
            else if (parts.Count() == 6){
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                int bonus = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int amountCompleted = int.Parse(parts[5]);
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                checklistGoal.SetAmountCompleted(amountCompleted);
                _goals.Add(checklistGoal);
            }
            else if (parts.Count() == 7){
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                int bonus = int.Parse(parts[3]);
                int amountDesired = int.Parse(parts[4]);
                int amountSaved = int.Parse(parts[5]);
                string reason = parts[6];
                FinancialGoal financialGoal = new FinancialGoal(name, description, points, amountDesired, amountSaved, bonus, reason);
                _goals.Add(financialGoal);
            }
        }
        Thread.Sleep(1000);
        Console.WriteLine();
        Console.WriteLine("File loaded");
        Console.WriteLine();
    }

    private string DefineName(){
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        return name;
    }
    private string DefineDescription(){
        Console.Write("What is a short description of it? ");
       string description = Console.ReadLine();
       return description;
    }
    private int DefinePoints(){
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        return points;
    }

    private int DefineTarget(){
        Console.Write("How many times does this goal need to be accomplished? ");
        int target = int.Parse(Console.ReadLine());
        return target;
    }

    private int DefineBonus(){
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int target = int.Parse(Console.ReadLine());
        return target;
    }

    private int DefineAmountDesired(){
        Console.Write("What is the amount desired to be saved? ");
        int amountDesired = int.Parse(Console.ReadLine());
        return amountDesired;
    }
    private int DefineAmountSaved(){
        Console.Write("What is the amount already saved? ");
        int amountSaved = int.Parse(Console.ReadLine());
        return amountSaved;
    }
    private string DefineReason(){
        Console.Write("Describe shortly the reason of this saving: ");
       string reason = Console.ReadLine();
       return reason;
    }
}