using System;

class Program
{
    static void Main(string[] args)
    {
        // core requirements
        Console.Write("What is your grade percentage? ");
        string sPercentage = Console.ReadLine();
        int percentage = int.Parse(sPercentage);
        string letter = "";
        string result = "";
        string sign;
        if (percentage >= 90){
            letter = "A";
        }
        else if (percentage >= 80 && percentage < 90){
            letter = "B";
        }
        else if (percentage >= 70 && percentage < 80){
            letter = "C";
        }
        else if (percentage >= 60 && percentage < 70){
            letter = "D";
        }
        else if (percentage < 60){
            letter = "F";
        }

        if (percentage >=70){
            result = "Congratulations! You passed this class!";
        }
        else {
            result = "I am sorry you have failed this class. But, don't give up, use the knowledge you already have and try it again!";
        }
        // stretch requirements:
        if (percentage % 10 >= 7 && percentage < 97 && letter != "F"){
            sign = "+";
            Console.WriteLine($"Your grade is {letter}{sign}.");
        }
        else if (percentage % 10 < 7 && percentage < 97 && letter != "F"){
            sign = "-";
            Console.WriteLine($"Your grade is {letter}{sign}.");
        }
        else{
            Console.WriteLine($"Your grade is {letter}.");
            
        }
  
        Console.WriteLine(result);
    }
}