using Npgsql;


namespace QuizApp
{
    public static class SignManager // Klass som hanterar inlogg och registrering
    {
        // Till Lorik, ändra connection stringen till databas.
        private static readonly string connectionString = "Host=localhost;Username=myuser;Password=mypassword;Database=quizapp";

        public static void SignUp()
        {
            Console.Clear();

            Console.WriteLine(@"
   _____ _               _    _       
  / ____(_)             | |  | |      
 | (___  _  __ _ _ __   | |  | |_ __  
  \___ \| |/ _` | '_ \  | |  | | '_ \ 
  ____) | | (_| | | | | | |__| | |_) |
 |_____/|_|\__, |_| |_|  \____/| .__/ 
            __/ |              | |    
           |___/               |_|    
            ");

            string username;

            while (true)
            {
                Console.Write("Enter Username (no spaces): ");
                username = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(username) || username.Contains(" "))
                {
                    Console.WriteLine("Invalid username. It must not be empty or contain spaces.");
                    continue;
                }
                if (username.Length < 3)
                {
                    Console.WriteLine("Username must be at least 3 characters long.");
                    continue;
                }
                break;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new NpgsqlCommand("INSERT INTO users (username) VALUES (@username)", connection);
                    command.Parameters.AddWithValue("username", username);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Sign Up Successful! Press Enter to continue.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.ReadLine();
                }
            }
        }

        public static void SignIn()
        {
            Console.Clear();

            Console.WriteLine(@"
   _____ _               _____       
  / ____(_)             |_   _|      
 | (___  _  __ _ _ __     | |  _ __  
  \___ \| |/ _` | '_ \    | | | '_ \ 
  ____) | | (_| | | | |  _| |_| | | |
 |_____/|_|\__, |_| |_| |_____|_| |_|
            __/ |                    
           |___/                     
            ");

            string username;

            while (true)
            {
                Console.Write("Enter Username: ");
                username = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username cannot be empty. Try again.");
                    continue;
                }
                break;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new NpgsqlCommand("SELECT id, best_score FROM users WHERE username = @username AND password = @password", connection);
                    command.Parameters.AddWithValue("username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            int bestScore = reader.GetInt32(1);

                            ShowUserMenu(userId, username, bestScore);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid credentials. Press Enter to try again.");
                            Console.ReadLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn error occurred: {ex.Message}");
                }
            }
        }
         static void ShowUserMenu(int userId, string username, int bestScore)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine(@"
                                                                     
 __ __  ______ ___________    _____   ____   ____  __ __ 
|  |  \/  ___// __ \_  __ \  /     \_/ __ \ /    \|  |  \
|  |  /\___ \\  ___/|  | \/ |  Y Y  \  ___/|   |  \  |  /
|____//____  >\___  >__|    |__|_|  /\___  >___|  /____/ 
           \/     \/              \/     \/     \/       
            ");

            Console.WriteLine($"Welcome, {username}! Your Best Score: {bestScore}");
            Console.WriteLine("\n1. Play Quiz");
            Console.WriteLine("2. Edit Profile");
            Console.WriteLine("3. Log Out");

            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayQuiz(userId);
                    break;
                case "2":
                    EditProfile(userId);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }  
    }
}
