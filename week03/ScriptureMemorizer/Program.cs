using System;

class Program
{
    static void Main(string[] args)
    {
        // Example: Proverbs 3:5-6
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 random words at a time
        }
    }
}
/* 
CREATIVITY & EXCEEDING REQUIREMENTS:
1. Implemented logic to ensure only visible words are selected for hiding (Stretch Challenge).
2. Designed the HideRandomWords method to gracefully handle the end of the scripture 
   without crashing if fewer words remain than the requested amount to hide.
*/
