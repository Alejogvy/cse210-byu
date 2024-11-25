using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Count == 0) return;

        var random = new Random();
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public override string ToString()
    {
        return $"{Reference}\n\n{string.Join(' ', _words)}";
    }
}
