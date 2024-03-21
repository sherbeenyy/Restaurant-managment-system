using System.Security.Cryptography;
using Restaurant_managment_system;

class Program
{
    static void Main(string[] args)
    {

        // Employee calss testing 
        Employee ahmed = new Employee(1, "chef", "ahmed", 20, "cairo", "01111111", 12, 0);
        Employee ashraf = new Employee(1, "chef", "ashraf", 20, "cairo", "01111111", 12, 0);
        Employee osama = new Employee(1, "cashier", "osama", 20, "cairo", "01111111", 12, 0);



        ahmed.displayInfo();

        Owner Mohamed = new Owner(1, "owner", "Mohamed", 20, "cairo", "01111111", 12, 0, 0);
        Mohamed.hire(ahmed);
        Mohamed.hire(ashraf);
        Mohamed.hire(osama);
        Manager ashrafm = Mohamed.promoteToManager(ashraf);
        Console.WriteLine("Managers: ");
        Mohamed.printManagers();
        Console.WriteLine("Employees: ");
        Mohamed.printEmployees();
        ashrafm.hire(ahmed);


        // Menu class testing 

        Console.WriteLine("\n------------Menu testing ---------------\n");

        Menu item1 = new Menu();
        Menu item2 = new Menu();
        Menu item3 = new Menu();
        Console.WriteLine("1. Add new item.\n2. Remove item. \n3. Edit item.\n4. View item details.\n");
        Console.Write(">>");
        int choice = int.Parse(Console.ReadLine());
    }
}