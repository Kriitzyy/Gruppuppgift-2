using System; 
using Npgsql;
using QuizApp;

public class LoadQuizapp
{
    public static void SetUpDatabase()
    {
        using (var connection = DataBaseConnection.GetConnection())
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected to the database.");

                // Create Tables
                string createTables = @"
                CREATE TABLE IF NOT EXISTS users (
                    id SERIAL PRIMARY KEY,
                    username VARCHAR(50) UNIQUE NOT NULL,
                    best_score INT DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS categories (
                    id SERIAL PRIMARY KEY,
                    name VARCHAR(50) NOT NULL
                );

                CREATE TABLE IF NOT EXISTS questions (
                    id SERIAL PRIMARY KEY,
                    category_id INT REFERENCES categories(id),
                    question TEXT NOT NULL,
                    option_a TEXT NOT NULL,
                    option_b TEXT NOT NULL,
                    option_c TEXT NOT NULL,
                    option_d TEXT NOT NULL,
                    correct_option CHAR(1) NOT NULL
                );

                CREATE TABLE IF NOT EXISTS scores (
                    id SERIAL PRIMARY KEY,
                    user_id INT REFERENCES users(id),
                    score INT NOT NULL
                );
            ";

                using (var command = new NpgsqlCommand(createTables, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tables created successfully.");
                }

                // Add Unique Constraints (Run Separately)
                string addUniqueConstraints = @"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1
                        FROM pg_constraint
                        WHERE conname = 'unique_category_name'
                    ) THEN
                        ALTER TABLE categories ADD CONSTRAINT unique_category_name UNIQUE (name);
                    END IF;

                    IF NOT EXISTS (
                        SELECT 1
                        FROM pg_constraint
                        WHERE conname = 'unique_question'
                    ) THEN
                        ALTER TABLE questions ADD CONSTRAINT unique_question UNIQUE (category_id, question);
                    END IF;
                END $$;
            ";

                using (var command = new NpgsqlCommand(addUniqueConstraints, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Unique constraints added successfully.");
                }

                // Insert Categories
                string insertCategories = @"
                INSERT INTO categories (name) VALUES
                ('General Knowledge'),
                ('Science'),
                ('Math'),
                ('History'),
                ('Spel'),
                ('Programmering'),
                ('Filmer')
                ON CONFLICT DO NOTHING;
            ";

                using (var command = new NpgsqlCommand(insertCategories, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Categories inserted successfully.");
                }

                // Insert Questions
                string insertQuestions = @"
                INSERT INTO questions (category_id, question, option_a, option_b, option_c, option_d, correct_option) VALUES
                -- Spel (Category 5)
                (5, 'Vilken färg har Mario på sina skor?', 'Svart', 'Grå', 'Brun', 'Blå', 'C'),
                (5, 'Vilket djur är Sonic?', 'Mus', 'Kanin', 'Katt', 'Igelkott', 'D'),
                (5, 'Vilket spel är John Cena med i?', 'UFC', 'Street Fighter', 'Tekken', 'WWE', 'D'),
                (5, 'I League of Legends finns en champion som heter Nasus, vilken lane kör man honom?', 'Jungle', 'Top lane', 'Mid lane', 'Bot lane', 'B'),
                (5, 'Hur varvar man klart Minecraft i Survival Mode?', 'Besegra Herobrine', 'Få full Diamond Armor', 'Besegra Witcher', 'Besegra Ender Dragon', 'D'),
                -- Programmering (Category 6)
                (6, 'Hur många bitar har datatypen Long?', '32 bitar', '64 bitar', '8 bitar', '128 bitar', 'B'),
                (6, 'Vilken av följande är inte en giltig datatyp i C#?', 'Integer', 'Decimal', 'String', 'Double', 'A'),
                (6, 'Vilket språk används som grund för Frontend?', 'XML', 'HTML', 'Java', 'SQL', 'B'),
                (6, 'Vad kommer följande kod skriva ut?\nint[] numbers = { 1, 2, 3, 4, 5 };\nConsole.WriteLine(numbers[5]);', '5', '0', 'NullReferenceException', 'IndexOutOfRangeException', 'D'),
                (6, 'Vad betyder NULL i programmering?', 'Tom sträng', 'Felmeddelande', 'Objektreferensfel', 'Inget värde', 'D'),
                -- Filmer (Category 7)
                (7, 'Vad heter ringen som Frodo måste förstöra i Sagan om Ringen?', 'The Ring of Power', 'The One Ring', 'The Elven Ring', 'The Dark Ring', 'B'),
                (7, 'Vilken stad är huvudplatsen för handlingen i filmen Inception?', 'Paris', 'Tokyo', 'Los Angeles', 'New York', 'A'),
                (7, 'Vad heter huvudkaraktären i filmen Pirates of the Caribbean?', 'Will Turner', 'Hector Barbossa', 'Jack Sparrow', 'Davy Jones', 'C'),
                (7, 'Vilken regissör är känd för filmer som Pulp Fiction och Kill Bill?', 'Christopher Nolan', 'Martin Scorsese', 'Steven Spielberg', 'Quentin Tarantino', 'D'),
                (7, 'Vilken animerad Disney-film innehåller låten Let It Go?', 'Moana', 'Tangled', 'Frozen', 'The Little Mermaid', 'C')
                ON CONFLICT DO NOTHING;
            ";

                using (var command = new NpgsqlCommand(insertQuestions, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Questions inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
