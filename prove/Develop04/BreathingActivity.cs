public class BreathingActivity : Activity{
    public BreathingActivity() : base("Breathing Activity", 
                                    "This activity will help you relax by walking your through breathing in and out slowly." 
                                    + " Clear your mind and focus on your breathing.")
    {
         DisplayStartingMessage(); 

    }

    public void Run(){
        int duration = GetDuration();
        // preventing an error in the loop in case the time choosed by the user is not divided by 10
        int gap = duration % 10;
        // deciding how many breathing exercises the user will made. Each breathing exercise will take 10 seconds.
        int breathingTimes = (duration - gap)/10;
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        // using the gap of time to add one more breathing activity if the gap is more then 5.
        if (gap >= 5){
            if (gap % 2 != 0){
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountDown((gap - (gap % 2))/2);
                Console.Write("Breathe out...");
                ShowCountDown((gap + (gap % 2))/2);
            }
            else if (gap % 2 == 0){
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountDown((gap/2)-1);
                Console.Write("Breathe out...");
                ShowCountDown((gap/2)+1);
            }
        }
        // Displaying breathing exercise. 
        for (int i = 0; i < breathingTimes; i++){
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.Write("Breathe out...");
            ShowCountDown(6);
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}