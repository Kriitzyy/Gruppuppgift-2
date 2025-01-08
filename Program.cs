using System;
using System.Data;
using Npgsql;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            LoadQuizapp.SetUpDatabase();
            bool StillGoing = true;
            int MenuChoice;
            
            while (StillGoing)
            {
                Console.Clear();
                ShowMenu.DisplayMenu(); //Quiz-app logo

                string userinput = Console.ReadLine();

                if (int.TryParse(userinput, out MenuChoice))
                { // Error handling och Konvert
                    switch (MenuChoice)
                    {
                        case 1:
                            SignManager.SignUp(); // Metod 1 för innehåll
                            break;

                        case 2:
                            SignManager.SignIn(); // Metod 2 för innehåll
                            break;

                        case 3:
                            Console.WriteLine("Exiting...");
                            StillGoing = false;
                            break;

                        default:
                            Console.WriteLine("Ensure choosing the correct number!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ensure choosing from 1-3!");
                }
            }
        }
    }
}
