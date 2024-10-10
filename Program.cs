﻿
using System;

class HighScore
{
    List<Tuple<string, int>> scores = new List<Tuple<string, int>>();
    public void AddScore(string initials, int score)
    {
        scores.Add(new Tuple<string, int>(initials, score));
        scores.Sort((a, b) => b.Item2.CompareTo(a.Item2)); // Sort in descending order
    }
    public void ShowScores()
    {
        if (scores.Count == 0)
        {
            Console.WriteLine("No scores yet.");
        }
        else
        {
            Console.WriteLine("High Scores:");
            foreach (var score in scores)
            {
                Console.WriteLine($"{score.Item1}: {score.Item2}");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        HighScore board = new HighScore();
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Add Score\n2. View Scores\n3. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter initials: ");
                    string initials = Console.ReadLine();
                    Console.Write("Enter score: ");
                    int score = int.Parse(Console.ReadLine());
                    board.AddScore(initials, score);
                    break;
                case "2":
                    board.ShowScores();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}