using System;
using System.Collections.Generic;
using System.IO;

namespace ScoreGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "scores.txt";
            List<double> scores = new List<double>();
            double currentScore = 0.0;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (double.TryParse(line, out double score))
                    {
                        scores.Add(score);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Do you play? (y/n)");
                string response = Console.ReadLine();

                if (response.ToLower() == "y")
                {
                    currentScore += 20.0;
                    Console.WriteLine(currentScore);
                }
                else
                {
                    break;
                }
            }

            scores.Add(currentScore);

            double averageScore = 0.0;
            if (scores.Count > 0)
            {
                double sum = 0.0;
                foreach (double score in scores)
                {
                    sum += score;
                }
                averageScore = sum / scores.Count;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (double score in scores)
                {
                    writer.WriteLine(score);
                }
            }

            Console.WriteLine($"Your average score: {averageScore}");
            Console.WriteLine($"Your current score: {currentScore}");
        }
    }
}
