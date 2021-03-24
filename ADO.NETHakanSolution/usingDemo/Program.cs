using System;
using System.Data.SqlClient;

namespace usingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection1 = new SqlConnection();
            connection1.Dispose();
            
            // Ovanstående två rader är detsamma som nedan en rad:

            using SqlConnection connection2 = new SqlConnection();

            using Box box = new Box();
            box.Depth = 10;
        }
    }
}
