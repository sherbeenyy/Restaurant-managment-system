using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Customer
{
    private string Name { get; set; }
    private string PhoneNumber { get; set; }
    private string Address { get; set; }
    private int LoyaltyPoints { get;  set; }

    public Customer(string name, string phoneNumber, string address)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        LoyaltyPoints = 0;
    }

    private List<Customer> customers = new List<Customer>(); // create a list of customers names customers

    // add customers 

    public void AddCustomer()
    {
        Console.WriteLine("Enter customer details: ");
        ReadInput();
    }

    // Edit customers
    public void EditCustomerInfo(string phone)
    {
        Customer person = customers.FirstOrDefault(x => x.PhoneNumber == phone);
        if (person != null)
        {
            Console.WriteLine("what do you wish to edit ? " +
                "1. Name\n" +
                "2. PhoneNumber\n" +
                "3. Address\n");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter new name: ");
                    person.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter new PhoneNumber: ");
                    person.PhoneNumber = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Enter new Adress: ");
                    person.Address = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }
        else
        {
            Console.WriteLine("there is no person");
        }

    }
    public void ReadInput()
    {
        Console.Write("Enter customer name: ");
       string  Name = Console.ReadLine();

        Console.Write("Enter customer phone number: ");
        string PhoneNumber = Console.ReadLine();

        Console.Write("Enter customer address: ");
        string Address = Console.ReadLine();

        AddLoyaltyPoints(2); // Add 2 loyalty points for each entry to change loyalty points change the number 2
        customers.Add(new Customer(Name, PhoneNumber, Address));
    }

    public void AddLoyaltyPoints(int points)
    {
        LoyaltyPoints += points;
    }


    public void DisplayCustomer()
    {
        Console.WriteLine($"Name: {Name}, Phone Number: {PhoneNumber}, Address: {Address}, Loyalty Points: {LoyaltyPoints}");
    }

    // file handeling code 

    public void LoadItemsFromFile()
    {
        string path = @"C:\Users\mazen\OneDrive\Desktop\test\OOP project\Restaurant-managment-system\Restaurant managment system\files\menu.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path); // Read JSON content from the file
            customers = JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>(); // Deserialize JSON to List<MenuItem>
        }
        else
        {
            customers = new List<Customer>(); // Initialize empty list if file doesn't exist
        }
    }
    public void SaveItemsToFile()
    {
        string path = @"C:\Users\mazen\OneDrive\Desktop\test\OOP project\Restaurant-managment-system\Restaurant managment system\files\menu.json";
        string json = JsonConvert.SerializeObject(customers, Formatting.Indented); // Serialize list to JSON
        File.WriteAllText(path, json); // Write JSON content to the file
    }


}