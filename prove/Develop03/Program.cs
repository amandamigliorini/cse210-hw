using System;

class Program
{
    static void Main(string[] args)
    {
        string status = "";
        bool scriptureStatus = false;
        Console.Clear();
        Scripture scripture = new Scripture();
        int quoteLength = scripture.GetQuoteLength();;
        int quantity = 3;
        int totalQuantity = 0;
           

        while(status != "quit" && scriptureStatus != true){
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            status = Console.ReadLine();
           
            if (status == ""){
                Console.Clear();
                //Exceed requirements: the HideRandomWords is checking the word and hidden only the words that
                // wasn't hidden yet. In order to prevent error I added a simple if else that control the quantity to be hidden passed.
                if (quoteLength - totalQuantity >=3){
                    quantity = 3;
                    totalQuantity += quantity;
                    scripture.HideRamdomWords(quantity);
                    string text = scripture.GetDisplayText();
                    scriptureStatus = scripture.IsCompletelyHidden(text);
                }
                else if(quoteLength - totalQuantity < 3){
                    quantity = quoteLength - totalQuantity;
                    scripture.HideRamdomWords(quantity);
                    string text = scripture.GetDisplayText();
                    scriptureStatus = scripture.IsCompletelyHidden(text);
                }
            }
        } 
        
    }
}