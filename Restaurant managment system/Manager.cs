using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_managment_system
{
    internal class Manager
    {
        List<Employee> employees = new List<Employee>(); //data strcuter like the array but easier to add and delete ;
        List<string> allowedRoles = new List<string>
        {
            "manager","chef","delivery", "waiter","cashier"
        };


        //searching in the list if the role exist 
        private bool foundInAllowedRoles(Employee e)
        {
            for (int i = 0; i < allowedRoles.Count; i++)
            {
                if (allowedRoles[i] == e.Role)
                    return true;

            }
            return false;
        }

        public bool checkIfValid(Employee e)
        {

            // INCOMPLETE !!  we should check for other parameters employee is having 
            if (e.Age < 18)
            {
                Console.WriteLine("can't hire people who is less than 18 years old ");
                return false;
            }
            if (!foundInAllowedRoles(e))
            {
                Console.WriteLine("invalid role");
                return false;
            }
            return true;
        }
        public void hire(Employee e)
        {
            if (checkIfValid(e))
            {
                employees.Add(e);
                Console.WriteLine("hired Sucssefully");
            }
            else
            {
                Console.WriteLine("not hired!");
            }
        }


        public void printEmployees()
        {
            //print the employees
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].Name);
            }
        }

        //delete employee
        public void fire(Employee e)
        {
            employees.Remove(e);
            Console.WriteLine("fired Sucssefully");
        }
    }
}
