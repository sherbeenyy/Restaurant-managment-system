using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;


    public class Employee
    {
        private int _id;
        private string _role;
        private string _name;
        private int _age; // i thought when the owner will hire he should see if he's above 18 or not
        private string _address;
        private string _phoneNumber;
        private float _workingHours;
        private float _salary = 0;
        private int _shift; // 0 representing night and 1 representing morning
        static private int _totalEmployees = 0;

        public Employee(int id, string role, string name, int age, string address, string phoneNumber, float workingHours, int shift)
        {
            _id = id;
            _role = role;
            _name = name;
            _age = age;
            _address = address;
            _phoneNumber = phoneNumber;
            _workingHours = workingHours;
            _salary = workingHours * 12.2f * 30;
            _shift = shift;
            _totalEmployees++;
        }
        ~Employee() { } //clean up when the object is destroyed;
        public int Age
        {
            set; get;
        }
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        public string PhoneNumber
        {
            set { _phoneNumber = value; }
            get { return _phoneNumber; }
        }
        public float WorkingHours
        {
            set; get;
        }
        public float Salary
        {
            set; get;
        }
        public int Shift
        {
            set; get;
        }
        public string Role
        {
            set { _role = value; }
            get { return _role; }
        }
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int Id
        {
            set; get;
        }
        public int TotalEmployees
        { get { return _totalEmployees; } }



        public bool askForRaise()
        {
            if (_workingHours > 8)
            {
                _salary += 1000;
                return true;
            }
            return false;
        }
        public void displayInfo()
        {
            Console.WriteLine("Employee ID: " + _id);
            Console.WriteLine("Employee Role: " + _role);
            Console.WriteLine("Employee Name: " + _name);
            Console.WriteLine("Employee Age: " + _age);
            Console.WriteLine("Employee Address: " + _address);
            Console.WriteLine("Employee Phone Number: " + _phoneNumber);
            Console.WriteLine("Employee Working Hours: " + _workingHours);
            Console.WriteLine("Employee Salary: " + _salary);
            Console.WriteLine("Employee Shift: " + _shift);
        }

    }


