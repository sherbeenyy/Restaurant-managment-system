using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Reservations
    {
    private string Name { get; set; }
        private string PhoneNumber { get; set; }
        private string Address { get; set; }
        private int NumberOfPeople { get; set; }
        private DateTime ReservationTime { get; set; }

        public Reservations(string name, string phoneNumber, string address, int numberOfPeople, DateTime reservationTime)
    {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            NumberOfPeople = numberOfPeople;
            ReservationTime = reservationTime;
        }

    // Defualt constructor
    public Reservations()
    {
    }

        public void AddReservation()
    {
            Console.Write("Enter customer name: ");
            Name = Console.ReadLine();

            Console.Write("Enter customer phone number: ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Enter customer address: ");
            Address = Console.ReadLine();

            Console.Write("Enter number of people: ");
            NumberOfPeople = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter reservation time: ");
            ReservationTime = Convert.ToDateTime(Console.ReadLine());
        }

        public void DisplayReservation()
    {
            Console.WriteLine($"Name: {Name}, Phone Number: {PhoneNumber}, Address: {Address}, Number of People: {NumberOfPeople}, Reservation Time: {ReservationTime}");
        }

    // testing in the main function

    public void ReservationManagement()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("1. Add new Reservation");
            Console.WriteLine("2. Remove Reservation");
            Console.WriteLine("3. View Reservations");
            Console.WriteLine("4. Edit Reservation");
            Console.WriteLine("5. Exit");
            Console.Write(">> ");
            string option = Console.ReadLine();
            Console.WriteLine("==================");

            switch (option)
            {
                case "1":
                    AddReservation();
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;

                case "4":
                    break;
                case "5":
                    continueRunning = false;  // Sets the flag to false to exit the loop.
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }



}

