public class AppointmentManager{
    List <Appointment> _appointments = new List<Appointment>();

    public AppointmentManager(){

    }
    public void Start(){

        string choice = "";
        while (choice != "6"){
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Appointment");
            Console.WriteLine(" 2. List Appointments");
            Console.WriteLine(" 3. Save Appointments");
            Console.WriteLine(" 4. Load Appointments");
            Console.WriteLine(" 5. Fulfill Appointments");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: "); 
            choice = Console.ReadLine();
            if (choice == "1"){
                CreateAppointment();
            }
            
        }
    }
    public void CreateAppointment(){
         string choice = "";
        Console.WriteLine("Which type of appointment would you like to create? ");
        Console.WriteLine(" 1. Personal Appointment");
        Console.WriteLine(" 2. Study Appointment");
        Console.WriteLine(" 3. Work Appointment");
        Console.WriteLine(" 4. Volunteer Appointment");
        Console.Write(">>>");
        choice = Console.ReadLine();
        if (choice == "1"){
            PersonalAppointment personalAppointment = new PersonalAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            _appointments.Add(personalAppointment);
        }
        else if (choice == "2"){
            StudyAppointment studyAppointment = new StudyAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            _appointments.Add(studyAppointment);
        }
        else if (choice == "3"){            
            WorkAppointment workAppointment = new WorkAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            _appointments.Add(workAppointment);
        }
        else if (choice == "4"){
            VolunteerAppointment volunteerAppointment = new VolunteerAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            _appointments.Add(volunteerAppointment);
        }

    }
    public void DisplayAppiontments(){

    }
    public void DisplayQuote(){

    }
    public void ListTime(){

    }
    public void FulfillAppointment(){

    }
    public void SaveAppointments(){

    }
    public void LoadAppointments(){

    }
    private string DefineName(){
        Console.Write("What is the name of the appointment? ");
        string name = Console.ReadLine();
        return name;
    }
    private string DefineDescription(){
        Console.Write("What is a short description of it? ");
       string description = Console.ReadLine();
       return description;
    }
    private string DefineDate(){
        Console.Write("What is a short date of the appointment? ");
       string date = Console.ReadLine();
       return date;
    }

    private string DefineTime(){
        Console.Write("What is a short time of the appointment? ");
       string time = Console.ReadLine();
       return time;
    }
    private string DefineEndTime(){
        Console.Write("What is a short end time of the appointment? ");
       string endTime = Console.ReadLine();
       return endTime;
    }

}