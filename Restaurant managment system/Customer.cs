/*Need to check that everything is working*/
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
    // from my understanding in order to save data from the method we have learened the class
    // we are creating a list from needs to be sepreate as indvisuals 
    public class CustomerItem
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int LoyaltyPoints { get; set; }

        public CustomerItem(string name, string phoneNumber, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            LoyaltyPoints = +2;
        }


    }

    private List<CustomerItem> customers = new List<CustomerItem>(); // create a list of customers names customers
    public void CustomerManagement()
{
    LoadItemsFromFile();
        bool continueRunning = true;
        while (continueRunning)
        {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Edit Customer");
        Console.WriteLine("3. Display All Customers");
        Console.WriteLine("4. Exit");

        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                AddCustomer();
                Console.WriteLine("Customer added successfully.");
                break;
            case "2":
                Console.Write("Please enter your Phone Number: ");
                string phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone))
                {
                    Console.WriteLine("Phone number cannot be empty. Please try again.");
                }
                else
                {
                    DisplayCustomer(phone);
                    EditCustomerInfo(phone);
                }
                break;
            case "3":
                Displayall();
                break;
            case "4":
                continueRunning = false;  // Sets the flag to false to exit the loop.
                break;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
    }
}

    // add customers 

    public void AddCustomer()
    {
        Console.WriteLine("Enter customer details: ");
        ReadInput();
    }

    // Edit customers
    public void EditCustomerInfo(string phone)
    {
        CustomerItem person = customers.FirstOrDefault(x => x.PhoneNumber == phone);
        if (person != null)
        {
            Console.WriteLine("what do you wish to edit ?\n " +
                "1. Name\n" +
                "2. PhoneNumber\n" +
                "3. Address\n");
            Console.Write(">>");

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
        SaveItemsToFile();
    }
    public void ReadInput()
    {
        Console.Write("Enter customer name: ");
       string  Name = Console.ReadLine();

        Console.Write("Enter customer phone number: ");
        string PhoneNumber = Console.ReadLine();

        Console.Write("Enter customer address: ");
        string Address = Console.ReadLine();
        // Add 2 loyalty points for each entry to change loyalty points change the number 2
        customers.Add(new CustomerItem(Name, PhoneNumber, Address));
        SaveItemsToFile();
    }

    public void DisplayCustomer(string phone)
{
    CustomerItem person = customers.FirstOrDefault(x => x.PhoneNumber == phone);
    if (person != null)
    {
        Console.WriteLine("============Customer List===========");
        Console.WriteLine($"Name: {person.Name}\nPhone Number: {person.PhoneNumber}\nAddress: {person.Address}\nLoyalty Points: {person.LoyaltyPoints}\n");
        Console.WriteLine("============");
    }
    else
    {
        Console.WriteLine("Customer not found.");
    }
}

public void Displayall()
{
    if (customers.Count > 0)
    {
        foreach (var person in customers)
        {
            Console.WriteLine($"Name: {person.Name}, Phone Number: {person.PhoneNumber}, Address: {person.Address}, Loyalty Points: {person.LoyaltyPoints}");
        }
    }
    else
    {
        Console.WriteLine("No customers found.");
    }
}
    // file handeling code 

    private const string path = "Customers.json";
    public void LoadItemsFromFile()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path); // Read JSON content from the file
            customers = JsonConvert.DeserializeObject<List<CustomerItem>>(json) ?? new List<CustomerItem>(); // Deserialize JSON to List<MenuItem>
        }
        else
        {
            customers = new List<CustomerItem>(); // Initialize empty list if file doesn't exist
        }
    }
    public void SaveItemsToFile()
    {
        string json = JsonConvert.SerializeObject(customers, Formatting.Indented); // Serialize list to JSON
        File.WriteAllText(path, json); // Write JSON content to the file
    }
}


