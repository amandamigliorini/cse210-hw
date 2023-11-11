class PrompGenerator
{
   static List <string> _Prompts = new List<string>(){
    "Who was the most interesting person I interacted with today?", 
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "If I had one thing I could do over today, what would it be?",
    "What is one thing I did to improve myself today?",
    "What is one thing I did to take care os myself today?",
    "What did I do to think Celestial during this day?",
    "Who is the person I minister today and how?"
   };
   public string _prompt = "";
   public void DisplayPrompt(){

    Random index = new Random();
    int _listIndex = index.Next(0, _Prompts.Count);
    _prompt = _Prompts[_listIndex];
    _prompt = _prompt.ToUpper();
    Console.WriteLine(_prompt);
    

   }
}