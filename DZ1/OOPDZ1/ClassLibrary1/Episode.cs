using System;
using System.Collections.Generic;
using System.Text;
namespace ClassLibrary1
{
    public class Episode
    {
        int viewerCount = 0;
        double scoreSum = 0;
        double maxScore = 0.0;
        Random randomNum = new Random();

        public Episode()
        {
        }
        public Episode(int viewerCount, double scoreSum, double maxScore)
        {
            this.viewerCount = viewerCount;
            this.scoreSum = scoreSum;
            this.maxScore = maxScore;
        }

        public void AddView(double score)
        {
            viewerCount++;
            scoreSum = scoreSum + score;
            if (score > maxScore)
                maxScore = score;
        }

        public double GenerateRandomScore()
        {
            return randomNum.NextDouble() * 10.0;
        }

        public double GetMaxScore()
        {
            return Math.Round(maxScore, 5);
        }

        public double GetAverageScore()
        {
            return scoreSum / (double)viewerCount;
        }

        public int GetViewerCount()
        {
            return viewerCount;
        }

    }
}