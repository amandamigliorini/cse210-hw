public class Scripture {
    //Keeps track of both the reference and the text of the scripture. 
    //Can hide words and get the rendered display of the text.
    private int _index;
    private string _randomScripture = "";
    private string _referenceString = "";
    private string _quote = "";
    private Reference _reference;
    private List<Word> _Words = new List<Word>();
    private List<string> _ReferencesTexts = new List<string>();
    private List<string> _ScriptureTexts = new List<string>();
    private string _quoteHidded = " ";


    public Scripture(){
        //buiding Scripture using all behaviors that will choose the reference and quote.
        LoadScriptures();
        _index = GetRandomIndex();
        _randomScripture = GetRandomScripture(_index);
        _referenceString = GetRandomReference(_randomScripture);
        _quote = GetRandomQuote(_randomScripture);
        _reference = CreateRandomReference(_referenceString);
       
        string[] words = _quote.Split(" ");
        
        foreach (string word in words){
            Word w1 = new Word(word);
            _Words.Add(w1);
        }
        Console.WriteLine($"{_referenceString}: {_quote}");     
    }

    //Exceeding Requirements: HideRandomWords is hidden only the words that wasn't already hidden.
    // It checks if the word isHidden.
    public void HideRamdomWords(int quantity){     
        _quoteHidded = "";
        Random newRandom = new Random();
        int index;

        for(int i=0; i<quantity; i++){            
            index = newRandom.Next(0, _Words.Count());

            if (_Words[index].IsHidden()){
                i -= 1;
            }
            else{
                _Words[index].Hide(); 
            } 
        }

        foreach (Word word in _Words){
            _quoteHidded += word.Get() + " ";
        }

        Console.WriteLine($"{_referenceString}: {_quoteHidded}");
    }

    public int GetQuoteLength(){
        int length = _Words.Count();
        return length;
    }
    
    public string GetDisplayText(){
        string text = _quoteHidded;
        return text;
    }

    public bool IsCompletelyHidden(string text){
        // if the text is completely hidden it should return true
        string letter;
        bool status = true;

        if (text == ""){
            status = false;
        }
        else{
            foreach(char let in text){
                letter = let.ToString();

                if (letter != "_" && letter != " "){
                    status = false;
                    break;
                }
            }
        }
        return status;
    }

// Exceeding requirements. The behavior LoadScriptures make the program to load scriptures from a file
// and adding it to a list of references strings and to a list of quotes strings.

    private void LoadScriptures(){
        string fileName = "scriptures.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines){
            string[] parts = line.Split("'");

            string referenceText = parts[0];
            string scriptureText = parts[1];

            _ReferencesTexts.Add(referenceText);
            _ScriptureTexts.Add(scriptureText);      
        }
    }

// Exceeding requirements. The behaviors GetRandom...(Index,Scripture,Reference,Quote) are choosing one random scripture 
// and organizing it separating the reference string.
     private int GetRandomIndex(){
        Random indexRandom = new Random();
        int index = indexRandom.Next(0,_ReferencesTexts.Count);
        return index;
    }

    private string GetRandomScripture(int index){
        string reference = _ReferencesTexts[index];
        string text = _ScriptureTexts[index];
        string scripture = ($"{reference}~~{text}");
        return scripture;
    }
    private string GetRandomReference(string scriptureText){
        string[] parts = scriptureText.Split("~~");
            string reference = parts[0].Trim();
            return reference;
    }
    private string GetRandomQuote(string scriptureText){
    string[] parts = scriptureText.Split("~~");
        string quote = parts[1].Trim();
        return quote;
    }

// Exceeding requirements. The behavior CreateRandoReference is using the reference string and Reference class to
// create a Reference, adding it to the _reference that will help Scripture class tracks the reference.
    private Reference CreateRandomReference(string _reference){
        string book;
        int chapter;
        int verse;
                
        string[] parts = _reference.Split(" ");

            book = parts[0].Trim();
            chapter = int.Parse(parts[1].Split(":")[0].Trim());
            string verses = parts[1].Split(":")[1].Trim();
            char verseDivisor = '–';
            if (verses.Contains(verseDivisor)){         
                string[] parts1 = verses.Split('–');

                verse = int.Parse(parts1[0].Trim());
                int end = int.Parse(parts1[1].Trim());
                    Reference reference = new Reference(book, chapter, verse, end);
                    return reference;
            }
            else{
                verse = int.Parse(verses);
                Reference reference = new Reference(book, chapter, verse);
                return reference;
            }   
    }

}

