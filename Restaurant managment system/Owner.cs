using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

    public class Owner : Manager
    {
        public Owner(int id, string role, string name, int age, string address, string phoneNumber, float workingHours, int shift, float expYears) : base(id, role, name, age, address, phoneNumber, workingHours, shift, expYears)
        {
        }
        List<Manager> managers = new List<Manager>();

        public Manager promoteToManager(Employee e)
        {
            e.Role = "manager";
            Manager newManager = new Manager(e.Id, e.Role, e.Name, e.Age, e.Address, e.PhoneNumber, e.WorkingHours, e.Shift, 0);
            newManager.Name = e.Name;
            newManager.Age = e.Age;
            newManager.Salary = e.Salary;
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

       

    }



