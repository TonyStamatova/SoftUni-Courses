namespace _04.MergeFiles
{
    using System.IO;
    
    public class MergeFiles
    {
        public static void Main()
        {
            string directory = "files";
            string fileOne = "FileOne.txt";

            using (StreamReader firstFileReader = new StreamReader(Path.Combine(directory, fileOne)))
            {
                string fileTwo = "FileTwo.txt";

                using (StreamReader secondFileReader = new StreamReader(Path.Combine(directory, fileTwo)))
                {
                    string outputFile = "Output.txt";

                    using (StreamWriter writer = new StreamWriter(Path.Combine(directory, outputFile)))
                    {
                        for (int i = 0; i < fileOne.Length; i++)
                        {
                            writer.WriteLine(firstFileReader.ReadLine());
                            writer.WriteLine(secondFileReader.ReadLine());
                        }
                    }
                }
            }
        }
    }
}
