using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    public void hire()
    {
        if (isAuth)
        {
            while (true)
            {
                Console.Write("Enter the employee role: ");
                string Role = Console.ReadLine();
                if(allowedRoles.Contains(Role))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid role, please try again.");
                }
            }
            Console.Write("Enter the employee name: ");
            string Name = Console.ReadLine();


            Console.Write("Enter the employee age: ");
            int Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the employee address: ");
            string Address = Console.ReadLine();

            Console.Write("Enter the employee phone number: ");
            string PhoneNumber = Console.ReadLine();

            Console.Write("Enter the employee working hours: ");
            int WorkingHours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the employee shift: ");
            int Shift = Convert.ToInt32(Console.ReadLine());


            var newEmployee = new Employee(employees.Count + 1, Role, Name, Age, Address, PhoneNumber, WorkingHours, Shift);

            employees.Add(newEmployee);

            Console.WriteLine("Employee added successfully");

        }
        else Console.WriteLine("you are not authorized to do this action");
        }
        
        public void printEmployees()
    {
            Console.WriteLine("Employees List");
        //print the employees
        for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].Name);
            }
            Console.WriteLine("==================");
    }

        //delete employee
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
            }
            else
                {
                Console.WriteLine("Employee not found\n");
                Console.WriteLine("==================================");
                }
            }
            else Console.WriteLine("you are not authorized to do this action");
        }

    public void ManagerManagement()
    {
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

   




