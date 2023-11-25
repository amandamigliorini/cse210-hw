using Microsoft.VisualBasic;

public class Activity{
    private string _name;
    private string _description;
    private string _duration;

    public Activity(string name, string description){
        // clear console and set name, description.
        Console.Clear();
        _name = name;
        _description = description;
           
    }
    public int GetDuration(){
        string sDuration = _duration;
        int duration = int.Parse(sDuration);
        return duration;
    }
    // set duration of the activity and display the starting message.
    public void DisplayStartingMessage(){    
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine("");
        Console.WriteLine(_description);
        Console.WriteLine("");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = Console.ReadLine();
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("Well done!!\n");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

//show an animation spinner
    public void ShowSpinner(int seconds){
        List<string> animation = new List<string>();
        animation.Add("|");
        animation.Add("/");
        animation.Add("-");
        animation.Add("\\");
        animation.Add("|");
        animation.Add("/");
        animation.Add("-");
        animation.Add("\\");
        
        // one animation of 8 strings complete will take 1 second (1000/8 = 125), repeating seconds time the loop that will
        // write each string will make the spinner work exactly the programmed seconds and the animation looks faster.
        for (int i = seconds; i > 0;  i--){
            foreach (string a in animation){
                Console.Write(a);
                Thread.Sleep(125);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine();
    }

    // show a numeric countdown
    public void ShowCountDown(int seconds){
        for (int i = seconds; i > 0;  i--){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    //Exceeding requirements: Loading the prompts from a file.
    //Reflecting Activity and Listing Activity share this code. So it was defined in the base class Activity.
    // This way I have less lines of code, and I can add more prompts, questions, etc directly on the files and it will update the program as well.
    public void LoadListFromFile(List<string> list, string fileName){
    
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines){
            list.Add(line);      
        }
    }
}