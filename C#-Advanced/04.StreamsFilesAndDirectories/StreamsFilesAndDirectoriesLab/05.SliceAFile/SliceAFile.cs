namespace _05.SliceAFile
{
    using System;
    using System.IO;

    public class SliceAFile
    {
        public static void Main()
        {
            string directory = "files";
            string inputFileName = "sliceMe.txt";

            using (FileStream inputFile = new FileStream(Path.Combine(directory, inputFileName), FileMode.Open))
            {
                long size = inputFile.Length;
                int bufferSize = (int)Math.Ceiling(size / 4d);
                byte[] buffer = new byte[bufferSize];

                for (int i = 1; i <= 4; i++)
                {
                    string outputFileName = $"Part-{i}.txt";

                    using (FileStream outputFile = new FileStream(
                        Path.Combine(directory, outputFileName),
                        FileMode.Create))
                    {
                       int bytesRead = inputFile.Read(buffer, 0, bufferSize);
                        outputFile.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
