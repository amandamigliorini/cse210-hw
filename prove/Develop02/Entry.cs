class Entry
{

 public string _entryTitle = "";
 public string _entryText = "";
 public string _date = "";

 private DateTime _theCurrentTime;
 public Entry(){
    _theCurrentTime = DateTime.Now;
 }
 public string GetDate(){
    string date = _theCurrentTime.ToShortDateString();
    return date;
 }
 public void DisplayEntry(){  
    Console.WriteLine("");
    Console.WriteLine($"{_date}");
    Console.WriteLine($"{_entryTitle}");
    Console.WriteLine($"{_entryText}");
    Console.WriteLine("________________");
 }


}