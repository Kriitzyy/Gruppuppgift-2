using System;
using QuizApp;

public static class ShowMenu
{
    // Metod för att visa meny-alternativ
    public static void DisplayMenu()
    {
        ShowHomePage();
        Console.WriteLine("\n[1] - Sign up");
        Console.WriteLine("[2] - Sign in");
        Console.WriteLine("[3] - Exit");
        Console.Write("\nSelect an option: ");
    }

    // Justerar textens position till mitten
    private static void Center(string message)
    {
        int screenWidth = Console.WindowWidth;
        int stringWidth = message.Length;
        int spaces = (screenWidth / 2) + (stringWidth / 2);
        Console.WriteLine(message.PadLeft(spaces));
    }

    // Visar Quiz-App-logga och introduktionstext
    public static void ShowHomePage()
    {
        Console.WriteLine(@"   
                                                    ============================================================================================  
                                                    =                                                                                          =
                                                    =    ████████▄   ███    █▄   ▄█   ▄███████▄          ▄████████    ▄███████▄    ▄███████▄   =
                                                    =    ███    ███  ███    ███ ███  ██▀     ▄██        ███    ███   ███    ███   ███    ███   =
                                                    =    ███    ███  ███    ███ ███▌       ▄███▀        ███    ███   ███    ███   ███    ███   =
                                                    =    ███    ███  ███    ███ ███▌  ▀█▀▄███▀▄▄        ███    ███   ███    ███   ███    ███   =
                                                    =    ███    ███  ███    ███ ███▌   ▄███▀   ▀      ▀███████████ ▀█████████▀  ▀█████████▀    =
                                                    =    ███    ███  ███    ███ ███  ▄███▀              ███    ███   ███          ███          =
                                                    =    ███  ▀ ███  ███    ███ ███  ███▄     ▄█        ███    ███   ███          ███          =
                                                    =    ▀██████▀▄█ ████████▀  █▀    ▀████████▀        ███    █▀   ▄████▀       ▄████▀         =
                                                    =                                                                                          =
                                                    ============================================================================================                               
   ");
        Center("🎮 WELCOME TO THE QUIZ APP 🎮\n");
        Center("Think you're the ultimate brainiac? Or maybe you’re just here to prove you're smarter than your friends?");
        Center("Either way, welcome to the *Quiz App*—where knowledge is your weapon, and trivia mastery is your ultimate flex! 🧠⚔️");
        Center("💡 **Ready to show the world who's boss? Let’s go!**");
    }
}
