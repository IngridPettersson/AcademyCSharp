using System;
using System.Data.SqlClient;

namespace ADO.NETHakan
{
    class Program
    {
        static SqlConnection sqlConnection = new SqlConnection();

        static void Main(string[] args)
        {
            // ADO.NET är ett API som i sin enklaste form består av 3 klassser:
            //1. SqlConnection
            //2. SqlCommand
            //      SqlParameter (behövs främst när vi ska anropa stored procedures)
            //3. SqlDataReader
            // För att använda ADO.NET behöver man endast kunna grundläggande SQL.

        }
    }
}
