using System;

class Program
{
    static void Main(string[] args)
    {
        // First order

        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Tent", "T001", 120.50, 1));
        order1.AddProduct(new Product("Sleeping Bag", "S002", 45.00, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        // Second order
        
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Kayak", "K003", 300.00, 1));
        order2.AddProduct(new Product("Helmet", "H004", 50.00, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}
