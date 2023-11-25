public class ListingActivity : Activity{
    private int _count = 0;
    private List<string> _prompts = new List<string>();
        
    public ListingActivity() : base("Listing Activity", 
                                    "This activity will help you reflect on the good things in your life by having you list" 
                                    + " as many things as you can in a certain area.")
    {
         DisplayStartingMessage(); 
         LoadListFromFile(_prompts, "ListingPrompts.txt");
    }

    public void Run(){
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        GetListFromUser();
        Console.WriteLine();
        DisplayEndingMessage();
    }

    public void GetRandomPrompt(){
        Random indexRandom = new Random();
        int index = indexRandom.Next(0,_prompts.Count);
        string prompt = _prompts[index];
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
    }
    
    public List<string> GetListFromUser(){
        List<string> _list = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime){
            Console.Write("> ");
            string entry = Console.ReadLine();
            _list.Add(entry);
            _count += 1;
        }
        Console.WriteLine($"You listed {_count} items!");
        return _list;
    }
}