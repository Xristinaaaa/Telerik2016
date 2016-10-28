using System;
using System.Data.SqlClient;

namespace CategoriesDescription
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
                string input = "SELECT CategoryName, Description FROM Categories";
                SqlCommand command = new SqlCommand(input, dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        var categoryDescription = (string)reader["Description"];

                        Console.WriteLine($"Category | name- {categoryName} | description- {categoryDescription}");
                    }
                }
            }
        }
    }
}
