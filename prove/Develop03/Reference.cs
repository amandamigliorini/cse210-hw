public class Reference{
    //Keeps track of the book, chapter, and verse information.

    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse, int end){
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = end;
    }

    public Reference(string book, int chapter, int verse){
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

}