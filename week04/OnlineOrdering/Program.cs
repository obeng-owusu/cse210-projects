using System;
using System.Collections.Generic;

namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();

            // Order 1 - USA
            Order order1 = new Order(
                new Customer(
                    "John Smith",
                    new Address(
                        "123 Main Street",
                        "Springfield",
                        "IL",
                        "USA")));

            order1.AddProduct(new Product("Laptop", "P1001", 799.99m, 1));
            order1.AddProduct(new Product("Wireless Mouse", "P1002", 24.99m, 2));
            order1.AddProduct(new Product("USB Cable", "P1003", 9.99m, 3));

            orders.Add(order1);

            // Order 2 - Canada
            Order order2 = new Order(
                new Customer(
                    "Maria Garcia",
                    new Address(
                        "456 Queen Street",
                        "Toronto",
                        "ON",
                        "Canada")));

            order2.AddProduct(new Product("Smartphone", "P2001", 699.99m, 1));
            order2.AddProduct(new Product("Phone Case", "P2002", 19.99m, 2));
            order2.AddProduct(new Product("Screen Protector", "P2003", 12.99m, 3));

            orders.Add(order2);

            // Order 3 - UK
            Order order3 = new Order(
                new Customer(
                    "David Williams",
                    new Address(
                        "789 Baker Street",
                        "London",
                        "Greater London",
                        "United Kingdom")));

            order3.AddProduct(new Product("Headphones", "P3001", 149.99m, 1));
            order3.AddProduct(new Product("Charger", "P3002", 29.99m, 1));

            orders.Add(order3);

            // Order 4 - USA
            Order order4 = new Order(
                new Customer(
                    "Sarah Johnson",
                    new Address(
                        "987 Oak Avenue",
                        "Austin",
                        "TX",
                        "United States")));

            order4.AddProduct(new Product("Monitor", "P4001", 249.99m, 1));
            order4.AddProduct(new Product("Keyboard", "P4002", 59.99m, 1));
            order4.AddProduct(new Product("Desk Mat", "P4003", 29.99m, 1));

            orders.Add(order4);

            int orderNumber = 1;

            foreach (Order order in orders)
            {
                Console.WriteLine();
                Console.WriteLine(new string('=', 60));
                Console.WriteLine($"ORDER #{orderNumber}");
                Console.WriteLine(new string('=', 60));

                Console.WriteLine();
                Console.WriteLine(order.GetPackingLabel());

                Console.WriteLine();
                Console.WriteLine(order.GetShippingLabel());

                Console.WriteLine();
                Console.WriteLine($"TOTAL PRICE: ${order.CalculateTotalCost():F2}");

                Console.WriteLine();
                Console.WriteLine(new string('-', 60));

                orderNumber++;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}