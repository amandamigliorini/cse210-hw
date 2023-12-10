using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Quote newQuote = new Quote();
        AppointmentManager appointmentManager = new AppointmentManager();
        appointmentManager.Start();
    }
}