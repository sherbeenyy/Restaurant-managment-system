using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Ordering
{
    // properties

    public int OrderID { get; private set; }
    public int OrderItems { get; private set; }
    public int Receipt { get; private set; }
    public int TaxRate { get; private set; }
    public int ServiceCharge { get; private set; }
    public string OrderDate { get; private set; }

    // constructor

    public Ordering(int orderID, int orderItems, int receipt, int taxRate, int serviceCharge, string orderDate)
    {
        OrderID = orderID;
        OrderItems = orderItems;
        Receipt = receipt;
        TaxRate = taxRate;
        ServiceCharge = serviceCharge;
        OrderDate = orderDate;
    }

    public Ordering()
    {
    }

public void OrderingManagement()
{
    bool continueRunning = true;
    while (continueRunning)
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Order");//To write the food id and the quantity
        Console.WriteLine("2. Edit order");//To edit the order (To change of food,quantity, addor remove food)
        Console.WriteLine("3. Reciept");
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
                PrintOrderDetails();
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
    // method to calculate the tax based on the order items and tax rate

    public int CalculateTax()
    {
        return OrderItems * TaxRate / 100;
    }

    // method to calculate the total cost of the order

    public int CalculateTotalCost()
    {
        return OrderItems + CalculateTax() + ServiceCharge;
    }

    // method to print the order details

    public void PrintOrderDetails()
    {
        Console.WriteLine($"Order ID: {OrderID}");
        Console.WriteLine($"Order Items: {OrderItems}");
        Console.WriteLine($"Receipt: {Receipt}");
        Console.WriteLine($"Tax Rate: {TaxRate}%");
        Console.WriteLine($"Service Charge: {ServiceCharge}");
        Console.WriteLine($"Order Date: {OrderDate}");
        Console.WriteLine($"Tax: {CalculateTax()}");
        Console.WriteLine($"Total Cost: {CalculateTotalCost()}");
    }
}

