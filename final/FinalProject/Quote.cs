public class Quote{
    string _quote;
    string _author;
    List <string> _quotes = new List <string>();
    List <string> _authors = new List <string>();

    public Quote(){
        LoadQuotes();
        DisplayRandomQuote();
       

    }

    public void LoadQuotes(){
       string fileName = "Quotes.txt";
       string[] lines = System.IO.File.ReadAllLines(fileName);

       foreach (string line in lines){
        string[] parts = line.Split("~~");

        string quote = parts[0];
        string author = parts[1];

        _quotes.Add(quote);
        _authors.Add(author);      
        }
    }


    public void DisplayRandomQuote(){
        Random indexRandom = new Random();
        int index = indexRandom.Next(0,_quotes.Count);
        string quote = _quotes[index];
        string author = _authors[index];
        Console.WriteLine(quote);
        Console.WriteLine(author);
        
    }

    private void SetQuote(string quote){
        _quote = quote;
    }
     private void SetAuthor(string author){
        _author = author;
    }
}