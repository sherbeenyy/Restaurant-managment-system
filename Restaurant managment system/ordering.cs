using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ordering
{

 private readonly Dictionary<int, string> menuItems = new()
    {
        { 1, "Place Order" },
        { 2, "View Order History" },
        { 3, "Exit" }
    };

    // to display the main menu
    public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Menu!");
        Console.WriteLine("==================");

        // to Display the menu items
        foreach (var item in menuItems)
        {
            Console.WriteLine($"{item.Key}. {item.Value}");
        }
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
