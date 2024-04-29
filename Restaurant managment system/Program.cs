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

        Console.WriteLine("Welcome to the Restaurant Management System\n");

        LoginManager loginManager = new LoginManager();

        // Prompt for login
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (loginManager.ValidateLogin(username, password))
        {
            Console.WriteLine("Login successful!");
            RunRestaurantManagement();
        }
        else
        {
            Console.WriteLine("Login failed. Please check your username and password.");
        }
    }




    static void RunRestaurantManagement()
    {
        Menu menu = new Menu();
        Ordering order = new();
        Manager ahmed = new Manager(1, "manager", "ahmed", 20, "cairo", "01111111", 8, "night", 12, 0);

        bool isRunning = true;
        while (isRunning)
        {       
                int choice;
                do
                {
                    Console.WriteLine("1. Manage Menu");
                    Console.WriteLine("2. Place an Order");
                    Console.WriteLine("3. Manage Staff");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice >> ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Please enter a valid number.\n");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            menu.MenuManagement();
                            break;
                        case 2:
                            // Placeholder for placing an order
                            Console.WriteLine("Order placement not yet implemented.\n");
                            break;
                        case 3:
                            ahmed.ManagerManagement();
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.\n");
                            break;
                    }
                } while (choice != 4);
        }
    }


}
