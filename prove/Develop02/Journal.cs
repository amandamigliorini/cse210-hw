
class Journal
{
    public List<Entry>_Entries = new List<Entry>();
    public void DisplayEntries(){
        foreach (Entry entry in _Entries) {
            entry.DisplayEntry();
        }
    }
    
    public void SaveJournal(){
    
        string fileName = "myJournal.txt";
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _Entries) {
                outputFile.WriteLine($"{entry._date}~~{entry._entryTitle}~~{entry._entryText}");
            }     
        }        
    }

    public void LoadJournal(){
        _Entries = new List<Entry>();
        string fileName = "myJournal.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines){
            string[] parts = line.Split("~~");

            string date = parts[0];
            string title = parts[1];
            string entry = parts[2];

            Entry loadedEntry = new Entry();
            loadedEntry._date = date;
            loadedEntry._entryTitle = title;
            loadedEntry._entryText = entry;
            _Entries.Add(loadedEntry);      
        }
    }

    public void AddEntry(Entry entry){
        PrompGenerator prompt = new PrompGenerator();
        //Entry entry = new Entry();
        prompt.DisplayPrompt();
        // SAVING PROMPT AS THE ENTRY TITLE.
        entry._entryTitle = prompt._prompt;                
        
        // INTERACTING WITH THE USER TO FULFILL ENTRY
        Console.WriteLine($"\nWrite your text entry:");
        Console.Write(">>> ");
        entry._entryText = Console.ReadLine();
        
        string date = entry.GetDate();
        entry._date = date;
    }

    public void AddPersonalEntry(Entry personalEntry){
        // INTERACTING WITH THE USER TO FULFILL ENTRY
        Console.WriteLine("\nWhat is the title of your entry? ");
        Console.Write(">>> ");
        personalEntry._entryTitle = Console.ReadLine();
        personalEntry._entryTitle = personalEntry._entryTitle.ToUpper();
        
        Console.WriteLine($"\nWrite your text entry:");
        Console.Write(">>> ");
        personalEntry._entryText = Console.ReadLine();
        
        string date = personalEntry.GetDate();
        personalEntry._date = date;
    }


}

 

