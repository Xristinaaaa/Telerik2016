using System;
using System.Data.SqlClient;

namespace CategoryProducts
{
    class Startup
    {
        static void Main(string[] args)
        {
            string connection = "Server =.;" + "Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connection);
            dbCon.Open();

            using (dbCon)
            {
                string input = @"SELECT p.ProductName, c.CategoryName 
                                FROM Products p 
                                JOIN Categories c 
                                ON p.CategoryID = c.CategoryID";

                SqlCommand command = new SqlCommand(input, dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        var productName = (string)reader["ProductName"];

                        Console.WriteLine($"Category: {categoryName} | Product name: {productName}");
                    }
                }
            }
        }
    }
}
