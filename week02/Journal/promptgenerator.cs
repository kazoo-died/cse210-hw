using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>();
    private Random _random = new Random();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What made me smile today?");
        _prompts.Add("What am I grateful for today?");
        _prompts.Add("What is a new thing I learned today?");
        _prompts.Add("How did I take care of myself today?");
        _prompts.Add("What challenged me today?");
        _prompts.Add("What is something I want to remember about today?");
        _prompts.Add("What is a goal I have for tomorrow?");
        _prompts.Add("What is something kind I did for someone else today?");
        _prompts.Add("What is something kind someone did for me today?");
        _prompts.Add("What is a moment from today that I want to savor?");
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "";
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
