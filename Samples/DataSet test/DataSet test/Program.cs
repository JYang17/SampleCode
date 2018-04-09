using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace DataSet_test
{
    class Program
    {
        private static void DemonstrateReadWriteXMLDocumentWithStreamReader(string xmlFilePath)
        {
            // Create a DataSet with one table and two columns.
            DataSet OriginalDataSet = new DataSet("dataSet");
            OriginalDataSet.Namespace = "NetFrameWork";
            DataTable table = new DataTable("table");
            DataColumn idColumn = new DataColumn("id",
                Type.GetType("System.Int32"));
            idColumn.AutoIncrement = true;

            DataColumn itemColumn = new DataColumn("item");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            OriginalDataSet.Tables.Add(table);

            // Add ten rows.
            DataRow newRow;
            for (int i = 0; i < 10; i++)
            {
                newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }
            OriginalDataSet.AcceptChanges();

            // Print out values of each table in the DataSet 
            // using the function defined below.
            PrintValues(OriginalDataSet, "Original DataSet");

            // Write the schema and data to an XML file.
            string xmlFilename = xmlFilePath;

            // Use WriteXml to write the document.
            OriginalDataSet.WriteXml(xmlFilename);

            // Dispose of the original DataSet.
            OriginalDataSet.Dispose();

            // Create a new DataSet.
            DataSet newDataSet = new DataSet("New DataSet");

            // Read the XML document into the DataSet.
            newDataSet.ReadXml(xmlFilename);

            // Print out values of each table in the DataSet 
            // using the function defined below.
            PrintValues(newDataSet, "New DataSet");
        }

        private static void PrintValues(DataSet dataSet, string label)
        {
            Console.WriteLine("\n" + label);
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine("TableName: " + table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.Write("\table " + row[column]);
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            DemonstrateReadWriteXMLDocumentWithStreamReader(@"C:\GenericProfileTemplate.xml");
        }
    }
}
