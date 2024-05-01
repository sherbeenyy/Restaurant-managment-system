using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateAndTime.Workdays;

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
            string customerName = string.IsNullOrEmpty(table.Name) ? "No one" : table.Name;
            Console.WriteLine($"Table Number: {table.TableNumber}, Status: {status}, Customer: {customerName}");
        }
    }
}

// Table class to represent the tables in the restaurant
public class Table
{
    public int TableNumber { get; set; }
    public bool IsReserved { get; set; }
    public bool IsOccupied { get; set; }

    public string Name { get; set; }
    public Table(int tableNumber)
    {
        TableNumber = tableNumber;
        IsReserved = false;
        IsOccupied = false;
    }
}



// main class for the reservation system

public class Reservations : Customer
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

    // only owner can do this 
    public void InitDaysAndTables()
    {
        int daysCount = InputValidator.ReadInt("Enter the number of days in the week: ");

        for (int i = 0; i < daysCount; i++)
        {
            
            string dayName = InputValidator.ReadString("Enter the day name: ");

            var day = new DayInWeek(dayName);
            days.Add(day);

            int tableCount = InputValidator.ReadInt("Enter the number of tables for this day: ");

            for (int j = 0; j < tableCount; j++)
            {
                day.AddTable(new Table(j + 1)); // Creates tables with sequential numbers
            }
        }
        SaveItemsToFile();
    }

    // Display tables for a specific day
    public void DisplayTables()
    {
        
        string dayName = InputValidator.ReadString("Enter the day name: ");

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
        
        string dayName = InputValidator.ReadString("Enter the day name: ");

        var day = days.FirstOrDefault(d => d.DayName.Equals(dayName, StringComparison.OrdinalIgnoreCase));
        if (day == null)
        {
            Console.WriteLine("Day not found.");
            return;
        }

        int tableNumber = InputValidator.ReadInt("Enter the table number: ");

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
                Console.WriteLine($"Please enter customer Name:");
                string name = Console.ReadLine();

                table.Name = name;
                Console.WriteLine($"Table {tableNumber} reserved successfully.");


                SaveItemsToFile();
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
                SaveItemsToFile();
            }
        }
    }

    public void reservationManagment()
    {
        LoadItemsFromFile();
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

    // file handeling 

    private const string path = "Reservations.json";
    public void LoadItemsFromFile()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path); // Read JSON content from the file
            days = JsonConvert.DeserializeObject<List<DayInWeek>>(json) ?? new List<DayInWeek>(); // Deserialize JSON to List<MenuItem>
        }
        else
        {
            days = new List<DayInWeek>(); // Initialize empty list if file doesn't exist
        }
    }
    public void SaveItemsToFile()
    {
        string json = JsonConvert.SerializeObject(days, Formatting.Indented); // Serialize list to JSON
        File.WriteAllText(path, json); // Write JSON content to the file
    }
}

