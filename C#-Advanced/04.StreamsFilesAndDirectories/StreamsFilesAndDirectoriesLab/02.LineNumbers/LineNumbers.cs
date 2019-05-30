namespace _02.LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            string fileDir = "files";
            string fileName = "input.txt";
            string filePath = Path.Combine(fileDir, fileName);

            using (var reader = new StreamReader(filePath))
            {
                int count = 1;
                string line = reader.ReadLine();
                string outputFile = "Output.txt";

                using (var writer = new StreamWriter(Path.Combine(fileDir, outputFile)))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{count}. {line}");
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
