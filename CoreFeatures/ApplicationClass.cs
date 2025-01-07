using System; 
using QuizApp; // Tillgång till inehållet i ApplicationClass

public class QuizClass
{
    public string Question { get; set; } // Fråga egenskap
    public string OptionA { get; set; } // Alternativ A
    public string OptionB { get; set; } // Alternativ B
    public string OptionC { get; set; } // Alternativ C
    public string OptionD { get; set; } // Alternativ D
    public string CorrectOption { get; set; } // Rätt svar

    public QuizClass(string question, string optionA, string optionB, string optionC, string optionD, string correctOption)
    {
        Question = question;
        OptionA = optionA;
        OptionB = optionB;
        OptionC = optionC;
        OptionD = optionD;
        CorrectOption = correctOption;
    }
}