using System;
using Npgsql;

public class DatabaseHelper
{
    // Connection string to your PostgreSQL database
    private static readonly string ConnectionString = "Host=localhost;Username=postgres;Password=Mo20042004;Database=Quizapp";

    // Method to test the database connection
    public static void TestConnection()
    {
        // Create a connection object using the connection string
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            try
            {
                // Open the connection
                connection.Open();
                Console.WriteLine("Connection successful!");

                // Example of querying the categories table
                using (var cmd = new NpgsqlCommand("SELECT * FROM public.categories", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Category ID: {reader["id"]}, Name: {reader["name"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If there is an error, print the message
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Message: {ex.Message}"); // Error message
                Console.WriteLine($"Source: {ex.Source}");   // Source of the error (e.g., the method where it happened)
                Console.WriteLine($"StackTrace: {ex.StackTrace}"); // Full stack trace
                Console.WriteLine($"Method: {ex.TargetSite.Name}");
                Console.WriteLine();
            }
            finally
            {
                // Ensure the connection is closed
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}