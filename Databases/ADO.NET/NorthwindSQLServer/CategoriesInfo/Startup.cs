using System;
using System.Data.SqlClient;

namespace CategoriesInfo
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
                string input = "SELECT COUNT(*) FROM Categories";
                SqlCommand command = new SqlCommand(input, dbCon);

                int categoriesCount = (int)command.ExecuteScalar();

                Console.WriteLine("Rows count: {0} ", categoriesCount);
            }
        }
    }
}
