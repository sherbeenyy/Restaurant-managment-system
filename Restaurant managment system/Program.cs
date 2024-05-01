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
    public static bool login_toggler = true;

    static void Main(string[] args)
    {

        if (login_toggler)
        {
            Console.WriteLine("Welcome to the Restaurant Management System\n");

            LoginManager loginManager = new LoginManager();
            LoginStaff loginstaff = new LoginStaff();

            while (true)
            {
                int number;
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Staff");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3. Exit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your choice >> ");

                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number.\n");
                    Console.ResetColor();
                    continue;
                }
                switch (number)
                {
                    case 1:
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
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Enter username: ");
                        string usernameforStaff = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string passwordforStaff = Console.ReadLine();
                        Console.ResetColor();
                        if (loginstaff.loginForStaff(usernameforStaff, passwordforStaff))
                        {
                            Console.WriteLine("Login Successfull");
                            RunRestaurantManagementForSataff();
                        }else
                        {
                                Console.WriteLine("Login failed. seems like you are not an employee here ");
                        }
                        break;
                    case 3:
                        return;
                      


                }
            }
        }




        static void RunRestaurantManagementForSataff()
        {
            Menu menu = new Menu();
            Ordering order = new Ordering();
            Customer customer = new Customer();
            Reservations resreve = new Reservations();

            int choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=======Restaurant Functions=========");
                Console.WriteLine("1. Manage Customers");
                Console.WriteLine("2. Manage Orders");
                Console.WriteLine("3. Manage Reservations");
                Console.WriteLine("4. Manage Menu");
                Console.WriteLine("5. Exit");
                Console.ResetColor();
                Console.Write("Enter your choice >> ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number.\n");
                    Console.ResetColor();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        customer.CustomerManagement();
                        break;
                    case 2:
                        order.OrderingManagement();

                        break;
                    case 3:
                        resreve.reservationManagment();
                        break;
                    case 4:
                        menu.MenuManagement();
                        break;
                    case 5:
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option, please try again.\n");
                        Console.ResetColor();
                        break;
                }
            }
            while (choice != 5);
        }
            static void RunRestaurantManagement()
            {
                Menu menu = new Menu();
                Ordering order = new Ordering();
                Manager manager = new Manager();
                Customer customer = new Customer();
                Reservations resreve = new Reservations();

                int choice;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("=======Restaurant Functions=========");
                    Console.WriteLine("1. Manage Menu");
                    Console.WriteLine("2. Manage Customers");
                    Console.WriteLine("3. Manage Orders");
                    Console.WriteLine("4. Manage Employees");
                    Console.WriteLine("5. Manage Reservations");
                    Console.WriteLine("6. Exit");
                    Console.ResetColor();
                    Console.Write("Enter your choice >> ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number.\n");
                        Console.ResetColor();
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option, please try again.\n");
                            Console.ResetColor();
                            break;
                    }
                }
                while (choice != 6);

            }

        }
    }