using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public void AddLoyaltyPoints(int points)
    {
        LoyaltyPoints += points;
    }

    public void ReadInput()
    {
        Console.Write("Enter customer name: ");
        Name = Console.ReadLine();

        Console.Write("Enter customer phone number: ");
        PhoneNumber = Console.ReadLine();

        Console.Write("Enter customer address: ");
        Address = Console.ReadLine();

        AddLoyaltyPoints(2); // Add 2 loyalty points for each entry to change loyalty points change the number 2
    }

    public void DisplayCustomer()
    {
        Console.WriteLine($"Name: {Name}, Phone Number: {PhoneNumber}, Address: {Address}, Loyalty Points: {LoyaltyPoints}");
    }


}