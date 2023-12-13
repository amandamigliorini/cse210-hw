public class AppointmentManager{
    private List <Appointment> _appointments = new List<Appointment>();
    private List <Time> _times = new List<Time>();

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
            else if (choice == "2"){
                DisplayAppointments();
            }
            else if (choice == "3"){
                SaveAppointments();
            }
            else if (choice == "4"){
                LoadAppointments();
            }
            else if (choice == "5"){
                FulfillAppointment();
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
        Console.Write(">>> ");
        choice = Console.ReadLine();
        if (choice == "1"){
            PersonalAppointment personalAppointment = new PersonalAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            Time time = new Time(personalAppointment.GetDate(), personalAppointment.GetStartTime(), personalAppointment.GetEndTime());
            if (time.IsOccupied(_times)){
                Console.WriteLine();
                Console.WriteLine("This time is occupied, please add appointment again, in a free time.");
                Console.WriteLine();
            }
            else{
                _appointments.Add(personalAppointment);
                _times.Add(time);
            }  
        }
        else if (choice == "2"){
            StudyAppointment studyAppointment = new StudyAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            Time time = new Time(studyAppointment.GetDate(), studyAppointment.GetStartTime(), studyAppointment.GetEndTime());
            if (time.IsOccupied(_times)){
                Console.WriteLine();
                Console.WriteLine("This time is occupied, please add appointment again, in a free time.");
                Console.WriteLine();
            }
            else{
                _appointments.Add(studyAppointment);
                _times.Add(time);
            }           
        }
        else if (choice == "3"){            
            WorkAppointment workAppointment = new WorkAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            Time time = new Time(workAppointment.GetDate(), workAppointment.GetStartTime(), workAppointment.GetEndTime());
            if (time.IsOccupied(_times)){
                Console.WriteLine();
                Console.WriteLine("This time is occupied, please add appointment again, in a free time.");
                Console.WriteLine();
            }
            else{
                _appointments.Add(workAppointment);
                _times.Add(time);
            }            
        }
        else if (choice == "4"){
            VolunteerAppointment volunteerAppointment = new VolunteerAppointment(DefineName(), DefineDescription(), DefineDate(), DefineTime(), DefineEndTime());
            Time time = new Time(volunteerAppointment.GetDate(), volunteerAppointment.GetStartTime(), volunteerAppointment.GetEndTime());
            if (time.IsOccupied(_times)){
                Console.WriteLine();
                Console.WriteLine("This time is occupied, please add appointment again, in a free time.");
                Console.WriteLine();
            }
            else{
                _appointments.Add(volunteerAppointment);
                _times.Add(time);
            }           
        }
    }
    public void DisplayAppointments(){
        Console.Clear();
        Console.WriteLine();
        int i = 1;
        foreach (Appointment appointment in _appointments){
            if (appointment.IsFulfilled() == false){
                Console.WriteLine($"{i}. [ ] {appointment.GetDetailsString()}.");
                Console.WriteLine();
                i ++;
            }
            else if (appointment.IsFulfilled() == true){
                Console.WriteLine($"{i}. [X] {appointment.GetDetailsString()}.");
                Console.WriteLine();
                i ++;
            }   
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    public void FulfillAppointment(){
        Console.WriteLine("Appointments:");
        ListAppointmentNames();
        Console.Write("Which appointment do you want to set fulfilled? ");
        int choice = int.Parse(Console.ReadLine());
        int index = choice - 1;
        
        while (_appointments.Count < choice){
            Console.WriteLine("Couldn't find this appointment");
            Console.Write("Which appointment do you want to set fulfilled? ");
            choice = int.Parse(Console.ReadLine());
            index = choice - 1;
        }

        _appointments[index].FulfillAppointment();


    }
    public void SaveAppointments(){
        string fileName = "Appointments.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Appointment appointment in _appointments) {
                outputFile.WriteLine($"{appointment.GetStringRepresentation()}");
            }     
        }

        Thread.Sleep(1000);
        Console.WriteLine();
        Console.WriteLine("File saved");

    }
    public void LoadAppointments(){
        string fileName = "Appointments.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        _appointments.Clear();

        foreach (string line in lines){
            string[] parts = line.Split("~~");
            
            if (parts.Count() == 6){
                string name = parts[0];
                string date = parts[1];
                string time = parts[2];
                string endTime = parts[3];
                string description = parts[4];
                PersonalAppointment personalAppointment = new PersonalAppointment(name, description, date, time, endTime);
                personalAppointment.SetFulfillment(bool.Parse(parts[5]));
                _appointments.Add(personalAppointment);
            }
            else if (parts.Count() == 7){
                string name = parts[0];
                string date = parts[1];
                string time = parts[2];
                string endTime = parts[3];
                string course = parts[4];
                string description = parts[5];
                StudyAppointment studyAppointment = new StudyAppointment(name, description, date, time, endTime, course);
                studyAppointment.SetFulfillment(bool.Parse(parts[6]));
                _appointments.Add(studyAppointment);
            }
            else if (parts.Count() == 8){
                string name = parts[0];
                string date = parts[1];
                string time = parts[2];
                string endTime = parts[3];
                string place = parts[4];
                string address = parts [5];
                string description = parts[6];
                VolunteerAppointment volunteerAppointment = new VolunteerAppointment(name, description, date, time, endTime, place, address);
                volunteerAppointment.SetFulfillment(bool.Parse(parts[7]));
                _appointments.Add(volunteerAppointment);
            }
            else if (parts.Count() == 9){
                string name = parts[0];
                string date = parts[1];
                string time = parts[2];
                string endTime = parts[3];
                string projectName = parts[4];
                string description = parts [5];
                int steps = int.Parse(parts[6]);
                int stepsDone = int.Parse(parts[7]);
                WorkAppointment workAppointment = new WorkAppointment(name, description, date, time, endTime, projectName, steps, stepsDone);
                workAppointment.SetFulfillment(bool.Parse(parts[8]));
                _appointments.Add(workAppointment);
            }
        }
        Thread.Sleep(1000);
        Console.WriteLine();
        Console.WriteLine("File loaded");
        Console.WriteLine();
    }
    public void ListAppointmentNames(){
        
        int i = 1;
        foreach (Appointment appointment in _appointments){
            Console.WriteLine($"{i}. {appointment.GetName()}.");
            i ++;     
        } 
        Console.WriteLine();       
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
        Console.Write("What is the date of the appointment?(YYYY-MM-DD) ");
       string date = Console.ReadLine();
       return date;
    }
    private string DefineTime(){
        Console.Write("What is the time of the appointment?(HH:mm)(24 hours format) ");
       string time = Console.ReadLine();
       return time;
    }
    private string DefineEndTime(){
        Console.Write("What is the end time of the appointment?(HH:mm)(24 hours format)  ");
       string endTime = Console.ReadLine();
       return endTime;
    }
}