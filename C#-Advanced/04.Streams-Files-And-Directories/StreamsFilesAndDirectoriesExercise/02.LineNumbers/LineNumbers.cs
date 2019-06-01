namespace _02.LineNumbers
{
    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        public static void Main()
        {
            string directoryName = "files";
            string inputFileName = "text.txt";

            string[] lines = File.ReadAllLines(Path.Combine(directoryName, inputFileName));

            for (int i = 0; i < lines.Length; i++)
            {
                MatchCollection letters = Regex.Matches(lines[i], @"[A-Za-z]");
                MatchCollection punctuationMarks = Regex.Matches(lines[i], @"[^A-Za-z\s]");

                lines[i] = $"Line {i + 1}: {lines[i]} ({letters.Count})({punctuationMarks.Count})";
            }

            string outputFileName = "output.txt";
            File.WriteAllLines(Path.Combine(directoryName, outputFileName), lines);
        }
    }
}
