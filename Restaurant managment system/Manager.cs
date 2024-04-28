using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        protected List<Employee> employees = new List<Employee>(); //data strcuter like the array but easier to add and delete ;
        List<string> allowedRoles = new List<string>
        {
            "chef","delivery", "waiter","cashier"
        };
        //searching in the list if the role exist 
        private bool foundInAllowedRoles(Employee e)
        {
            for (int i = 0; i < allowedRoles.Count; i++)
            {
                if (allowedRoles[i] == e.Role)
                    return true;

            }
            return false;
        }

        /*public bool checkIfValid(Employee e)
        {

            // INCOMPLETE !!  we should check for other parameters employee is having 
            if (e.Age < 18)
            {
                Console.WriteLine("can't hire people who is less than 18 years old ");
                return false;
            }
            if (!foundInAllowedRoles(e))
            {
                Console.WriteLine("invalid role");
                return false;
            }
            return true;
        }*/

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
            string ageInput = Console.ReadLine();
            if (!int.TryParse(ageInput, out int age) || age < 18)
            {
                Console.WriteLine("Invalid age. Must be 18 or older.");
                return; // Exit if invalid age
            }

            Console.Write("Enter the employee address: ");
            string address = Console.ReadLine();

            Console.Write("Enter the employee phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter the employee working hours: ");
            if (!float.TryParse(Console.ReadLine(), out float workingHours))
            {
                Console.WriteLine("Invalid input for working hours.");
                return; // Exit if invalid input
            }

            Console.Write("Enter the employee shift: ");
            if (!int.TryParse(Console.ReadLine(), out int shift))
            {
                Console.WriteLine("Invalid input for shift.");
                return; // Exit if invalid input
            }

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

    // print employees
    public void printEmployees()
    {
            Console.WriteLine("Employees List");
       
        for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].Name);
            }
            Console.WriteLine("==================");
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

    public void SaveItemsToFile() // Save employees to JSON file
    {
        string path = @"C:\Users\mazen\OneDrive\Desktop\test\OOP project\Restaurant-managment-system\Restaurant managment system\files\employee.json";
        string json = JsonConvert.SerializeObject(employees, Formatting.Indented); // Serialize the list to JSON with indented format
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



    //add employee ..create new employee

   




