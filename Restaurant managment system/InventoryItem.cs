using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class InventoryItem
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public double LowThreshold { get; set; }

    public InventoryItem(string name, double quantity, double lowThreshold)
    {
        Name = name;
        Quantity = quantity;
        LowThreshold = lowThreshold;
    }

    public void UpdateQuantity(double amount)
    {
        Quantity += amount;
        CheckLowInventory();
    }

    private void CheckLowInventory()
    {
        if (Quantity <= LowThreshold)
        {
            Console.WriteLine($"Alert: Inventory low for {Name}. Current stock: {Quantity}");
        }
    }
}

public static class InventoryManager
{
    private static readonly string InventoryFilePath = "inventory.json";
    public static Dictionary<string, InventoryItem> Inventory = new Dictionary<string, InventoryItem>();

    public static void InitializeInventory()
    {
        if (File.Exists(InventoryFilePath))
        {
            LoadInventoryFromFile();
        }
        else
        {
            InitializeDefaultInventory();
            SaveInventoryToFile();
        }
    }



    private static void LoadInventoryFromFile()
    {
        try
        {
            string json = File.ReadAllText(InventoryFilePath);
            Inventory = JsonConvert.DeserializeObject<Dictionary<string, InventoryItem>>(json) ?? new Dictionary<string, InventoryItem>();
            if (Inventory.Count == 0) throw new InvalidOperationException("Loaded inventory is empty.");
            Console.WriteLine("Inventory loaded successfully from file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load inventory from file. Error: {ex.Message}. Initializing with default values.");
            InitializeDefaultInventory();
            SaveInventoryToFile();
        }
    }
    public static void SaveInventoryToFile()
    {
        string json = JsonConvert.SerializeObject(Inventory, Formatting.Indented);
        File.WriteAllText(InventoryFilePath, json);
    }

    private static void InitializeDefaultInventory()
    {
        Inventory.Clear();
        Inventory.Add("Flour", new InventoryItem("Flour", 100, 10));
        Inventory.Add("Sugar", new InventoryItem("Sugar", 50, 5));
    }

   

    public static void AddInventoryItem(string name, double quantity, double lowThreshold = 10)
    {
        if (Inventory.TryGetValue(name, out InventoryItem item))
        {
            item.UpdateQuantity(quantity);
        }
        else
        {
            Inventory[name] = new InventoryItem(name, quantity, lowThreshold);
            Console.WriteLine($"New item added: {name}");
        }
        SaveInventoryToFile();
    }

    public static void UpdateInventory(string name, double quantityChange, double? newLowThreshold = null)
    {
        if (Inventory.TryGetValue(name, out InventoryItem item))
        {
            item.UpdateQuantity(quantityChange);
            if (newLowThreshold.HasValue)
            {
                item.LowThreshold = newLowThreshold.Value;
            }
        }
        else
        {
            Console.WriteLine($"Inventory item {name} not found. Adding new item.");
            Inventory.Add(name, new InventoryItem(name, quantityChange, newLowThreshold ?? 10));
        }
        SaveInventoryToFile();
    }

    public static void CheckInventoryLevels()
    {
        Console.WriteLine("Checking inventory levels for all items:");
        foreach (var item in Inventory)
        {
            if (item.Value.Quantity <= item.Value.LowThreshold)
            {
                Console.WriteLine($"Low stock alert: {item.Key} has only {item.Value.Quantity} units left, which is below the low threshold of {item.Value.LowThreshold}.");
            }
        }
    }

    public static void DisplayInventory()
    {
        Console.WriteLine("Current Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"{item.Key}: {item.Value.Quantity} units (Low Threshold: {item.Value.LowThreshold})");
        }
    }

    public static void AddInventoryItems()
    {
        string input;
        do
        {
            Console.Write("Enter item name ('done' to finish): ");
            input = Console.ReadLine();
            if (input.ToLower() == "done") break;

            string name = input;
            Console.Write("Enter quantity: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter low threshold: ");
            double lowThreshold = Convert.ToDouble(Console.ReadLine());
            InventoryManager.AddInventoryItem(name, quantity, lowThreshold);
            Console.WriteLine("Item added successfully.");
        } while (true);
    }

    public static void EditInventoryItem()
    {
        Console.Write("Enter the name of the item you wish to edit: ");
        string name = Console.ReadLine();

        if (Inventory.TryGetValue(name, out InventoryItem item))
        {
            Console.WriteLine($"Current quantity of {name}: {item.Quantity}");
            Console.Write("Enter new quantity (press Enter to skip): ");
            string quantityInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(quantityInput) && double.TryParse(quantityInput, out double newQuantity))
            {
                item.Quantity = newQuantity;
                Console.WriteLine($"Updated {name} quantity to {item.Quantity}.");
            }

            Console.WriteLine($"Current low threshold of {name}: {item.LowThreshold}");
            Console.Write("Enter new low threshold (press Enter to skip): ");
            string thresholdInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(thresholdInput) && double.TryParse(thresholdInput, out double newLowThreshold))
            {
                item.LowThreshold = newLowThreshold;
                Console.WriteLine($"Updated {name} low threshold to {item.LowThreshold}.");
            }

            // Save changes to file
            SaveInventoryToFile();
            Console.WriteLine("Inventory updated successfully.");
        }
        else
        {
            Console.WriteLine($"Item '{name}' not found in inventory.");
        }
    }
}