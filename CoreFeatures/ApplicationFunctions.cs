using System;
using System.Data;
using Npgsql;


namespace QuizApp
{
    public static class ApplicationFunctions
    {
        
        public static void PlayQuiz(int userid)
        {
            Console.Clear();
            Console.WriteLine("=== Choose a Category ===");

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT id, name FROM categories", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}. {reader.GetString(1)}");
                    }
                }

                Console.Write("\nSelect a category: ");
                int categoryId = int.Parse(Console.ReadLine());

                StartQuiz(userid, categoryId);
            }
        }

        public static void StartQuiz(int userId, int categoryId)
        {
            Console.Clear();
            Console.WriteLine("=== Quiz Time ===\n");

            int score = 0;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "SELECT question, option_a, option_b, option_c, option_d, correct_option FROM questions WHERE category_id = @categoryId LIMIT 15",
                    connection);
                command.Parameters.AddWithValue("categoryId", categoryId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                        Console.WriteLine($"A. {reader.GetString(1)}");
                        Console.WriteLine($"B. {reader.GetString(2)}");
                        Console.WriteLine($"C. {reader.GetString(3)}");
                        Console.WriteLine($"D. {reader.GetString(4)}");

                        Console.Write("\nYour answer: ");
                        string answer = Console.ReadLine().ToUpper();

                        if (answer == reader.GetString(5).ToUpper())
                        {
                            score++;
                        }
                    }
                }
            }

            UpdateBestScore(userId, score);

            Console.WriteLine($"\nYou scored {score} points!");

            while (true)
            {
                Console.WriteLine("\nWhat do you want to do next?");
                Console.WriteLine("1. Play another category");
                Console.WriteLine("2. Return to the user menu");
                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    PlayQuiz(userId);
                    return;
                }
                else if (choice == "2")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please select a valid option.");
                }
            }
        }

        public static void UpdateBestScore(int userId, int score)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "UPDATE users SET best_score = GREATEST(best_score, @score) WHERE id = @userId",
                    connection);
                command.Parameters.AddWithValue("score", score);
                command.Parameters.AddWithValue("userId", userId);

                command.ExecuteNonQuery();
            }
        }

        public static void FunctionName4()
        {
            // Innehåll
        }
    }
}
