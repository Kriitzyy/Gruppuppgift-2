using System; 
using QuizApp;

public class Scores
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ScoreValue { get; set; }

    // Foreign key relation to User
    public User User { get; set; }

    public Scores(int id, int userId, int scoreValue)
    {
        Id = id;
        UserId = userId;
        ScoreValue = scoreValue;
    }
}