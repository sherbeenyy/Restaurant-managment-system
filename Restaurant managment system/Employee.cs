using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Employee
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public decimal WorkingHours { get; set; }
    public string Shift { get; set; }
    public decimal Salary { get; set; }

    public decimal Wage { get; set; }

    // default constructor
    public Employee()
    {

    }

    public Employee(int id, string role, string name, int age, string address, string phoneNumber, decimal workingHours, string shift, decimal wage)
    {
        Id = id;
        Role = role;
        Name = name;
        Age = age;
        Address = address;
        PhoneNumber = phoneNumber;
        WorkingHours = workingHours;
        Shift = shift;
        Wage = wage;
        Salary = workingHours * wage;
    }

    public void displayInfo()
    {
        Console.WriteLine("Employee ID: " + Id);
        Console.WriteLine("Employee Role: " + Role);
        Console.WriteLine("Employee Name: " + Name);
        Console.WriteLine("Employee Age: " + Age);
        Console.WriteLine("Employee Address: " + Address);
        Console.WriteLine("Employee Phone Number: " + PhoneNumber);
        Console.WriteLine("Employee Working Hours: " + WorkingHours);
        Console.WriteLine("Employee Shift: " + Shift);
        Console.WriteLine("Employee Salary: " + Salary);
    }

}    


