using System;

namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        protected override void RunActivity()
        {
            int totalSeconds = DurationSeconds;
            DateTime endTime = DateTime.Now.AddSeconds(totalSeconds);
            int breaths = 0;

            while (DateTime.Now < endTime)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(4);
                if (DateTime.Now >= endTime) break;

                Console.WriteLine("Breathe out...");
                ShowCountDown(6);
                breaths++;
            }

            _resultSummary = $"Breaths completed: {breaths}";
        }
    }
}
