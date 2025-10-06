using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("123 Maple St", "Richmond", "VA", "USA");
        Address address2 = new Address("78 Queen St", "Toronto", "ON", "Canada");

        
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emily Brown", address2);

        
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "K123", 49.99, 2));
        order1.AddProduct(new Product("Mouse", "M456", 25.50, 1));
        order1.AddProduct(new Product("Monitor", "MN789", 199.99, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "H321", 89.99, 1));
        order2.AddProduct(new Product("Microphone", "MIC654", 120.00, 1));

        
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():F2}");
    }
}
