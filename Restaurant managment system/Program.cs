﻿using System.Globalization;
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

        Console.WriteLine("Welcome to the Restaurant Management System\n\n");

        Menu menu = new Menu();
        Ordering order = new();
        Manager ahmed = new Manager(1, "manager", "ahmed", 20, "cairo", "01111111", 8, "night", 12, 0);
        Customer customer=new Customer(); 

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please log in:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Simple credential checking
            if (username == "admin" && password == "admin")
            {
                Console.WriteLine("Login successful!\n");
                int choice;
                do
                {
                    Console.WriteLine("1. Manage Menu");
                    Console.WriteLine("2. Customer Management");
                    Console.WriteLine("3. Place an Order");
                    Console.WriteLine("4. Manage Staff");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice >> ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Please enter a valid number.\n");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            menu.MenuMangemnet();
                            break;
                        case 2:
                        customer.CustomerManagement();
                        break;
                        case 3:
                            // Placeholder for placing an order
                            Console.WriteLine("Order placement not yet implemented.\n");
                            break;
                        case 4:
                            ahmed.ManagerManagement();
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.\n");
                            break;
                    }
                } while (choice != 4);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.\n");
            }
        }
    }

}
