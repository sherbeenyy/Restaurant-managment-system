﻿using System.Globalization;
using System.Security.Cryptography;
using System.Xml.Serialization;
using Restaurant_managment_system;

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


        // Menu class testing 


        Console.WriteLine("\n------------Menu testing ---------------\n");

             Menu menu = new Menu();
             
             while (true)
             {
                 menu.MenuMangemnet();
             }

    
    





//Anas Customer part:
        /*Customer customer = new Customer("", "", "");
        customer.ReadInput();
         customer.DisplayCustomer();*/


//Anas ordering part
/*
   Ordering menu = new();

        while (true)
        {
            menu.DisplayMenu();
            int selection = menu.GetUserSelection();

            if (selection > 0 && selection <= menuItems.Count)
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
            }
        }
*/
    }
    
}
