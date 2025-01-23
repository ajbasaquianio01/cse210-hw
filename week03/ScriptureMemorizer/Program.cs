using System;

class Program
{
    static void Main()
    {
        var reference = new ScriptureReference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        var scripture = new Scripture(reference, text);
        var random = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program will now end.");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(random);
        }
    }
}