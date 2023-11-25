using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        string choice;
        static string Menu(){
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            return Console.ReadLine();
        }

        choice = Menu();

        while (choice != "4"){
            if (choice == "1"){
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                choice = Menu();
            }
            else if (choice == "2"){
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                choice = Menu();
            }
            else if (choice == "3"){
                ListingActivity listing = new ListingActivity();
                listing.Run();
                choice = Menu();
            }
            // Exceeding requirements: Dealing with the case of the user type something that is not on the menu.
            else{
                Console.Clear();
                Console.WriteLine("Please, choose a valid option.");
                Thread.Sleep(2000);
                Console.WriteLine();
                choice = Menu();
            }
        }

    }
}