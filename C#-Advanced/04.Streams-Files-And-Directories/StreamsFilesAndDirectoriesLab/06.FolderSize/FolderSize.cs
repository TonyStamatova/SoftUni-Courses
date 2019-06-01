namespace _06.FolderSize
{
    using System.IO;

    public class FolderSize
    {
        public static void Main()
        {
            string dirPath = "../../../TestFolder";
            string[] files = Directory.GetFiles(dirPath);

            using (StreamWriter writer = new StreamWriter("Output.txt"))
            {
                double sum = default;

                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    sum += (double)info.Length / (1024 * 1024);
                }

                writer.WriteLine(sum);
            }
        }
    }
}
