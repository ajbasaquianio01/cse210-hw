using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    private List<Word> Words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(Random random)
    {
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Count > 0)
        {
            int wordsToHide = Math.Min(3, visibleWords.Count); // Hide up to 3 words at a time.
            for (int i = 0; i < wordsToHide; i++)
            {
                var wordToHide = visibleWords[random.Next(visibleWords.Count)];
                wordToHide.Hide();
                visibleWords.Remove(wordToHide);
            }
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public override string ToString()
    {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }
}