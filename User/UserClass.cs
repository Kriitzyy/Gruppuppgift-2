using System;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int BestScore { get; set; }

    public User(int id, string username, int bestScore = 0)
    {
        Id = id;
        Username = username;
        BestScore = bestScore;
    }
}