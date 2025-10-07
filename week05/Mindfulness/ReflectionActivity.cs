using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class ReflectionActivity : Activity
    {
        private static readonly List<string> _prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> _questions = new()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        { }

        protected override void RunActivity()
        {
            Random rnd = new();
            string prompt = _prompts[rnd.Next(_prompts.Count)];
            Console.WriteLine("Prompt:");
            Console.WriteLine(prompt + "\n");

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            int count = 0;

            while (DateTime.Now < end)
            {
                string question = _questions[rnd.Next(_questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(5);
                count++;
            }

            _resultSummary = $"Questions considered: {count}";
        }
    }
}
