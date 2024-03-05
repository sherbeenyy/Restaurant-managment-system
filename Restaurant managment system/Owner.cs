using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_managment_system
{


    internal class Owner
    {
        List<Employee> employees; //data strcute like the array but easier to add and delete ;

        public bool checkIfValid(Employee e)
        {

            // INCOMPLETE !!  we should check for other parameters 
            if (e.Age == -1)
            { return false; }

            return true;
        }

        public void hire(Employee e)
        {
            if (checkIfValid(e))
            {
                employees.Add(e);
            }
        }

    }
}
