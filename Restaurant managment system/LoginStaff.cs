using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class LoginStaff
{

    private string username = "staff";
    private string password = "staff";

    public LoginStaff() { }

    public bool loginForStaff(string username, string password)
    {
        if(username != "staff" ||  password != "staff")
        {
            return false;
        }
        return true;
    }


}
  

