using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private static readonly List<string> _prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void RunActivity()
        {
            Random rnd = new();
            string prompt = _prompts[rnd.Next(_prompts.Count)];
            Console.WriteLine("Prompt:");
            Console.WriteLine(prompt + "\n");

            Console.WriteLine("You will have 5 seconds to think...");
            ShowCountDown(5);

            Console.WriteLine("Start listing items. Press Enter after each.");
            List<string> items = new();

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            while (DateTime.Now < end)
            {
                Console.Write("> ");
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                        items.Add(input.Trim());
                }
                else Thread.Sleep(100);
            }

            Console.WriteLine($"You listed {items.Count} items:");
            int i = 1;
            foreach (var item in items)
                Console.WriteLine($"{i++}. {item}");

            _resultSummary = $"Items listed: {items.Count}";
        }
    }
}
