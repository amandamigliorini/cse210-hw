using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        static void Menu(){
            // EXCEEDING REQUIREMENTS. HAVING A MENU WILL HELP IN READING THE PROGRAM AND SPARE LINES OF CODE
            Console.WriteLine("\nPlease, select one of the following choices:");
            Console.WriteLine("\n1.Write with random prompt\n2.Write with no prompt\n3.Display\n4.Load\n5.Save\n6.Quit");
            Console.WriteLine("What would you like to do? ");
            Console.Write(">>> ");
        }

        //FIRST INTERACTION WITH THE USER
        Console.WriteLine("Welcome to the Journal Program!");
        // HELPING THE USER UNDERSTAND THE JOURNAL PROGRAM
        Console.WriteLine("\nPLEASE NOTE THAT IF YOU CHOOSE TO WRITE BEFORE LOAD, YOU WILL BE STARTING A NEW JOURNAL.\nTHE MOMENT YOU SAVE IT, YOU'LL BE DELETING THE OLD ONE");
        
        Menu();
        int choice = int.Parse(Console.ReadLine());
        Journal myJournal = new Journal();        
        
        while (choice != 7){
            if (choice == 1){
                // ADDING NEW ENTRY
                Entry entry = new Entry();
                myJournal.AddEntry(entry);
              
                // USING ENTRIES LIST TO STORE THE ENTRY 
                myJournal._Entries.Add(entry);
                Console.WriteLine("\nThank You!!\n");
                Menu();
                choice = int.Parse(Console.ReadLine());
            }
            else if (choice == 2){
                // EXCEEDING REQUIREMENTS: IN CASE THE USER DON'T WANT TO USE A PROMPT, THEY CAN START ONE PERSONAL ENTRY
                // PERSONAL ENTRY WILL STORE A TITLE THAT THE USER WILL WRITE INSTEAD OF USING PROMPT
                // STARTING NEW ENTRY
                Entry personalEntry = new Entry();
                myJournal.AddPersonalEntry(personalEntry);                
               
                // USING ENTRIES LIST TO STORE THE ENTRY 
                myJournal._Entries.Add(personalEntry);
                
                Console.WriteLine("\nThank You!!\n");
                Menu();
                choice = int.Parse(Console.ReadLine());
            }
            else if (choice == 3){
                // EXCEEDING REQUIREMENTS: iF THE USER DIDN'T LOAD THE JOURNAL OR STARTED A NEW ONE, THERE'S NOTHING TO DISPLAY
                // A SIMPLE SOLUTION: CHECKING IF THERES SOMETHING TO DISPLAY AND, CASE NOT, INTERACTING WITH THE USER ABOUT IT
                if (myJournal._Entries.Count <= 0){
                    Console.WriteLine("You don't have any entries in your Journal. Please load your entries or start a new journal first.");
                    Console.WriteLine("Thank You!!\n");
                    Menu();
                    choice = int.Parse(Console.ReadLine());
                }
                //CALLING DISPLAY ENTRIES TO DISPLAY ALL JOURNAL
                else{                                   
                    myJournal.DisplayEntries();
                    Console.WriteLine("");
                    Menu();
                    choice = int.Parse(Console.ReadLine());
                }
            }
            else if (choice == 4){
                // MESSAGING ABOUT WHAT IS HAPPENING IN THE PROGRAM AND MAKING THE USER ASSURED THAT EVERYTHING WENT WELL
                Console.WriteLine("Loading Your Journal.....");
                myJournal.LoadJournal();
                Console.WriteLine("Journal Loaded");
                myJournal.DisplayEntries();

                Menu();
                choice = int.Parse(Console.ReadLine());                
            }
            else if (choice == 5){
                // MESSAGING ABOUT WHAT IS HAPPENING IN THE PROGRAM AND MAKING THE USER ASSURED THAT EVERYTHING WENT WELL
                Console.WriteLine("Saving Your Journal.....");
                myJournal.SaveJournal();
                Console.WriteLine("Journal Saved");
               
                Menu();
                choice = int.Parse(Console.ReadLine());
            }
            else if (choice == 6){
                // EXCEEDING REQUIREMENTS: QUITTING CHOICES IN ORDER TO HELP THE USER TO NOT LOSE THEIR NEW ENTRIES
                Console.Write("Please, choose one option:\n1.Save and Quit.\n2.Quit without saving.");
                int quitChoice = int.Parse(Console.ReadLine());
                // EXCEEDING REQUIREMENTS: QUITTING CHOICES IN ORDER TO HELP THE USER TO NOT LOSE THEIR JOURNAL
                // IN CASE THEY JUST OPENED THE PROGRAM BUT DIDN'T INTERACT WITH IT
                if (quitChoice == 1){
                    Console.WriteLine("If you didn't load your journal previously, that can erase your previous entries.");
                    Console.WriteLine("Did you load or updated your journal previously?");
                    Console.WriteLine("1.Yes, please continue saving.\n2.No, I'll quit whithout saving");
                    Console.Write(">>> ");
                    int loaded = int.Parse(Console.ReadLine());
                    
                    if (loaded == 1){
                        Console.WriteLine("Saving Your Journal.....");
                        myJournal.SaveJournal();
                        Console.WriteLine("Journal Saved");
                    
                        Console.WriteLine("\nThank You!!\n");
                        // ENDING PROGRAM
                        choice = 7;
                    }
                    if (loaded == 2){
                        quitChoice = 2;
                    }

                }
                if (quitChoice == 2){
                    Console.WriteLine("\nThank You!!\n");
                    // ENDING PROGRAM
                    choice = 7;
                }
            }
        }
    }
}