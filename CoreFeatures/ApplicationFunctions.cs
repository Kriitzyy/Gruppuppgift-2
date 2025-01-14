using System;
using System.Data;
using Npgsql;
using QuizApp;

public static class ApplicationFunctions
{
    // Metod som visar tillgängliga kategorier för användaren att välja.
    public static void PlayQuiz(int userId)
    {
        Console.Clear();
        Console.WriteLine("=== Categories ===");

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

            int categoryId = -1;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("\nSelect a category: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out categoryId))
                {
                    var checkCommand = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM categories WHERE id = @categoryId",
                        connection
                    );
                    checkCommand.Parameters.AddWithValue("@categoryId", categoryId);

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. The selected category does not exist.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            StartQuiz(userId, categoryId);
        }
    }

    // Metod som startar quizet.
    public static void StartQuiz(int userId, int categoryId)
    {
        Console.Clear();
        Console.WriteLine("=== Quiz Time ===\n");

        int score = 0;

        using (var connection = DataBaseConnection.GetConnection())
        {
            connection.Open();
            var command = new NpgsqlCommand(
                "SELECT question, option_a, option_b, option_c, option_d, correct_option FROM questions WHERE category_id = @categoryId LIMIT 5",
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

                    string answer = "";
                    bool isValid = false;

                    while (!isValid)
                    {
                        Console.Write("\nYour answer: ");
                        answer = Console.ReadLine().ToUpper();

                        if (answer != "A" && answer != "B" && answer != "C" && answer != "D")
                        {
                            Console.WriteLine("Invalid input! Please enter A, B, C, or D.");
                        }
                        else
                        {
                            isValid = true;
                        }
                    }

                    if (answer == reader.GetString(5).ToUpper())
                    {
                        score++;
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong!");
                    }
                    Thread.Sleep(1700); // Vänta så användaren ser resultatet
                    Console.Clear(); // Rensa konsolen
                }
            }

            var updateCommand = new NpgsqlCommand(
                @"UPDATE users 
                  SET best_score = GREATEST(best_score, best_score + @score)
                  WHERE id = @userId;
                  UPDATE scores
                  SET score = score + @score
                  WHERE user_id = @userId;",
                connection
            );
            updateCommand.Parameters.AddWithValue("score", score);
            updateCommand.Parameters.AddWithValue("userId", userId);
            updateCommand.ExecuteNonQuery();
        }

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

    // Metod som låter användaren redigera sitt användarnamn.
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
