using Npgsql;
<<<<<<< Updated upstream
namespace QuizApp
 {

    public class ApplicationFunctions { 

        public static void PlayQuiz(int userid) 
=======

namespace QuizApp
{
    public static class ApplicationFunctions
    {
        private static readonly string ConnectionString = "Host=localhost;Username=postgres;Password=Mo20042004;Database=Quizapp";

        public static void PlayQuiz(User user)
>>>>>>> Stashed changes
        {
             Console.Clear();
        Console.WriteLine("=== Choose a Category ===");

<<<<<<< Updated upstream
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT id, name FROM categories", connection);

            using (var reader = command.ExecuteReader())
=======
            using (var connection = new NpgsqlConnection(ConnectionString))
>>>>>>> Stashed changes
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}. {reader.GetString(1)}");
                }
<<<<<<< Updated upstream
=======

                Console.Write("\nSelect a category: ");
                int categoryId = int.Parse(Console.ReadLine());

                // Skickar user-objektet till StartQuiz
                StartQuiz(user, categoryId);
>>>>>>> Stashed changes
            }

            Console.Write("\nSelect a category: ");
            int categoryId = int.Parse(Console.ReadLine());

            StartQuiz(userId, categoryId);
        }
<<<<<<< Updated upstream
        }
        public static void FunctionName2() {

            // Innehåll

        }
        public static void FunctionName3() {

            // Innehåll

        }
         public static void FunctionName4() {

            // Innehåll

        }

=======

        public static void StartQuiz(User user, int categoryId)
        {
            Console.Clear();
            Console.WriteLine("=== Quiz Time ===\n");

            int score = 0;

            using (var connection = new NpgsqlConnection(ConnectionString))
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

            // Visa slutpoängen
            Console.WriteLine($"\nYou scored {score} points! Your best score is {user.BestScore}.");

            while (true)
            {
                Console.WriteLine("\nWhat do you want to do next?");
                Console.WriteLine("1. Play another category");
                Console.WriteLine("2. Return to the user menu");
                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    PlayQuiz(user);  // Skicka tillbaka användaren till quizet
                    return;
                }
                else if (choice == "2")
                {
                    return;  // Avsluta quizet och gå tillbaka till användarmenyn
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please select a valid option.");
                }
            }
        }
>>>>>>> Stashed changes
    }
}