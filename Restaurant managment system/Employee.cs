using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_managment_system
{
    internal class Employee
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
            get { return _age; }
            set { _age = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public float WorkingHours
        {
            get { return _workingHours; }
            set { _workingHours = value; }
        }
        public float Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public int Shift
        {
            get { return _shift; }
            set { _shift = value; }
        }
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

}
