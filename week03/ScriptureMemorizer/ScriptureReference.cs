using System;

public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public string VerseRange { get; private set; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseRange = verse.ToString();
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        VerseRange = $"{startVerse}-{endVerse}";
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{VerseRange}";
    }
}