using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List <int> numbers = new List<int>();
        int number;
        int sum = 0;
        float avg = 0;
        int max = 0;
        int min = 100000000;
         Console.WriteLine("Enter a list of numbers, type 0 when finished.");
         Console.WriteLine();
        
        do{
            Console.Write("Enter number: ");
            string sNumber = Console.ReadLine();
            number = int.Parse(sNumber);
            if (number != 0){
                numbers.Add(number);
                sum = sum + number;
                avg = ((float)sum)/numbers.Count;
            }
        }while(number !=0);

        for (int i = 0; i < numbers.Count; i++){
        if (numbers[i] > max){
            max = numbers[i];
        }
        if (numbers[i] < min && numbers[i] > 0){
            min = numbers[i];
        }
        }
      
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");
  
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int orderedNumber in numbers){
            Console.WriteLine(orderedNumber);
        }
        

    }
}