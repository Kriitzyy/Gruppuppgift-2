using System; 
using QuizApp; // Tillgång till inehållet i ApplicationClass

public class Question
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string CorrectOption { get; set; }

    public Question(int id, string questionText, string optionA, string optionB, string optionC, string optionD, string correctOption)
    {
        Id = id;
        QuestionText = questionText;
        OptionA = optionA;
        OptionB = optionB;
        OptionC = optionC;
        OptionD = optionD;
        CorrectOption = correctOption;
    }
}
