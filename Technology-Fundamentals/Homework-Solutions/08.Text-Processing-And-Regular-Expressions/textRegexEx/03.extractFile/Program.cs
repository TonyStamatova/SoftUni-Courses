using System;
using System.Text.RegularExpressions;

namespace _03.extractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string regexFileName = @"(?<=\\)[^\\.]+(?=\.)";
            string regexExtension = @"(?<=\.).+$";

            string fileName = Regex.Match(path, regexFileName).ToString();
            string fileExtension = Regex.Match(path, regexExtension).ToString();

            Console.WriteLine($"File name: {fileName}" + Environment.NewLine + $"File extension: {fileExtension}");
        }
    }
}
