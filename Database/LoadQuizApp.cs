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
                ('History')
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
                -- General Knowledge (Category 1)
                (1, 'What is the capital of France?', 'Paris', 'London', 'Berlin', 'Madrid', 'A'),
                (1, 'Who wrote ""Hamlet""?', 'Shakespeare', 'Dickens', 'Hemingway', 'Tolkien', 'A'),
                (1, 'What is the boiling point of water?', '100°C', '90°C', '110°C', '80°C', 'A'),
                (1, 'Who painted the Mona Lisa?', 'Van Gogh', 'Picasso', 'Da Vinci', 'Rembrandt', 'C'),
                (1, 'Which gas do plants absorb from the atmosphere?', 'Oxygen', 'Carbon Dioxide', 'Nitrogen', 'Hydrogen', 'B'),
                -- Science (Category 2)
                (2, 'Who discovered penicillin?', 'Newton', 'Edison', 'Fleming', 'Darwin', 'C'),
                (2, 'What is the chemical symbol for gold?', 'Au', 'Ag', 'Go', 'Gd', 'A'),
                (2, 'What is the hardest natural substance on Earth?', 'Iron', 'Diamond', 'Gold', 'Quartz', 'B'),
                (2, 'What is the speed of light?', '300,000 km/s', '150,000 km/s', '450,000 km/s', '200,000 km/s', 'A'),
                (2, 'What is H2O commonly known as?', 'Oxygen', 'Water', 'Hydrogen', 'Salt', 'B'),
                -- Math (Category 3)
                (3, 'What is 5 + 7?', '10', '11', '12', '13', 'C'),
                (3, 'What is the square root of 64?', '6', '7', '8', '9', 'C'),
                (3, 'Solve: 9 x 9', '80', '81', '90', '91', 'B'),
                (3, 'What is the value of pi (approx)?', '3.12', '3.14', '3.16', '3.18', 'B'),
                (3, 'Which is the first prime number?', '1', '2', '3', '5', 'B'),
                -- History (Category 4)
                (4, 'What year did World War II end?', '1944', '1945', '1946', '1947', 'B'),
                (4, 'Who was the first President of the United States?', 'Jefferson', 'Lincoln', 'Washington', 'Adams', 'C'),
                (4, 'Where was Napoleon Bonaparte born?', 'France', 'Corsica', 'Italy', 'Spain', 'B'),
                (4, 'Who was the British Prime Minister during WWII?', 'Churchill', 'Chamberlain', 'Eden', 'Macmillan', 'A'),
                (4, 'What ancient civilization built the pyramids?', 'Romans', 'Greeks', 'Egyptians', 'Persians', 'C')
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