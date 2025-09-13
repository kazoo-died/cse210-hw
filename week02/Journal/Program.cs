

/*
  Journal Program - Program.cs

  Notes on exceeding requirements:
  - Implemented saving/loading that preserves multi-line responses by escaping newlines
    on save and restoring them on load. This keeps entries with line breaks but still
    saves each entry as a single file line (simplifies parsing).*/





using System;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g. journal.txt): ");
                    string saveFile = Console.ReadLine();
                    try { journal.SaveToFile(saveFile); }
                    catch (Exception ex) { Console.WriteLine($"Error saving file: {ex.Message}"); }
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g. journal.txt): ");
                    string loadFile = Console.ReadLine();
                    try { journal.LoadFromFile(loadFile); }
                    catch (Exception ex) { Console.WriteLine($"Error loading file: {ex.Message}"); }
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1-5.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        string prompt = prompts.GetRandomPrompt();
        Console.WriteLine("\n--- New Entry ---");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Type your response. Press a blank line (Enter on an empty line) to finish.");

        var sb = new StringBuilder();
        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;

            if (sb.Length > 0)
                sb.AppendLine();

            sb.Append(line);
        }

        string response = sb.ToString();
        string dateText = DateTime.Now.ToShortDateString();

        var entry = new Entry(dateText, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added to journal.");
    }
}
