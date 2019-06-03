namespace _05.DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, double>> filesByExtension
                = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (var currentFile in allFiles)
            {                
                string fileName = currentFile.Name;
                double fileSize = currentFile.Length / 1024d;
                string extension = currentFile.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new Dictionary<string, double>());
                }
                
                filesByExtension[extension].Add(fileName, fileSize);
            }

            string path =Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                "report.txt");

            foreach (var (key, value) in filesByExtension
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                File.AppendAllText(path, key + Environment.NewLine);

                foreach (var (name, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{name} - {Math.Round(size, 3)}kb" + Environment.NewLine);
                }
            }
        }
    }
}
