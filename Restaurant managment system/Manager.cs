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

        public bool checkIfValid(Employee e)
        {

            // INCOMPLETE !!  we should check for other parameters employee is having 
            if (e.Age < 18)
            {
                Console.WriteLine("can't hire people who is less than 18 years old ");
                return false;
            }
            // not working IDK WHY ????????
            if ( e.Role != "manager" || e.Role != "chef" || e.Role != "delivery" || e.Role != "waiter" || e.Role != "cashier") {
                Console.WriteLine("Invalid role");
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



    }
}
