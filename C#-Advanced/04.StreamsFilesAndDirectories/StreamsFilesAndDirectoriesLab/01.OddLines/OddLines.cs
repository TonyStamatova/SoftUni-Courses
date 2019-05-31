namespace _01.OddLines
{
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            string fileDir = "files";
            string fileName = "Input.txt";
            string filePath = Path.Combine(fileDir, fileName);

            using (var reader = new StreamReader(filePath))
            {
                int count = default;
                string line = reader.ReadLine();
                string outputFile = "Output.txt";

                using (var writer = new StreamWriter(Path.Combine(fileDir, outputFile)))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }                
            }
        }
    }
}
