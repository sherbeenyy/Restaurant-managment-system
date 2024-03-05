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
        private int _age; // i thought when the owner will hire he should see if he's above 18 or not;
        private string _address;
        private string _phoneNumber;
        private float _workingHours;
        private float _salary = 0;
        private int _shift; // 0 representing night and 1 representing morning ;
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
            _salary = workingHours*12.2f*30;
            _shift = shift;
            _totalEmployees++;
        }
         ~Employee() { } //clean up when the object is destroyed;

        public int Age
        {
            get { return _age; }
        }  
    }    
}
