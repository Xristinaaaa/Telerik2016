using System;
using EFNorthwind.Data;
using System.Linq;

namespace EFNorthwind
{
    public class CustomersFunctionality
    {
        public static void InsertCustomer(string id, string company, string name, string city, string country, string phone)
        {
            var dbContext = new NORTHWNDEntities();

            var customer = new Customers
            {
                CustomerID = id,
                CompanyName = company,
                ContactName = name,
                City = city,
                Country = country,
                Phone = phone
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        public static void ModifyCustomers(string customerId, string newName)
        {
            var dbContext = new NORTHWNDEntities();

            var customerToModify = dbContext.Customers.Find(customerId);
            customerToModify.ContactName = newName;

            dbContext.SaveChanges();
        }

        public static void DeleteCustomers(string customerId)
        {
            var dbContext = new NORTHWNDEntities();

            var customerToDelete = dbContext.Customers.Find(customerId);

            dbContext.Customers.Remove(customerToDelete);

            dbContext.SaveChanges();
        }
        
        public static void FindSpecificCustomers()
        {
            var dbContext = new NORTHWNDEntities();

            var customers = dbContext.Orders
                                    .Where(o => o.OrderDate.Value.Year > 1997 && o.ShipCountry == "Canada")
                                    .Select(o => o.CustomerID)
                                    .ToList();

            Console.WriteLine("Customers IDs: ");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public static void FindSpecificCustomersSQL()
        {
            var dbContext = new NORTHWNDEntities();

            string nativeSqlQuery = @"SELECT o.CustomerID
                                     FROM Orders o
                                     WHERE YEAR(o.OrderDate) > 1997 AND o.ShipCountry = 'Canada'";
            var customers = dbContext.Database.SqlQuery<string>(nativeSqlQuery).ToList();

            Console.WriteLine("Customers IDs: ");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public static void FindSpecificSales()
        {
            var dbContext = new NORTHWNDEntities();

            var sales = dbContext.Orders
                                    .Where(o => o.OrderDate.Value.Month == 7 
                                            && o.ShippedDate.Value.Month == 8
                                            && o.ShipRegion == "DF")
                                    .Select(o => o.OrderID)
                                    .ToList();

            Console.WriteLine("Sales IDs: ");
            foreach (var sale in sales)
            {
                Console.WriteLine(sale);
            }
        }
        
        public static void PrintAllCustomers()
        {
            var dbContext = new NORTHWNDEntities();

            foreach (var customer in dbContext.Customers)
            {
                Console.WriteLine(customer.CustomerID + " -> " + customer.ContactName);
            }
        }
    }
}
