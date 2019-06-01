namespace _01.EvenLines
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class EvenLines
    {
        public static void Main()
        {
            string directoryName = "files";
            string inputFileName = "text.txt";

            using (StreamReader reader = new StreamReader(Path.Combine(directoryName, inputFileName)))
            {
                string line = string.Empty;
                int counter = default;

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 == 0)
                    {
                        string replacedCharsLine = Regex.Replace(line, @"[-,.!?]", @"@");
                        string[] words = replacedCharsLine.Split();
                        string[] result = words
                            .Reverse()
                            .ToArray();
                        Console.WriteLine(string.Join(" ", result));
                    }

                    
                    counter++;
                }                
            }
        }
    }
}
