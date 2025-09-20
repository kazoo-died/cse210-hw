using System;

class Program
{
    static void Main(string[] args)
    {
       
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference,
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths.");

       
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

           
            scripture.HideRandomWords(3);
        }
    }
}

/* Key Improvements Made:
 The HideRandomWords method ensures already hidden words are not re-hidden,
   making the hiding process smoother and more realistic.
*/


