using System; 

namespace ApplicationClass {

class Program {
    // .gitignore filen finns, men mer behövs kompletteras för fullfungerande.
    List<string> QuizQuestions = new List<string>(); // Lista för att spara Frågor? 
    static void Main(string[] args) {

       bool StillGoing = true; 
       int MenuChoice; 

       while (StillGoing) {

        ShowMenu.DisplayMenuName1(); // Menu val, (Finns i ShowMenu)

        string UserInput = Console.ReadLine()!.ToLower();

        if (int.TryParse(UserInput, out MenuChoice)) { // Error handling och Konvert

            switch(MenuChoice) {

                case 1:

                ApplicationFunctions.FunctionName1(); // Metod 1 för innehåll
                break;

                case 2:
                ApplicationFunctions.FunctionName2(); // Metod 2 för innehåll

                break;
                ApplicationFunctions.FunctionName3(); // Metod 3 för innehåll

                case 3: 
                ApplicationFunctions.FunctionName4();// Metod 4 för innehåll
                break;

                case 4:
                Console.WriteLine("Exiting...");
                StillGoing = false;
                break;

                default: 
                Console.WriteLine("Ensure choosing the correct number!");
                break; 


            }
        }
        else {
            Console.WriteLine("Ensure choosing from 1-4!");
        }
       }
    }
  }
}