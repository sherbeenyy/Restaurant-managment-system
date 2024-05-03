using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

    [Serializable]

public class MenuItem
{
    public string FoodName { get; set; }
    public string FoodDescription { get; set; }
    public decimal FoodPrice { get; set; }
    public string FoodCategory { get; set; }
    public int FoodId { get; set; }
    public Dictionary<string, double> IngredientsRequired { get; set; } // New property

    public MenuItem(string foodName, string foodDescription, decimal foodPrice, string foodCategory, int foodId)
    {
        FoodName = foodName;
        FoodDescription = foodDescription;
        FoodPrice = foodPrice;
        FoodCategory = foodCategory;
        FoodId = foodId;
        IngredientsRequired = new Dictionary<string, double>();
    }

    // Example method to add ingredients to the menu item
    public void AddIngredient(string ingredientName, double quantity)
    {
        if (IngredientsRequired.ContainsKey(ingredientName))
        {
            IngredientsRequired[ingredientName] += quantity;  // Update quantity if already exists
        }
        else
        {
            IngredientsRequired.Add(ingredientName, quantity); // Add new ingredient if not exists
        }
    }

}

public class Menu
{
   public List<MenuItem> menuItems = new List<MenuItem>(); // create a list of menu items named menuItems

// testing in the main function

   public void MenuManagement()
{
    LoadItemsFromFile();  // Load items when the program starts
    bool continueRunning = true;
    while (continueRunning)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("========Menu Management========");
        Console.WriteLine("1. Add new item");
        Console.WriteLine("2. Edit item by ID");
        Console.WriteLine("3. View Menu");
        Console.WriteLine("4. Remove item by ID");
        Console.WriteLine("5. Exit");
        Console.ResetColor();

        Console.Write(">> ");
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                AddNewItem();
                break;
            case "2":
                EditItem();
                break;
            case "3":
                ViewItems();
                break;
            case "4":
                RemoveItem();
                break;
            case "5":
                continueRunning = false;
                SaveItemsToFile(); // Save items when the program exits
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Exiting menu management.");
                Console.ResetColor();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option, please try again.");
                Console.ResetColor();
                break;
        }
    }
}

    // function to add new item to the menu from the user
    public void AddNewItem()
    {
        Console.WriteLine("=========Creating New Item============");
        string name = InputValidator.ReadString("Enter item name: ");
        string description = InputValidator.ReadString("Enter item description: ");
        decimal price = InputValidator.ReadDecimal("Enter item price: ");
        string category = InputValidator.ReadString("Enter item category: ");

        bool isUnique = false;
        int foodId;
        do
        {
            foodId = InputValidator.ReadInt("Enter a unique ID for the item: ");
            isUnique = !menuItems.Any(x => x.FoodId == foodId);
            if (!isUnique)
            {
                Console.WriteLine($"An item with ID {foodId} already exists. Please enter a different ID;");
            }
        } while (!isUnique);

        var newItem = new MenuItem(name, description, price, category, foodId);

        bool addingIngredients = true;
        Console.WriteLine("Enter ingredients (type 'done' when finished):");
        while (addingIngredients)
        {
            string ingredientName = InputValidator.ReadString("Enter ingredient name: ");
            if (ingredientName.ToLower() == "done")
            {
                addingIngredients = false;
                continue;
            }
            double quantity = InputValidator.ReadDouble("Enter quantity required: "); // Assuming this method exists or you implement it similarly to ReadInt/ReadDecimal
            newItem.AddIngredient(ingredientName, quantity);
            // Here you would update inventory, if this ingredient addition should affect inventory
            InventoryManager.AddInventoryItem(ingredientName, quantity, 10); // Assuming default low threshold
        }

        menuItems.Add(newItem);
        SaveItemsToFile();
        Console.WriteLine("New item added successfully.\n");
    }


    public void Createitem(MenuItem item)
    {
        menuItems.Add(item);
    }

    // remove item from list by id
    public void RemoveItem()
    {
       int id = InputValidator.ReadInt("Enter the ID of the item you want to remove: ");

        var item = menuItems.FirstOrDefault(x => x.FoodId == id);
        if (item != null)
        {
            menuItems.Remove(item); // Remove the item from the list
            SaveItemsToFile();      // Save the current state of list to file

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Item removed successfully: {item.FoodName}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Item not found.");
            Console.ResetColor();
        }
    }

    // edit item by id
    public void EditItem()
    {
        int id = InputValidator.ReadInt("Enter the ID of the item you want to edit: ");
        MenuItem item = menuItems.FirstOrDefault(x => x.FoodId == id);
        if (item != null)
        {
            Console.WriteLine("=======Editing Item========");
            Console.WriteLine("What do you wish to edit?\n1. Name\n2. Description\n3. Price\n4. Category\n5. Ingredients\n6. All");
            int choice = InputValidator.ReadInt("Enter your choice: ");
            switch (choice)
            {
                case 1:
                    item.FoodName = InputValidator.ReadString("Enter new name: ");
                    break;
                case 2:
                    item.FoodDescription = InputValidator.ReadString("Enter new description: ");
                    break;
                case 3:
                    item.FoodPrice = InputValidator.ReadDecimal("Enter new price: ");
                    break;
                case 4:
                    item.FoodCategory = InputValidator.ReadString("Enter new category: ");
                    break;
                case 5:
                    EditIngredients(item);
                    break;
                case 6:
                    EditAll(item);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            SaveItemsToFile();
        }
        else
        {
            Console.WriteLine("Item not found");
        }
    }

    private void EditIngredients(MenuItem item)
    {
        Console.WriteLine("Editing Ingredients (type 'done' to finish):");
        item.IngredientsRequired.Clear(); // Clear existing ingredients or manage them differently
        bool editingIngredients = true;
        while (editingIngredients)
        {
            string ingredientName = InputValidator.ReadString("Enter ingredient name or 'done': ");
            if (ingredientName.ToLower() == "done")
            {
                editingIngredients = false;
                continue;
            }
            double quantity = InputValidator.ReadDouble("Enter quantity required: ");
            item.AddIngredient(ingredientName, quantity);
            // Here you would update inventory, if this ingredient addition should affect inventory
            InventoryManager.AddInventoryItem(ingredientName, quantity, 10); // Assuming default low threshold

        }
    }


    private void EditAll(MenuItem item)
    {
        item.FoodName = InputValidator.ReadString("Enter new name: ");
        item.FoodDescription = InputValidator.ReadString("Enter new description: ");
        item.FoodPrice = InputValidator.ReadDecimal("Enter new price: ");
        item.FoodCategory = InputValidator.ReadString("Enter new category: ");
    }

   
    public virtual void ViewItems()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=======Welcome to the Menu=====\n");
        Console.ResetColor();

        foreach (var item in menuItems)
        {
            Console.WriteLine($"ID: {item.FoodId}, Name: {item.FoodName}, Description: {item.FoodDescription}, Price: {item.FoodPrice}, Category: {item.FoodCategory}\n ");
        }  
    }

    private const string path = "Menu.json";
    public void LoadItemsFromFile()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path); // Read JSON content from the file
            menuItems = JsonConvert.DeserializeObject<List<MenuItem>>(json) ?? new List<MenuItem>(); // Deserialize JSON to List<MenuItem>
        }
        else
        {
            menuItems = new List<MenuItem>(); // Initialize empty list if file doesn't exist
        }
    }
    public void SaveItemsToFile()
    {
        string json = JsonConvert.SerializeObject(menuItems, Formatting.Indented); // Serialize list to JSON
        File.WriteAllText(path, json); // Write JSON content to the file
    }
}





