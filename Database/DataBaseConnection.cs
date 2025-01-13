using System;
using Npgsql;
using QuizApp;

public class DataBaseConnection
{
    // Sträng för att ansluta till databasen
    private static string connectionString =
        "Host=localhost;Port=5432;Username=postgres;Password=password;Database=quizapp";

    // Skapar och returnerar en ny anslutning till PostgreSQL-databasen
    public static NpgsqlConnection GetConnection()
    {
        try
        {
            return new NpgsqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            throw new Exception("Fel vid skapande av databasanslutning: " + ex.Message);
        }
    }
}
