namespace _03.WordCount
{
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            string fileDirectory = "files";
            string wordsFileName = "words.txt";
            string[] wordsArray = null;

            using (StreamReader wordReader = new StreamReader(Path.Combine(fileDirectory, wordsFileName)))
            {
                wordsArray = wordReader
                    .ReadLine()
                    .Split();
            }

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var word in wordsArray)
            {
                words.Add(word.ToLower(), default);
            }

            string textFileName = "text.txt";

            using (StreamReader textReader = new StreamReader(Path.Combine(fileDirectory, textFileName)))
            {
                string line = string.Empty;

                while ((line = textReader.ReadLine()) != null)
                {
                    string[] newElements = line.ToLower().Split();

                    foreach (var element in newElements)
                    {
                        string word = Regex
                            .Match(element, @"\w+")
                            .ToString();

                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                    }
                }                
            }

            string outputFileName = "Output.txt";
            words = words
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            using (StreamWriter writer = new StreamWriter(Path.Combine(fileDirectory, outputFileName)))
            {
                foreach (var word in words)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
