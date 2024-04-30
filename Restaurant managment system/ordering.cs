using System;
using System.Collections.Generic;
using static Ordering;
/*Function that make remove order, ask for customer info,if info does not exist create customer info finally use the small percentage of subtotal and added to customer
 loyalty points */

public class Ordering : Menu
{
    // variables for Ordering 
    public int OrderID { get; set; }
    public int Receipt { get; set; }
    public int TaxRate = 14;
    public int ServiceCharge = 50;
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
        public void CalculateSubtotal()
        {
            Subtotal = OrderItems.Sum(item =>
            {
                var menuItem = menuItems.FirstOrDefault(m => m.FoodId == item.ItemId);
                return menuItem != null ? menuItem.FoodPrice * item.Quantity  : 0;
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

    private void EditExistingOrder() //  to modify specific order
    {
        ViewOrders(); // Display all orders for user to choose from
        Console.WriteLine("Enter the Order ID you want to edit:"); // we enter the order id not item id
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            var order = allOrders.FirstOrDefault(o => o.OrderID == orderId);// it search for the order id that we entered
            if (order != null)
            {
                Console.WriteLine("Editing Order ID: " + orderId);
                bool editing = true;
                while (editing)
                {
                    Console.WriteLine("=======Edit menu=======");
                    Console.WriteLine("1. Add new item");
                    Console.WriteLine("2. Edit item quantity");
                    Console.WriteLine("3. Finish editing");
                    string editChoice = Console.ReadLine();
                    switch (editChoice)
                    {
                        case "1":
                            AddItemToOrder(order);// to add extra stuff in order (line 301)
                            break;
                        case "2":
                            EditItemQuantityInOrder(order); //we edit an item quantity (line 331)
                            break;
                        case "3":
                            editing = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Order ID not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Order ID.");
        }
    }

    private void AddItemToOrder(OrderList order) //to add items in order
    {
        Console.WriteLine("Enter item ID: ");
        if (int.TryParse(Console.ReadLine(), out int itemId))
        {
            var menuItem = menuItems.FirstOrDefault(x => x.FoodId == itemId);
            if (menuItem != null)
            {
                Console.WriteLine("Enter quantity of item:");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    order.AddItem(new OrderItem(itemId, quantity));
                    Console.WriteLine("Item added successfully.");
                }
            }
            else
            {
                Console.WriteLine("Item ID not found in menu.");
            }
        }
        else
        {
            Console.WriteLine("Invalid item ID.");
        }
    }

    private void EditItemQuantityInOrder(OrderList order)// To edit the order qunatity
    {
        Console.WriteLine("Enter item ID to edit quantity:");
        if (int.TryParse(Console.ReadLine(), out int itemId))
        {
            var item = order.OrderItems.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                Console.WriteLine("Current quantity: " + item.Quantity);
                Console.WriteLine("Enter new quantity:");
                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    item.Quantity = newQuantity;
                    order.CalculateSubtotal(); // Recalculate subtotal after editing quantity
                    Console.WriteLine("Quantity updated successfully.");
                }
            }
            else
            {
                Console.WriteLine("Item ID not found in the order.");
            }
        }
        else
        {
            Console.WriteLine("Invalid item ID.");
        }
    }

    public void PrintOrderDetails()
    {
        ViewOrders(); // Display all orders for user to choose from
        Console.WriteLine("Enter the Order ID for which you want the receipt:");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            var order = allOrders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                OrderDate = DateTime.Now; // Update the order date to the current date
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"========Printing receipt for Order ID: {orderId}===========");
                Console.ResetColor();
                
                Console.WriteLine($"Order Date: {OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}");
                Console.WriteLine("Ordered Items:");
                foreach (var item in order.OrderItems)
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
                Console.WriteLine($"Subtotal for this Order: {order.Subtotal}");
                Console.WriteLine($"Service Charge: {ServiceCharge}");
                Console.WriteLine($"Tax Rate: {TaxRate}%");
                Console.WriteLine($"Total Cost: {order.Subtotal + ServiceCharge + (order.Subtotal * TaxRate / 100)}");
                }
            else
            {
                Console.WriteLine("Order ID not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Order ID.");
        }
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
            Console.WriteLine("============ ORDER PLACEMENT ========");
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Create Order");
            Console.WriteLine("3. Edit Existing Order");
            Console.WriteLine("4. Print Receipt");
            Console.WriteLine("5. View All Orders");
            Console.WriteLine("6. Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ViewItems();
                    break;
                case "2":
                    AddOrderItem();
                    break;
                case "3":
                    EditExistingOrder();
                    break;
                case "4":
                    PrintOrderDetails(); // Ensure this function prints details of all orders or let user select an order
                    break;
                case "5":
                    ViewOrders();
                    break;
                case "6":
                    continueRunning = false; // Exit the loop
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

   

}
