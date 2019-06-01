namespace _03.WordCount
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            string directory = "files";

            Dictionary<string, int> words = ReadWords(directory);

            CountWordsOccurrences(directory, words);

            ExportToActualResultFile(directory, words);

            string[] orderedResult = OrderWordsToCompare(words);

            bool resultsAreEqual = CompareResults(directory, orderedResult);

            Console.WriteLine(resultsAreEqual);
        }

        private static bool CompareResults(string directory, string[] orderedResult)
        {
            string result = string.Join(Environment.NewLine, orderedResult);
            string expectedResult = "expectedResult.txt";

            bool resultsAreEqual = File.Equals(
                result,
                File.ReadAllText(Path.Combine(directory, expectedResult)));
            return resultsAreEqual;
        }

        private static string[] OrderWordsToCompare(Dictionary<string, int> words)
        {
            string[] orderedResult = new string[words.Count];

            PrepareWordsForExport(
                words
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value),
                orderedResult);
            return orderedResult;
        }

        private static void ExportToActualResultFile(string directory, Dictionary<string, int> words)
        {
            string[] outputText = new string[words.Count];

            PrepareWordsForExport(words, outputText);

            string outputFile = "actualResult.txt";
            File.WriteAllLines(Path.Combine(directory, outputFile), outputText);
        }

        private static void CountWordsOccurrences(string directory, Dictionary<string, int> words)
        {
            string textToMatch = "text.txt";
            string wholeText = File.ReadAllText(Path.Combine(directory, textToMatch));
            MatchCollection textWords = Regex.Matches(wholeText, @"\w+");

            foreach (var word in textWords)
            {
                string wordToCheck = word
                    .ToString()
                    .ToLower();

                if (words.ContainsKey(wordToCheck))
                {
                    words[wordToCheck]++;
                }
            }
        }

        private static Dictionary<string, int> ReadWords(string directory)
        {
            string inputFile = "words.txt";
            string[] words = File.ReadAllLines(Path.Combine(directory, inputFile));
            Dictionary<string, int> wordsWithCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsWithCount.Add(word.ToLower(), default);
            }

            return wordsWithCount;
        }

        private static void PrepareWordsForExport(Dictionary<string, int> words, string[] outputText)
        {
            int counter = default;

            foreach (var kvp in words)
            {
                outputText[counter] = $"{kvp.Key} - {kvp.Value}";
                counter++;
            }
        }
    }
}
