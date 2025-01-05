using Npgsql;
namespace QuizApp
 {

    public class ApplicationFunctions { 

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

            StartQuiz(userId, categoryId);
        }
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

    }
}