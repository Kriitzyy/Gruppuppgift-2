using System;
using System.Data;
using Npgsql;
using QuizApp;

    public static class ApplicationFunctions
    {
        public static void PlayQuiz(int userid)
        {
            Console.Clear();
            Console.WriteLine("=== Choose a Category ===");

            using (var connection = DataBaseConnection.GetConnection())
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

                while (!int.TryParse(Console.ReadLine(), out categoryId) || categoryId <= 0) // om användaren matat in fel
                {
                    Console.WriteLine("Invalid input. Please enter a valid category number.");
                    Console.Write("\nSelect a category: ");
                }

                StartQuiz(userid, categoryId);
            }
        }

        public static void StartQuiz(int userId, int categoryId)
        {
            Console.Clear();
            Console.WriteLine("=== Quiz Time ===\n");

            int score = 0;

            using (var connection = DataBaseConnection.GetConnection())
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "SELECT question, option_a, option_b, option_c, option_d, correct_option FROM questions WHERE category_id = @categoryId LIMIT 15",
                    connection
                );
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
                        
                        if (answer != "A" && answer != "B" && answer != "C" && answer != "D")
                        {
                            Console.WriteLine("Invalid input! Please enter A, B, C, or D.");
                            continue; 
                        }

                        if (answer == reader.GetString(5).ToUpper())
                        {
                            score++;
                        }

                        if (score >= 15) {

                            score = 15;
                            break; 
                            // fortsätter inte med Quizappen, bara om användaren når 15 poäng
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
            using (var connection = DataBaseConnection.GetConnection())
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "UPDATE users SET best_score = GREATEST(best_score, @score) WHERE id = @userId",
                    connection
                );
                command.Parameters.AddWithValue("score", score);
                command.Parameters.AddWithValue("userId", userId);

                command.ExecuteNonQuery();
            }
        }

        public static void EditProfile(int userId)
        {
            Console.Clear();
            Console.WriteLine("=== Edit Username ===");

            Console.Write("Enter new username: ");
            string newUsername = Console.ReadLine();

            using (var connection = DataBaseConnection.GetConnection())
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "UPDATE users SET username = @username WHERE id = @userId",
                    connection
                );
                command.Parameters.AddWithValue("username", newUsername);
                command.Parameters.AddWithValue("userId", userId);

                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Username updated successfully! Press Enter to continue.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.ReadLine();
            }
        }
    }

