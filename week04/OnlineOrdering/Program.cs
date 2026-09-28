using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // ====================================================================
            // ORDER 1: Domestic Order (USA Customer)
            // ====================================================================
            Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Doe", address1);
            Order order1 = new Order(customer1);

            // Add 3 products to order 1
            Product prod1_1 = new Product("HP EliteBook G3 Battery", "BATT-HPG3", 45.00, 1);
            Product prod1_2 = new Product("600W Solar Charge Controller", "SOL-SCC600", 85.50, 1);
            Product prod1_3 = new Product("Heavy Duty Zip Ties (Pack of 100)", "HW-ZT100", 7.25, 2);

            order1.AddProduct(prod1_1);
            order1.AddProduct(prod1_2);
            order1.AddProduct(prod1_3);

            // ====================================================================
            // ORDER 2: International Order (Ugandan Customer)
            // ====================================================================
            Address address2 = new Address("Teobia Area", "Lira", "Northern Region", "Uganda");
            Customer customer2 = new Customer("Timothy Ebil", address2);
            Order order2 = new Order(customer2);

            // Add 2 products to order 2
            Product prod2_1 = new Product("Submersible Water Pump 370W", "PUMP-QDX370", 120.00, 1);
            Product prod2_2 = new Product("Digital Multimeter Tool", "TOOL-DMM01", 25.00, 1);

            order2.AddProduct(prod2_1);
            order2.AddProduct(prod2_2);

            // ====================================================================
            // DISPLAY ORDER INVOICES
            // ====================================================================
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                         ONLINE ORDERING INVOICE SYSTEM                        ");
            Console.WriteLine("===============================================================================\n");

            // Display Order 1
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine($"Shipping Cost : ${(customer1.IsCustomerInUSA() ? "5.00" : "35.00")}");
            Console.WriteLine($"Total Invoice : ${order1.CalculateTotalCost():0.00}");
            Console.WriteLine("\n" + new string('=', 79) + "\n");

            // Display Order 2
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine($"Shipping Cost : ${(customer2.IsCustomerInUSA() ? "5.00" : "35.00")}");
            Console.WriteLine($"Total Invoice : ${order2.CalculateTotalCost():0.00}");
            Console.WriteLine("===============================================================================");
        }
    }
}
