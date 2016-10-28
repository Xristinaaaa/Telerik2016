using System;
using System.Data.SqlClient;

namespace AddNewProduct
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
                string input = @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice)
                                 VALUES(@name, @supplierId, @categoryId, @quantity, @unitPrice)";
                SqlCommand command = new SqlCommand(input, dbCon);

                command.Parameters.AddWithValue("@name", "Chio- Chips");
                command.Parameters.AddWithValue("@supplierID", 1);
                command.Parameters.AddWithValue("@categoryID", 1);
                command.Parameters.AddWithValue("@quantity", "10000");
                command.Parameters.AddWithValue("@unitPrice", 1);

                command.ExecuteNonQuery();
            }
        }
    }
}
