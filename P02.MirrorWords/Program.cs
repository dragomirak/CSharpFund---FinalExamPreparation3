using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace P02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<string, string> wordsMap = new Dictionary<string, string>();

            string pattern = @"(@|#)(?<FirstWord>[A-Za-z]{3,})\1(@|#)(?<SecondWord>[A-Za-z]{3,})\1";

            if (Regex.Matches(text, pattern).Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            else
            {
                Console.WriteLine($"{Regex.Matches(text, pattern).Count} word pairs found!");
                foreach (Match match in Regex.Matches(text, pattern))
                {
                    string firstWordValue = match.Groups["FirstWord"].Value;
                    string secondWordValue = match.Groups["SecondWord"].Value;
                    string reversedWord = new string(secondWordValue.Reverse().ToArray());
                    if (firstWordValue == reversedWord)
                    {
                        wordsMap.Add(firstWordValue, secondWordValue);
                    }
                }
            }

            if (wordsMap.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                int currentIteration = 0;
                Console.WriteLine("The mirror words are:");
                foreach (KeyValuePair<string, string> kvp in wordsMap)
                {
                    currentIteration++;
                    Console.Write($"{kvp.Key} <=> {kvp.Value}");
                    if (currentIteration < wordsMap.Count)
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
    }
}