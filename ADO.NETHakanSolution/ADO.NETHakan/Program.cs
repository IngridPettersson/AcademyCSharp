using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ADO.NETHakan
{
    class Program
    {
        // Man måste först skriva @""; innan man kopierar in sin connection string.
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            // ADO.NET är ett API som i sin enklaste form består av 3 klassser:
            //1. SqlConnection
            //2. SqlCommand
            //      SqlParameter (behövs främst när vi ska anropa stored procedures)
            //3. SqlDataReader
            // För att använda ADO.NET behöver man endast kunna grundläggande SQL.

            // Finns tydligen en fin wrapper dapper .. som har gott rykte tydligen. En wrapper runt ADO.NET

            //List<Person> personal = GetPersonal();
            //AddProduct("Röda Lacket", 0.50m);
            UpdateProduct(5, productName: "Gröna lacket");
            UpdateProduct(2, price: 201934098m);
        }

        private static void UpdateProduct(int id, string productName = null, decimal? price = null)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "UpdateProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                // Användandet av SqlParameter skyddar oss från hacking-försök SQL injection, så det ska
                // vi ALLTID använda oss av när vi jobbar med ADO.NET.
                // @productName
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@productName";
                parameter.Value = productName;
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 32;
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);

                // @price
                parameter = new SqlParameter();
                parameter.ParameterName = "@price";
                parameter.Value = price;
                parameter.SqlDbType = SqlDbType.Money;
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);

                // @id
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.Value = id;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);

                int rowsAffected = command.ExecuteNonQuery();

            } //TODO: Add code for exception handling
            // TODO fungerar som keyword som lägger in kommentaren i Task List
            finally
            {
                connection.Close();
            }
        }

        private static void AddProduct(string productName, decimal price)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "AddProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                // @productName
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@productName";
                parameter.Value = productName;
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 32;
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);

                // @price
                parameter = new SqlParameter();
                parameter.ParameterName = "@price";
                parameter.Value = price;
                parameter.SqlDbType = SqlDbType.Money;
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);

                // @id
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameter);

                int rowsAffected = command.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }
        }

        private static List<Person> GetPersonal()
        {
            List<Person> collection = new List<Person>();
            try
            {
                connection.Open();
                using SqlCommand command = new SqlCommand(); // using här kör dispose på command. Se separat projekt i denna solution.
                command.CommandText = "select * from personal";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                //ExecuteReader använder vi när vi får en returnerad resultatmängd som vi vill gå igenom i C#,
                //och annars använder vi ExecuteNonQuery
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // while there are more rows in the table
                {
                    Person person = new Person();

                    person.ID = (int)reader["ID"]; //Vi måste berätta vilken datatyp det är (här int)
                    person.Sektion = reader.IsDBNull("Sektion") ? null : (int?)reader["Sektion"];
                    person.Titel = reader["Titel"].ToString();
                    person.Namn = reader["Namn"].ToString();
                    person.Lön = (decimal)reader["Lön"];

                    person.ChefsID = reader.IsDBNull("ChefsId") ? null : (int?)reader["ChefsId"];

                    collection.Add(person);
                }
            }
            finally
            {
                connection.Close();
            }

            return collection;
        }
    }
}
