using System;
using System.IO;
using System.Threading;

namespace MindfulnessApp
{
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;
        protected string _resultSummary = string.Empty;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Start()
        {
            Console.Clear();
            DisplayStartMessage();
            PromptAndSetDuration();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);

            RunActivity();

            DisplayEndMessage();
            LogActivity();

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void DisplayStartMessage()
        {
            Console.WriteLine($"== {_name} ==\n");
            Console.WriteLine(_description + "\n");
        }

        private void PromptAndSetDuration()
        {
            while (true)
            {
                Console.Write("Enter duration in seconds for this activity: ");
                string input = Console.ReadLine().Trim();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    _durationSeconds = seconds;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a positive integer.");
                }
            }
        }

        protected int DurationSeconds => _durationSeconds;

        private void DisplayEndMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Great job!");
            Console.WriteLine($"You have completed the {_name} for {_durationSeconds} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            char[] seq = { '|', '/', '-', '\\' };
            int idx = 0;
            DateTime end = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < end)
            {
                Console.Write(seq[idx]);
                Thread.Sleep(250);
                Console.Write('\r');
                idx = (idx + 1) % seq.Length;
            }
            Console.Write(" ");
            Console.WriteLine();
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
                Console.Write('\r');
            }
            Console.WriteLine();
        }

        private void LogActivity()
        {
            try
            {
                string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {_name} | {_durationSeconds} sec";
                if (!string.IsNullOrWhiteSpace(_resultSummary))
                    logLine += " | " + _resultSummary;
                File.AppendAllText("mindfulness_log.txt", logLine + Environment.NewLine);
            }
            catch { }
        }

        protected abstract void RunActivity();
    }
}
