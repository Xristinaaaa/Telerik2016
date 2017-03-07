using System;

namespace EFNorthwind
{
    class Startup
    {
        static void Main()
        {
            //CustomersFunctionality.InsertCustomer("HLPK", "Hewlett Packard", "Peter Ivanov", "Sofia", "Bulgaria", "12412141");
            //CustomersFunctionality.PrintAllCustomers();

            //CustomersFunctionality.ModifyCustomers("ALFKI", "Ivan Ivanov");
            //CustomersFunctionality.PrintAllCustomers();

            //CustomersFunctionality.DeleteCustomers("HLPK");
            //CustomersFunctionality.PrintAllCustomers();

            CustomersFunctionality.FindSpecificCustomers();
            CustomersFunctionality.FindSpecificCustomersSQL();
            CustomersFunctionality.FindSpecificSales();
        }
    }
}
