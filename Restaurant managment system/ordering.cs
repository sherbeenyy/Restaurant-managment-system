using System;
using System.Collections.Generic;
using static Ordering;
/* + to get the price of food to add them together for the receipt and change line 62 because I did the price = quantity until we get 
the price+ if everything is working well*/

public class Ordering : Menu
{
    // variables for Ordering 
    public int OrderID { get; set; }
    public int Receipt { get; set; }
    public int TaxRate { get; set; }
    public int ServiceCharge { get; set; }
    public DateTime OrderDate { get; set; }
    
    public decimal Subtotal { get; set; }

    // Initialize the OrderItems list
    protected List<OrderItem> OrderItems = new List<OrderItem>();


    public Ordering(int orderID, int receipt, int taxRate, int serviceCharge, DateTime orderDate,decimal subtotal)
    {
        OrderID = orderID;
        Receipt = receipt;
        TaxRate = taxRate;
        ServiceCharge = serviceCharge;
        OrderDate = orderDate;
        Subtotal = subtotal;
    }

    public Ordering()
    {
    }


    // classes for complex tables

    private int nextOrderId = 1;
    private List<OrderList> allOrders = new List<OrderList>();
    
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
    // class epresenting a list of items in an order
    public class OrderList
    {
        public int OrderID { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

        public decimal Subtotal { get; private set; }

        private List<MenuItem> menuItems;


        public OrderList(int orderID, List<MenuItem> menuItems)
        {
            OrderID = orderID;
            OrderItems = new List<OrderItem>();
            this.menuItems = new List<MenuItem>(menuItems);
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
            CalculateSubtotal();
        }
        private void CalculateSubtotal()
        {
            Subtotal = OrderItems.Sum(item =>
            {
                var menuItem = menuItems.FirstOrDefault(m => m.FoodId == item.ItemId);
                return menuItem != null ? menuItem.FoodPrice * item.Quantity : 0;
            });
        }

        // display the orders method
        public void DisplayOrders()
        {
            Console.WriteLine($"Order ID: {OrderID}");
            foreach (var item in OrderItems)
            {
                var menuItem = menuItems.FirstOrDefault(m => m.FoodId == item.ItemId);
                if (menuItem != null)
                {
                    decimal totalCost = menuItem.FoodPrice * item.Quantity;
                    Console.WriteLine($"Item Name: {menuItem.FoodName}, Quantity: {item.Quantity}, Price per Item: {menuItem.FoodPrice}, Total Cost: {totalCost}");
                }
                else
                {
                    Console.WriteLine($"Item ID {item.ItemId} not found in menu.");
                }
            }
            Console.WriteLine($"Subtotal for this Order: {Subtotal}");
        }
    }






    public void AddOrderItem()
    {
        int orderId = nextOrderId++;
        OrderList newOrder = new OrderList(orderId,menuItems);

        allOrders.Add(newOrder);

        Console.WriteLine("Enter item IDs and quantities (type 'done' to finish):");
        while (true)
        {
            Console.Write("Enter item ID: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;

            if (int.TryParse(input, out int itemId))
            {
                var menuItem = menuItems.FirstOrDefault(x => x.FoodId == itemId);
                if (menuItem != null)
                {
                    Console.Write("Enter Quantity of item: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        newOrder.AddItem(new OrderItem(itemId, quantity));
                        Console.WriteLine("Item added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid item ID.");
            }
        }
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
        TaxRate=14;//<------TaxRate can be change anytime we want
        int subtotal = 0;
        foreach (var item in OrderItems)
        {
            subtotal += item.Quantity; // assuming the quantity is the price of the item
        }
        return subtotal * TaxRate / 100;
    }

    public int CalculateTotalCost()
    {
        ServiceCharge=50;//<------ServiceCharge can be change anytime we want
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

    public void ViewOrders()
    {
        Console.WriteLine("===== Orders List");
        if (allOrders.Count == 0)
        {
            Console.WriteLine("There are no orders to display.");
            return;
        }

        foreach (var order in allOrders)
        {
            order.DisplayOrders();
            Console.WriteLine(); // Adds a line for better readability between orders
        }
    }
public void OrderingManagement()
    {
        LoadItemsFromFile();
        bool continueRunning = true;
        while (continueRunning)
        {

            Console.WriteLine("============ORDER PLACMENT========");
             Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Create Order");//To write the food id and the quantity
            Console.WriteLine("3. To Edit Order Quantity");//To edit the order (To change quantity)
            Console.WriteLine("4. Receipt");
            Console.WriteLine("5. ViewOrders");
            Console.WriteLine("6. Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ViewItems();
                    //To View the menu
                    break;
                case "2":
                    AddOrderItem();
                    break;
                case "3":
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
                case "4":
                    PrintOrderDetails();
                    break;
                case "5":
                    ViewOrders();
                    break;
                case "6":
                    continueRunning = false;  // Sets the flag to false to exit the loop.
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
