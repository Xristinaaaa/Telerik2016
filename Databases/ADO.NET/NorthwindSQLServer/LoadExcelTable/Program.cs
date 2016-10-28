using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadExcelTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\PeopleScores.xls;Persist Security Info=False";

            DataSet dataSet = new DataSet();

            OleDbConnection dbConn = new OleDbConnection(connection);
            dbConn.Open();

            using (dbConn)
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = dbConn;
                
                DataTable dtSheet = dbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    if (!sheetName.EndsWith("$"))
                    {
                        continue;
                    }
                    
                    command.CommandText = "SELECT * FROM [" + sheetName + "]";

                    DataTable dt = new DataTable();
                    dt.TableName = sheetName;

                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    da.Fill(dt);

                    dataSet.Tables.Add(dt);
                }

                command = null;
                dbConn.Close();
            }
        }
    }
}
