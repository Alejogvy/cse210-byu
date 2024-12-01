using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create clients
        Customer customer1 = new Customer("Daniel Sánchez", address1);
        Customer customer2 = new Customer("Bryan Niaupari", address2);

        // Create orders
        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        // Adding products to orders
        order1.AddProduct(new Product("Laptop", "A123", 799.99m, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.50m, 2));

        order2.AddProduct(new Product("Desk Chair", "C789", 150.00m, 1));
        order2.AddProduct(new Product("Desk Lamp", "D012", 45.00m, 1));

        // Display order information
        DisplayOrderDetails(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
    }
}
