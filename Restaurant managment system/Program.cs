using System.Globalization;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design.Serialization;


class Program
{
    static void Main(string[] args)
    {
      
        // Employee calss testing 
        /*   Employee ahmed = new Employee(1, "chef", "ahmed", 20, "cairo", "01111111", 12, 0);
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
          ashrafm.hire(ahmed); */

        // seralization testing 

        

        // Menu class testing and ordering testing 


        Console.WriteLine("\n------------Menu testing and ordering ---------------\n");

        Menu menu = new Menu();
        Ordering order = new();
        Manager ahmed = new Manager(1, "manager", "ahmed", 20, "cairo", "01111111", 12, 0, 0);

        Console.WriteLine("Welcome to the restaurant management system\n\n");
        while (true)
        { 
        Console.WriteLine("1. change the menu items");
        Console.WriteLine("2. Place an order");
        Console.WriteLine("3. Owner stuff");
        Console.WriteLine("4. Exit");
        Console.Write(">> ");
        int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                        menu.MenuMangemnet();
                    break;
                case 2:
                    // Place Order

                    break;
                case 3:
                    ahmed.ManagerManagement();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.\n");
                    break;
            }

        }


        /*Employee emp1 = new Employee(0,"waiter","mazen",22,"cairo","010140132",12,1);
        emp1.displayInfo();*/

        //Anas Customer part:
        /*Customer customer = new Customer("", "", "");
        customer.ReadInput();
         customer.DisplayCustomer();*/


        //Anas ordering part
              /*  while (true)
                {
                    order.ViewItems();
                    int selection = order.GetUserSelection();

                    if (selection > 0)
                    {
                        switch (selection)
                        {
                            case 1:
                                // Place Order
                                break;
                            case 2:
                                // View Order History
                                break;
                            case 3:
                                // Exit
                                return;
                            default:
                                break;
      
                    }
               }*/
        
    }

}
