using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

public class Manager : Employee
    {
        private float _expYears;
        private bool isAuth = true;
        public float ExpYears
        {
            get { return _expYears; }
            set { _expYears = value; }
        }
        public Manager(int id, string role, string name, int age, string address, string phoneNumber, float workingHours, int shift, float expYears)
        : base(id, role, name, age, address, phoneNumber, workingHours, shift)
        {
            _expYears = expYears;
        }


        public List<Employee> employees = new List<Employee>(); //data strcuter like the array but easier to add and delete ;

        List<string> allowedRoles = new List<string>
        {
            "chef","delivery", "waiter","cashier"
        };
        //searching in the list if the role exist 

            public bool login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                isAuth = true;
                return true;
            }
            return false;
        }

    // hire employee
    public void hire()
    {
        if (isAuth)
        {
            Console.Write("Enter the employee role: ");
            string role = Console.ReadLine();

            while (!allowedRoles.Contains(role))
            {
                Console.WriteLine("Invalid role, please try again.");
                role = Console.ReadLine();
            }

            Console.Write("Enter the employee name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the employee age: ");
            int  age = int.Parse(Console.ReadLine());
            

            Console.Write("Enter the employee address: ");
            string address = Console.ReadLine();

            Console.Write("Enter the employee phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter the employee working hours: ");
            float workingHours = float.Parse(Console.ReadLine());

            Console.Write("Enter the employee shift: ");
            int shift = int.Parse(Console.ReadLine());

            Employee newEmployee = new Employee(employees.Count + 1, role, name, age, address, phoneNumber, workingHours, shift);

            employees.Add(newEmployee);
            SaveItemsToFile();
            Console.WriteLine("Employee added successfully");
        }
        else
        {
            Console.WriteLine("You are not authorized to perform this action.");
        }
    }

    // print all employees info
    public void printEmployees()
    {
            Console.WriteLine("Employees List");
            
        foreach (var item in employees)
        {
                item.displayInfo();
                Console.WriteLine("==================================");
            }



            Console.WriteLine("==================================");

       
    }
        //Remove employee
        public void fire()
        {
            if(isAuth)
            {
            Console.WriteLine("Enter the id of the Employee you want to remove : ");
            Console.Write(">> ");   
            int id = int.Parse(Console.ReadLine());

            // Find item by id and remove it
            Employee item = employees.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Console.WriteLine("Item removed successfully." + item.Name);
                employees.Remove(item);
                SaveItemsToFile();
            }
            else
                {
                Console.WriteLine("Employee not found\n");
                Console.WriteLine("==================================");
                }
            }
            else Console.WriteLine("you are not authorized to do this action");
        }

    public void LoadItemsFromFile() // Load employees from JSON file
    {
        string path = @"C:\Users\mazen\OneDrive\Desktop\test\OOP project\Restaurant-managment-system\Restaurant managment system\files\employee.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            employees = JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>(); // Deserialize json to List<Employee>, if null create new List
        }
    }

    public void SaveItemsToFile()
    {
        string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
        Console.WriteLine("Debug - Serialized JSON: " + json);  // Check the serialized output

        string path = @"C:\Users\mazen\OneDrive\Desktop\test\OOP project\Restaurant-managment-system\Restaurant managment system\files\employee.json";  // Update this path as necessary
        File.WriteAllText(path, json);
    }

        public void ManagerManagement()
    {
        LoadItemsFromFile();
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("1. Hire Employee");
            Console.WriteLine("2. Fire Employee ");
            Console.WriteLine("3. View Employees ");
            Console.WriteLine("4. Exit");
            Console.Write(">> ");
            string option = Console.ReadLine();
            Console.WriteLine("==================");

            switch (option)
            {
                case "1":
                    hire();
                    break;
                case "2":
                    fire();
                    break;
                case "3":
                    printEmployees();
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
}
