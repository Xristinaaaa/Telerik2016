using System;
using System.Data.SqlClient;
using System.IO;

namespace CategoriesImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Server =.;" + "Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connection);
            dbCon.Open();

            using (dbCon)
            {
                string input = "SELECT Picture, CategoryName FROM Categories";
                SqlCommand command = new SqlCommand(input, dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        categoryName = categoryName.Replace('/', '-');

                        var imageContent = (byte[])reader["Picture"];
                        var name = categoryName;
                        var imageFormat = ".jpg";
                        var path = "../../images";

                        var fileStream = File.OpenWrite($"{path}{name}{imageFormat}");
                        using (fileStream)
                        {
                            fileStream.Write(imageContent, 78, imageContent.Length - 78);
                        }

                    }
                }
            }
        }
    }
}
