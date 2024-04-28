using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Ordering : Menu
{

 private readonly Dictionary<int, string> menuItems = new()
    {
        { 1, "Place Order" },
        { 2, "View Order History" },
        { 3, "Exit" }
    };

    // to display the main menu
    public override void ViewItems()
    { 
        return;
    }

    //to get the user's selection
    public int GetUserSelection()
    {

        Console.Write("Please enter your selection: ");
        var selection = Console.ReadLine();

        if (int.TryParse(selection, out int selectionNumber) && menuItems.ContainsKey(selectionNumber))
        {
            return selectionNumber;
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
            return -1;
        }
    }
}
