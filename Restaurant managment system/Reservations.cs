using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// DayInWeek class to represent the days in the week
public class DayInWeek
{
    public string DayName { get; set; }
    public List<Table> Tables { get; private set; } // List to hold tables for each day

    public DayInWeek(string dayName)
    {
        DayName = dayName;
        Tables = new List<Table>(); // Initialize the list of tables
    }

    public void AddTable(Table table)
    {
        Tables.Add(table); // Method to add a table to the day
    }

    public void DisplayTables()
    {
        foreach (var table in Tables)
        {
            string status = table.IsOccupied ? "Occupied" : table.IsReserved ? "Reserved" : "Available";
            Console.WriteLine($"Table Number: {table.TableNumber}, Status: {status}");
        }
    }
}

// Table class to represent the tables in the restaurant
public class Table
{
    public int TableNumber { get; set; }
    public bool IsReserved { get; set; }
    public bool IsOccupied { get; set; }

    public Table(int tableNumber)
    {
        TableNumber = tableNumber;
        IsReserved = false;
        IsOccupied = false;
    }
}



// main class for the reservation system

public class Reservations
    {
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


    private List<DayInWeek> days = new List<DayInWeek>();// list of days in the week 

    public Reservations()
    {

    }

    private Dictionary<string, int> dicforDays;


    // only owner can do this 
    public void InitDaysAndTables()
    {
        Console.WriteLine("Enter the days of the week your restaurant will be open:");
        int daysCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < daysCount; i++)
        {
            Console.WriteLine("Enter the day name:");
            string dayName = Console.ReadLine();
            var day = new DayInWeek(dayName);
            days.Add(day);

            Console.WriteLine("Enter the number of tables for " + dayName + ":");
            int tableCount = int.Parse(Console.ReadLine());
            for (int j = 0; j < tableCount; j++)
            {
                day.AddTable(new Table(j + 1)); // Creates tables with sequential numbers
            }
        }
    }

    // Display tables for a specific day
    public void DisplayTables()
    {
        Console.WriteLine("Enter the day to display tables:");
        string dayName = Console.ReadLine();
        var day = days.FirstOrDefault(d => d.DayName.Equals(dayName, StringComparison.OrdinalIgnoreCase));
        if (day == null)
        {
            Console.WriteLine("Day not found.");
            return;
        }
        day.DisplayTables();
    }

    public void ReserveOrCancelTable(bool isReserve)
    {
        Console.WriteLine("Enter the day:");
        string dayName = Console.ReadLine();
        var day = days.FirstOrDefault(d => d.DayName.Equals(dayName, StringComparison.OrdinalIgnoreCase));
        if (day == null)
        {
            Console.WriteLine("Day not found.");
            return;
        }

        Console.WriteLine("Enter the table number:");
        int tableNumber = int.Parse(Console.ReadLine());
        var table = day.Tables.FirstOrDefault(t => t.TableNumber == tableNumber);
        if (table == null)
        {
            Console.WriteLine("Table number not found.");
            return;
        }

        if (isReserve)
        {
            if (table.IsReserved || table.IsOccupied)
            {
                Console.WriteLine("Table is not available.");
            }
            else
            {
                table.IsReserved = true;
                Console.WriteLine("Table reserved successfully.");
            }
        }
        else
        {
            if (!table.IsReserved)
            {
                Console.WriteLine("Table is not reserved.");
            }
            else
            {
                table.IsReserved = false;
                Console.WriteLine("Reservation cancelled successfully.");
            }
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
                    
                    InitDaysAndTables();
                    break;
                case "2":
                    ReserveOrCancelTable(true);
                    break;
                case "3":
                    ReserveOrCancelTable(false);
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
       

    // Defualt constructor

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
}

