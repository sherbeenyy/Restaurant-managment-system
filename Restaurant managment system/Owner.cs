using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

    public class Owner : Manager
    {
    public Owner(int id, string role, string name, int age, string address, string phoneNumber, decimal workingHours, string shift, decimal wage, float expYears)
    : base(id, role, name, age, address, phoneNumber, workingHours, shift, wage, expYears)
    {

    }

    // default constructor
    public  Owner() : base()
        {
        }

        List<Manager> managers = new List<Manager>();


    // this is good
        public Manager promoteToManager(Employee e)
        {
            e.Role = "manager";
            Manager newManager = new Manager(e.Id, e.Role, e.Name, e.Age, e.Address, e.PhoneNumber, e.WorkingHours, e.Shift, 0,0);
            newManager.Name = e.Name;
            newManager.Age = e.Age;
            newManager.Id = e.Id;

            managers.Add(newManager);
            employees.Remove(e);
            return newManager;

        }
        public void printManagers()
        {
            for (int i = 0; i < managers.Count; i++)
            {
                Console.WriteLine(managers[i].Name);
            }
        }

    public void SetupOwnerCredentials()
    {
        Console.WriteLine("======================");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("WE HAVE REALIZED THIS IS YOUR FRIST TIME RUNNUNG THE WEB TIME TO SET UP YOUR ACCOUNT");
        Console.ResetColor();
        Console.WriteLine("Setting up new Owner account.");
        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        Console.ResetColor();

        Credentials credentials = new Credentials { Username = username };
        credentials.SetPassword(password);  // Hash the password

        SaveOwnerCredentials(credentials);  // Save the hashed password
        Console.WriteLine("Owner account created and credentials saved securely.");
    }

    public void SaveOwnerCredentials(Credentials credentials)
    {
        string path = "credentials.json";  // The path where credentials are saved
        string json = JsonConvert.SerializeObject(credentials, Formatting.Indented);
        File.WriteAllText(path, json);
        LoadCredentials();
    }

    private const string CredentialsPath = "credentials.json";

    public Credentials CurrentCredentials { get; private set; }
    public bool LoadCredentials()
    {
        if (File.Exists(CredentialsPath))
        {
            string json = File.ReadAllText(CredentialsPath);
            CurrentCredentials = JsonConvert.DeserializeObject<Credentials>(json);
            return true;
        }
        return false;
    }

}



