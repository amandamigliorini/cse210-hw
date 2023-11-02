using System;

class Program
{
    static void Main(string[] args)
    {

        string keepGaming = "yes";

        do {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess;
        int guesses = 0;

           do{
            Console.Write("What is your guess? ");
            string sGuess = Console.ReadLine();
            guess = int.Parse(sGuess);
            guesses ++;
            if (guess < magicNumber) {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber){
                Console.WriteLine("Lower");
            }
            else if (guess == magicNumber){
                Console.WriteLine ($"You guessed it! And you guessed it in {guesses} guesses!");
                Console.Write("Do you want to play it again? (yes/no) ");
                keepGaming = Console.ReadLine();
            }
        }while (guess != magicNumber);
 
        }while (keepGaming == "yes");

        Console.WriteLine ("Thank you!");
        
    } 
            
    
}