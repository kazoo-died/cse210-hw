using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public string Date => _date;
    public string Prompt => _prompt;
    public string Response => _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine("Response:");
        Console.WriteLine(_response);
        Console.WriteLine(new string('-', 30));
    }
}

