using System;
using System.Data;
using Microsoft.Data.SqlClient; // Use this if you installed Microsoft.Data.SqlClient

class Program
{
    static void Main()
    {
        // Connection string (adjust as necessary)
        string connectionString = "Server=localhost;Database=your_database;Integrated Security=True;";

        // SQL query to execute
        string query = "SELECT * FROM your_table";

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    // Read data
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0]); // Change index for different columns
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
