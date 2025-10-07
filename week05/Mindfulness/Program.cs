using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program\n");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Choose an option (1-4): ");
                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        new BreathingActivity().Start();
                        break;
                    case "2":
                        new ReflectionActivity().Start();
                        break;
                    case "3":
                        new ListingActivity().Start();
                        break;
                    case "4":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4.");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }

            Console.WriteLine("Thanks for using the Mindfulness Program. Goodbye!");
        }
    }
}
