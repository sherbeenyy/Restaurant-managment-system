using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using static Customer;

public class Manager : Employee
{
        private float _expYears;
        private bool isAuth = true;
        public float ExpYears
        {
            get { return _expYears; }
            set { _expYears = value; }
        }
        public Manager(int id, string role, string name, int age, string address, string phoneNumber, decimal workingHours, string shift,decimal wage, float expYears)
        : base(id, role, name, age, address, phoneNumber, workingHours,shift,wage)
        {
            _expYears = expYears;
        }

        // default constructor
        public Manager() : base()
        {

        }

    public List<Employee> employees = new List<Employee>(); //data strcuter like the array but easier to add and delete ;

        List<string> AllowedRoles = new List<string>
        {
            "chief","delivery", "waiter","cleaner","cashier","Chief","Delivery", "Waiter","Cashier","Cleaner"
        };

        List<string> AllowedShifts = new List<string>
         {
            "day","night","Day","Night"
         };

    // hire employee
    public void hire()
    {
        if (isAuth)
        {
            Console.WriteLine("===========Creating Employee======");
            Console.WriteLine("Allowed roles are: chief, delivery, waiter, cleaner, cashier");
            string role = InputValidator.ReadString("Enter the employee role: ");

            while (!AllowedRoles.Contains(role))
            {
                Console.WriteLine("Invalid role, please try again.");
                role = InputValidator.ReadString(">> ");
            }

            string name = InputValidator.ReadString("Enter the employee name: ");
            int age = InputValidator.ReadInt("Enter the employee age: ");
            string address = InputValidator.ReadString("Enter the employee address: ");
            string phoneNumber = InputValidator.ReadString("Enter the employee phone number: ");
            decimal workingHours = InputValidator.ReadDecimal("Enter the employee working hours: ");
            Console.WriteLine("Allowed shifts are: day, night");
            string shift = InputValidator.ReadString("Enter the employee shift: ");

            while (!AllowedShifts.Contains(shift))
            {
                Console.WriteLine("Invalid Shift, please try again.");
                shift = InputValidator.ReadString(">> ");
            }

            decimal wage = InputValidator.ReadDecimal("Enter employee wage: ");


            Employee newEmployee = new Employee(employees.Count + 1, role, name, age, address, phoneNumber, workingHours, shift, wage);

            employees.Add(newEmployee);
            SaveItemsToFile();
            Console.WriteLine("=======Employee added successfully============");
        }
        else
        {
            Console.WriteLine("You are not authorized to perform this action.");
        }
    }

    //Remove employee
    public void fire()
    {
        if (isAuth)
        {
           
            int id = InputValidator.ReadInt("Enter the id of the employee you want to remove: ");

            // Find item by id and remove it
            Employee item = employees.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Console.WriteLine("are you sure yoy wish to remove Employee" + item.Name);
                string answer = Console.ReadLine();
                if (answer == "yes")
                {
                    Console.WriteLine("Employee removed successfully." + item.Name);
                    employees.Remove(item);
                    SaveItemsToFile();
                }
                else
                {
                    Console.WriteLine("Employee not removed.");
                }
            }
            else
            {
                Console.WriteLine("Employee not found\n");
                Console.WriteLine("==================================");
            }
        }
        else Console.WriteLine("you are not authorized to do this action");
    }

    // Edit employee info
    public void EditEmployeeInfo()
    {
        Console.WriteLine("===========Editing Employee======");
        Console.WriteLine("Enter the id of the Employee you want to edit : ");
        int Employee_Id = int.Parse(Console.ReadLine());

        Employee person = employees.FirstOrDefault(x => x.Id == Employee_Id);
        if (Employee_Id != null)
        {
            Console.WriteLine("what do you wish to edit ?\n" +
                "1. Name\n" +
                "2. Role\n" +
                "3. Age\n" +
                "4. Address\n" +
                "5. PhoneNumber\n" +
                "6. Working Hours\n" +
                "7. Shift\n" +
                "8. Wage\n");

                Console.Write(">>");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                   person.Name = InputValidator.ReadString("Enter new name: ");
                    break;
                case 2:
                    person.Role = InputValidator.ReadString("Enter new Role: ");

                    break;
                case 3:
                    person.Age = InputValidator.ReadInt("Enter new Age: ");
                    break;
                case 4:
                   person.Address = InputValidator.ReadString("Enter new Address: ");
                    break;
                case 5:
                    person.PhoneNumber = InputValidator.ReadString("Enter new PhoneNumber: ");
                    break;
                case 6:
                    person.WorkingHours = InputValidator.ReadDecimal("Enter new Working Hours: ");
                    break;
                case 7:
                    person.Shift = InputValidator.ReadString("Enter new Shift: ");
                    break;
                case 8:
                    person.Wage = InputValidator.ReadDecimal("Enter new Wage: ");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Employee not found\n");
            Console.WriteLine("==================================");
        }
        Console.WriteLine("====Employee info updated successfully.====");
        SaveItemsToFile();
    }


    // print all employees info
    public void printEmployees()
    {
            Console.WriteLine("+================Employees List========================");
        // if list is empty display message
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
        }
        else
        {
            foreach (var item in employees)
            {
                item.displayInfo();
            }
        }
            
    }

        public void ManagerManagement()
    {
        LoadItemsFromFile();
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("=========Employee Management=========");
            Console.WriteLine("1. Hire Employee");
            Console.WriteLine("2. Fire Employee ");
            Console.WriteLine("3. Update Employee info");
            Console.WriteLine("4. View Employees ");
            Console.WriteLine("5. Exit");
            Console.Write(">> ");
            string option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    hire();
                    break;
                case "2":
                    fire();
                    break;
                case "3":
                    EditEmployeeInfo();
                    break;
                case "4":
                    printEmployees();
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

    private const string path = "Employees.json";
    public void LoadItemsFromFile() // Load employees from JSON file
    {

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            employees = JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>(); // Deserialize json to List<Employee>, if null create new List
        }
    }

    public void SaveItemsToFile()
    {
        string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}
