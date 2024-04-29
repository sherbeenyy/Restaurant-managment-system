using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


public class Reservations
    {





    public List<List<int>> tables = new List<List<int>>();

    private Dictionary<string, List<int>> reservedTableMap;

    private Dictionary<string, int> dicforDays;



    


    // only owner can do this 
    public void initTables( )
    {
        Console.WriteLine("Enter the days of the weeks");
        Console.Write(">>");
        int daysInTheWeek = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of tables");
        Console.Write(">>");
        
      
        
      int tablescount = int.Parse(Console.ReadLine());
        for (int i = 0; i < tablescount; i++)
        {
            tables.Add(new List<int>(daysInTheWeek));
        }
    }

    public void DisplayTables()
    {
        foreach (var innerList in tables)
        {
            Console.Write("table: ");
            foreach (var item in innerList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        };
    }

    public void reserveTable()
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter your phone number");
        Console.Write(">>");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter the day you wish to book on");
        Console.Write(">>");
        int day = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the table number");
        Console.Write(">>");
        int tableNumber = int.Parse(Console.ReadLine());

        for (int i =0;i < tables.Count;i++)
        {
            if (tables[day][tableNumber] == 1)
            {
                Console.WriteLine("sorry this table already reserved for someone else");
            }else
            {
                tables[day][tableNumber] = 1;
                list.Add(day);
                list.Add(tableNumber);
                reservedTableMap.Add(phoneNumber, list);
                Console.WriteLine("reserved successfully");
            }
        }
    }

    public void cancelReservation()
    {

        Console.WriteLine("Enter your phone number");
        Console.Write(">>");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter the day you wish to book on");
        Console.Write(">>");
        int day = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the table number");
        Console.Write(">>");
        int tableNumber = int.Parse(Console.ReadLine());
        if (tables[day][tableNumber] == 0)
            Console.WriteLine("you didn't book that table ! ");
        else
        {
            tables[day][tableNumber] = 0;
            reservedTableMap.Remove(phoneNumber);
            Console.WriteLine("you have unbooked the table successfully !");
        }
    }
    public void reservationManagment()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("1. init tables");
            Console.WriteLine("2. reserve a table");
            Console.WriteLine("3. cancel reservation");
            Console.WriteLine("4. display all tables");
            Console.WriteLine("5. Exit");
            Console.Write(">> ");
            string option = Console.ReadLine();
            Console.WriteLine("==================");

            switch (option)
            {
                case "1":
                    
                    initTables();
                    break;
                case "2":
                    reserveTable();
                    break;
                case "3":
                    cancelReservation();
                    break;
                case "4":
                    DisplayTables();
                    break;
                case "5":
                    continueRunning = false;
                    Console.WriteLine("Exiting menu management.");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
    private string Name { get; set; }
        private string PhoneNumber { get; set; }
        private string Address { get; set; }
        private int NumberOfPeople { get; set; }
        private DateTime ReservationTime { get; set; }

        public Reservations(string name, string phoneNumber, string address, int numberOfPeople, DateTime reservationTime)
    {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            NumberOfPeople = numberOfPeople;
            ReservationTime = reservationTime;
        }

    // Defualt constructor
    public Reservations()
    {
    }

        public void AddReservation()
    {
            Console.Write("Enter customer name: ");
            Name = Console.ReadLine();

            Console.Write("Enter customer phone number: ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Enter customer address: ");
            Address = Console.ReadLine();

            Console.Write("Enter number of people: ");
            NumberOfPeople = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter reservation time: ");
            ReservationTime = Convert.ToDateTime(Console.ReadLine());
        }

        public void DisplayReservation()
    {
            Console.WriteLine($"Name: {Name}, Phone Number: {PhoneNumber}, Address: {Address}, Number of People: {NumberOfPeople}, Reservation Time: {ReservationTime}");
        }

    // testing in the main function

    public void ReservationManagement()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("1. Add new Reservation");
            Console.WriteLine("2. Remove Reservation");
            Console.WriteLine("3. View Reservations");
            Console.WriteLine("4. Edit Reservation");
            Console.WriteLine("5. Exit");
            Console.Write(">> ");
            string option = Console.ReadLine();
            Console.WriteLine("==================");

            switch (option)
            {
                case "1":
                    AddReservation();
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;

                case "4":
                    break;
                case "5":
                    continueRunning = false;  // Sets the flag to false to exit the loop.
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }



}

