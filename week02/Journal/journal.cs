using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string Separator = "~|~";

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---\n");
        foreach (var e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                // Escape newlines so each entry remains on a single file line.
                string safeResponse = e.Response?.Replace("\r\n", "\\n").Replace("\n", "\\n") ?? "";
                string safePrompt = e.Prompt ?? "";
                string safeDate = e.Date ?? "";

                outputFile.WriteLine($"{safeDate}{Separator}{safePrompt}{Separator}{safeResponse}");
            }
        }

        Console.WriteLine($"Journal saved to {filename}.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File not found: {filename}");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);

            string date = parts.Length > 0 ? parts[0] : "";
            string prompt = parts.Length > 1 ? parts[1] : "";
            string responseEscaped = parts.Length > 2 ? parts[2] : "";

            // Restore newlines that were escaped when saving.
            string response = responseEscaped.Replace("\\n", Environment.NewLine);

            _entries.Add(new Entry(date, prompt, response));
        }

        Console.WriteLine($"Journal loaded from {filename}.");
    }
}
