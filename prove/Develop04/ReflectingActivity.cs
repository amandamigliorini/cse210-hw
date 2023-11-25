public class ReflectingActivity : Activity{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private List<int> _indexes = new List<int>();

    public ReflectingActivity() : base("Reflecting Activity", 
                                    "This activity will help you reflect on times in your life when you have shown strength and resilience." 
                                    + " This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        DisplayStartingMessage(); 
        LoadListFromFile(_prompts, "Prompts.txt");
        LoadListFromFile(_questions, "Questions.txt");
    }

    public void Run(){
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        DisplayPrompt();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
        Console.WriteLine();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt(){
        Random indexRandom = new Random();
        int index = indexRandom.Next(0,_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }

    public string GetRandomQuestion(){
        // get a random question from the _question list.
        //Exceed requirements. Added the index used to the _indexes list and verify if the index was already used.
        // In case the index was used, the program gets another Random Question to Display.
        int index;
        Random indexRandom = new Random();
        index = indexRandom.Next(0,_questions.Count);
        while (_indexes.Contains(index)){
            index = indexRandom.Next(0,_questions.Count);
        }
        _indexes.Add(index);

        string question = _questions[index];
        return question;
    }

    public void DisplayPrompt(){
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        string ready = Console.ReadLine();
    }

    public void DisplayQuestions(){
        int spinnerTime = 10;
        int duration = GetDuration();
         // preventing an error in the loop in case the time choosed by the user is not divided by 10
        int gap = duration % spinnerTime;
        // deciding how many reflection question the user will answer. Each exercise will take 10 seconds.
        int quantity = (duration - gap)/spinnerTime;
        if (quantity > _questions.Count){
            quantity = _questions.Count;
            spinnerTime = duration/quantity;
        }
        
        // displaying each question
        for (int i = 0; i < quantity; i++){
        string question = GetRandomQuestion();
        Console.Write($"> {question} ");
        ShowSpinner(spinnerTime);  
        }
    }
}