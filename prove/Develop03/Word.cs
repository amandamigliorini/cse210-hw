public class Word{
    //Keeps track of a single word.

    private string _word;
    private bool _isHidden = false;

    public Word(string word){
        _word = word;
    }

    public void Hide(){
        //creating new string to display on the console
        _word = new string('_', _word.Length);
    }
    public string Get(){
        return _word;
    }

    public bool IsHidden(){
        // check if a word is hidden or not
        string letter;
        foreach(char let in _word){
            letter = let.ToString();
            if (letter != "_"){
                _isHidden = false;
            }
            else{
                _isHidden = true;
                break;
            } 
        }
        return _isHidden;
    }

}