using System;
using System.Collections.Generic;

public class Ordering
{
    public int OrderID { get; set; }
    public int Receipt { get; set; }
    public int TaxRate { get; set; }
    public int ServiceCharge { get; set; }
    public string OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    public Ordering(int orderID, int receipt, int taxRate, int serviceCharge, string orderDate)
    {
        OrderID = orderID;
        Receipt = receipt;
        TaxRate = taxRate;
        ServiceCharge = serviceCharge;
        OrderDate = orderDate;

        // Initialize the OrderItems list
        OrderItems = new List<OrderItem>();
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }

    public void AddOrderItem(int itemId, int quantity)
    {
        // Add a new OrderItem object to the OrderItems list
        OrderItems.Add(new OrderItem(itemId, quantity));
    }

    public void EditOrderItemQuantity(int itemId, int newQuantity)
    {
        // Find the OrderItem object with the specified itemId
        OrderItem item = OrderItems.Find(i => i.ItemId == itemId);
        if (item != null)
        {
            item.Quantity = newQuantity;
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public int CalculateTax()
    {
        int subtotal = 0;
        foreach (var item in OrderItems)
        {
            subtotal += item.Quantity; // assuming the quantity is the price of the item
        }
        return subtotal * TaxRate / 100;
    }

    public int CalculateTotalCost()
    {
        int subtotal = 0;
        foreach (var item in OrderItems)
        {
            subtotal += item.Quantity; // assuming the quantity is the price of the item
        }
        return subtotal + (subtotal * TaxRate / 100) + ServiceCharge;
    }

    public void PrintOrderDetails()
    {
        Console.WriteLine($"Order ID: {OrderID}");
        Console.WriteLine($"Order Items: {OrderItems}");
        Console.WriteLine($"Receipt: {Receipt}");
        Console.WriteLine($"Tax Rate: {TaxRate}%");
        Console.WriteLine($"Service Charge: {ServiceCharge}");
        Console.WriteLine($"Order Date: {OrderDate}");
        Console.WriteLine($"Tax: {CalculateTax()}");
        Console.WriteLine($"Total Cost: {CalculateTotalCost()}");
    }

    public void OrderingManagement()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. To Order");//To write the food id and the quantity
            Console.WriteLine("2. To Edit Order Quantity");//To edit the order (To change quantity)
            Console.WriteLine("3. Reciept");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Please enter the food Id: ");
                    string itemIdStr = Console.ReadLine();
                    if (int.TryParse(itemIdStr, out int itemId))
                    {
                        Console.Write("Please enter the quantity: ");
                        string quantityStr = Console.ReadLine();
                        if (int.TryParse(quantityStr, out int quantity))
                        {
                            AddOrderItem(itemId, quantity);
                            Console.WriteLine("Order added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid food Id.");
                    }
                    break;
                case "2":
                    Console.Write("Please enter the food Id: ");
                    string editItemIdStr = Console.ReadLine();
                    if (int.TryParse(editItemIdStr, out int editItemId))
                    {
                        Console.Write("Please enter the new quantity: ");
                        string newQuantityStr = Console.ReadLine();
                        if (int.TryParse(newQuantityStr, out int newQuantity))
                        {
                            EditOrderItemQuantity(editItemId, newQuantity);
                            Console.WriteLine("Order quantity updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid food Id.");
                    }
                    break;
                case "3":
                    PrintOrderDetails();
                    break;
                case "4":
                    continueRunning = false;  // Sets the flag to false to exit the loop.
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
