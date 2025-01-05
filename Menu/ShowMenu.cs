// Här sparas Menyer då vi kanske kommer ha många olika/upprepande menyer
// Och så att det blir strukturerat
using System;

namespace QuizApp
{
    public static class ShowMenu
    {
        public static void DisplayMenu() //Metod för att visa meny-alternativ.
        {
            Console.WriteLine("\n[1] - Sign up");
            Console.WriteLine("[2] - Sign in");
            Console.WriteLine("[3] - Exit");

            Console.Write("\nSelect an option: ");
        }
        static void center(string message) //Metod för att justera 'Quiz-App' logo position.
    {
        int screenWidth = Console.WindowWidth;
        int stringWidth = message.Length;
        int spaces = (screenWidth / 2) + (stringWidth / 2);
        Console.WriteLine(message.PadLeft(spaces));
    }
        public static void ShowHomePage() { //Metod för att visa Quiz-App logo och text.
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
        center("🎮 WELCOME TO THE QUIZ APP 🎮\n");
        center("Think you're the ultimate brainiac? Or maybe you’re just here to prove you're smarter than your friends?");
        center("Either way, welcome to the *Quiz App*—where knowledge is your weapon, and trivia mastery is your ultimate flex! 🧠⚔️");
        center("💡 **Ready to show the world who's boss? Let’s go!**");
        }

    }
}
