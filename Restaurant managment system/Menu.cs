using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]

public class MenuItem

{
    public string FoodName { get; set; }
    public string FoodDescription { get; set; }
    public decimal FoodPrice { get; set; }
    public string FoodCategory { get; set; }
    public int FoodId { get; set; } // Add a unique id for each item

    public MenuItem(string foodName, string foodDescription, decimal foodPrice, string foodCategory, int foodId)
    {
        FoodName = foodName;
        FoodDescription = foodDescription;
        FoodPrice = foodPrice;
        FoodCategory = foodCategory;
        FoodId = foodId;
    }
}



public class Menu
{
    private List<MenuItem> menuItems = new List<MenuItem>(); // create a list of menu items named menuItems

// testing in the main function
    public void MenuMangemnet()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. Edit item by ID");
            Console.WriteLine("3. View Menu");
            Console.WriteLine("4. Remove item by ID");
            Console.WriteLine("5. Exit");
            Console.Write(">> ");
            string option = Console.ReadLine();
            Console.WriteLine("==================");

            switch (option)
            {
                case "1":
                    AddNewItem();
                    break;
                case "2":
                    EditErorrHandler();
                    break;
                case "3":
                    ViewItems();
                    break;
                case "4":
                    RemoveItem();
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

    // function to add new item to the menu from the user
    public void AddNewItem()
    {

         Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        Console.Write("Enter item description: ");
        string description = Console.ReadLine();

        Console.Write("Enter item price: ");
        decimal price;

        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input for price. Please enter a decimal value.");
            Console.Write("Enter item price: ");
        }

        Console.Write("Enter item category: ");
        string category = Console.ReadLine();

        // Ask the user for a unique id for the item

        bool isUnique = false;
        int foodId;
        do
    {
        Console.Write("Enter item id: ");
        while (!int.TryParse(Console.ReadLine(), out foodId))
        {
            Console.WriteLine("Invalid input for ID. Please enter an integer value.");
            Console.Write("Enter item id: ");
        }

        // Check if the foodId is unique

        isUnique = !menuItems.Any(x => x.FoodId == foodId);
        if (!isUnique)
        {
            Console.WriteLine($"An item with ID {foodId} already exists. Please enter a unique ID.");
        }
    } while (!isUnique);
        
        // Create a new MenuItem object with the user input

        var newItem = new MenuItem(name, description, price, category,foodId);

       
        // input data into file and print for testing 

        string path = @"C:\Users\mazen\OneDrive\Desktop\test\OOP project\Restaurant-managment-system\Restaurant managment system\files\menu.txt";
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($" foodID: , name: , description: , price: , category: ");
                sw.WriteLine($"{foodId} {name} {description} {price} {category} ");
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{foodId} {name} {description} {price} {category} ");
            }
        }

        {
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }


        // Add the new item to the list

        Createitem(newItem);// .add is a built in function in list to add new items 

        Console.WriteLine("\nNew item added successfully.\n");

    }


    // remove item from list by id
    public void RemoveItem()
    {
        Console.WriteLine("Enter the id of the item you want to remove ? : ");
        Console.Write(">> ");
        int id = int.Parse(Console.ReadLine());

        // Find item by id and remove it
        MenuItem item = menuItems.FirstOrDefault(x => x.FoodId == id);
        if (item != null)
        {
            Console.WriteLine("Item removed successfully."+item.FoodName);
            menuItems.Remove(item);
        }
        else
        {
            Console.WriteLine("Item not found\n");
            Console.WriteLine("==================================");
        }
    }


    // add item to the list
    public void Createitem(MenuItem item)
    {
        menuItems.Add(item);
    }

        


    // edit item by id
    public void EditItem(int id)
    {

        // Find item by id and edit it
        MenuItem item = menuItems.FirstOrDefault(x => x.FoodId == id);
        if (item != null)
        {
            Console.WriteLine("what do you wish to edit ? " +
                "1. Name\n" +
                "2. Description\n" +
                "3. Price\n" +
                "4. Category\n" +
                "5. All");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter new name: ");
                    item.FoodName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter new description: ");
                    item.FoodDescription = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Enter new price: ");
                    item.FoodPrice = Convert.ToDecimal(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Enter new category: ");
                    item.FoodCategory = Console.ReadLine();
                    break;
                case 5:
                    EditAll(item);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Item not found\n");
            Console.WriteLine("==================================");
        }
    }

    private void EditAll(MenuItem item)
    {
        Console.WriteLine("Enter new name: ");
        item.FoodName = Console.ReadLine();
        Console.WriteLine("Enter new description: ");
        item.FoodDescription = Console.ReadLine();
        Console.WriteLine("Enter new price: ");
        item.FoodPrice = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter new category: ");
        item.FoodCategory = Console.ReadLine();
    }

   private void EditErorrHandler()
   {
        try
                {
                    Console.WriteLine("Enter the id of the item you want to edit ? : ");
                    Console.Write(">> ");
            int id = int.Parse(Console.ReadLine());
                    EditItem(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input please input a number starting from 1.");
                    Console.WriteLine(e.Message);

                }
   }
    public virtual void ViewItems()
    {
        Console.WriteLine("Welcome to the Menu!");

        foreach (var item in menuItems)
        {
            Console.WriteLine($"ID: {item.FoodId} , Name: {item.FoodName} , Description: {item.FoodDescription} , Price: {item.FoodPrice} , Category: {item.FoodCategory}\n ");
        }  
        Console.WriteLine("==================");
     
       
    }
}

    

  

