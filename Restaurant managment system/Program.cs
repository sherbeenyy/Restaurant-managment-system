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
    public static bool login_toggler = false;

    static void Main(string[] args)
    {

        if (login_toggler)
        {
            Console.WriteLine("Welcome to the Restaurant Management System\n");

            LoginManager loginManager = new LoginManager();
            while (true)
            {
                // Prompt for login
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                Console.ResetColor();

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
        }
        else
        {
            Console.WriteLine("Login successful!");
            RunRestaurantManagement();
        }
    }

    static void RunRestaurantManagement()
    {
        Menu menu = new Menu();
        Ordering order = new Ordering();
        Manager manager = new Manager();
        Customer customer=new Customer(); 
        Reservations resreve = new Reservations();

        int choice;
        do
        {
            Console.WriteLine("=======Restaurant Functions=========");
            Console.WriteLine("1. Manage Menu");
            Console.WriteLine("2. Customer Management");
            Console.WriteLine("3. Place an Order");
            Console.WriteLine("4. Manage Staff");
            Console.WriteLine("5. Reservation Managment");
            Console.WriteLine("6. Exit");
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
                    customer.CustomerManagement();
                    break;
                case 3:
                    order.OrderingManagement();
                    // Placeholder for placing an order
                    //Console.WriteLine("Order placement not yet implemented.\n");
                    break;
                case 4:
                    manager.ManagerManagement();
                    break;
                case 5:
                    resreve.reservationManagment();
                    break;
                case 6:
                        
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.\n");
                    break;
            }
        } 
        while (choice != 6);
        
    }


}
