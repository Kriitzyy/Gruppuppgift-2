using System;
using Npgsql;
using QuizApp;

public class DataBaseConnection
{
    //Sträng för att ansluta till databasen
    private static string connectionString =
        "Host=localhost;Port=5432;Username=postgres;Password=123;Database=quiz_app_db";
        
   // Metod som använder NpgsqlConnection-klassen som returtyp. NpgsqlConnection hanterar anslutningar till en PostgreSQL-server.
    public static NpgsqlConnection GetConnection()
    {
        try
        {
            return new NpgsqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            throw new Exception("Fel vid skapande av databasanslutning" + ex.Message);
        }
    }
}
