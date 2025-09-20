using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string w in wordArray)
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rnd = new Random();
        int hiddenCount = 0;

      
        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = rnd.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + " ";
        foreach (Word w in _words)
        {
            display += w.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }
}
