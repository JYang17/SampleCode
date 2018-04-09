using System;
using System.Data;
using System.Data.Common;

namespace TestAdoNet
{
    class Program
    {
        static void Main()
        {
            //you can "add connection" or "create new sql server database" under the Data Connections tree node of the Server Explorer page.
            //In this case, I select "create new sql server database".
            var providerName = "System.Data.SqlClient";
            var connectStr = @"Data Source=APCNDAE1TZB762\SQL2014EXPRESS;Initial Catalog=JeremyDatabase1;Integrated Security=True;Pooling=False";
            //var connect = new SqlConnection(connectStr);

            var factory = DbProviderFactories.GetFactory(providerName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectStr;

            using (connection)
            {
                var commandString = GetSelectAllString();

                var command = factory.CreateCommand();
                command.CommandText = commandString;
                command.Connection = connection;

                var adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                var table = new DataTable();
                adapter.Fill(table);

                //you can retrieve the data table only if you execute a query command.
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn colum in table.Columns)
                    {
                        Console.WriteLine(row[colum]);
                    }
                }
            }

            Console.ReadKey();
        }

        private static string GetCreateDbString()
        {
            return "CREATE DATABASE JeremyDatabase2;";
        }

        private static string GetCreateTableString()
        {
            return "CREATE TABLE JeremyTable1" +
                    "(" +
                    "ID int PRIMARY KEY," +
                    "Name varchar(50)" +
                    ");";
        }

        private static string GetInsertIntoString()
        {
            return "INSERT INTO JeremyTable1 (ID,Name) VALUES (1,'Jeremy');";
        }

        private static string GetSelectAllString()
        {
            return "SELECT * FROM JeremyTable1";
        }
    }
}
