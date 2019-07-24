namespace _01.Logger.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using _01.Logger.Contracts;

    public class LogFile : IFile
    {
        private const string currentDirectory = "//files//";
        private const string currentFile = "file.txt";

        private string currentPath;
        private IFilePathAdministrator administrator;

        public LogFile()
        {
            this.administrator = new FilePathAdministrator(currentDirectory, currentFile);
            this.currentPath = this.administrator.GetPath();
            this.administrator.CreateValidPath();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; private set; }

        public ulong Size => this.GetFileSize();

        public void Write(string message)
        {
            File.AppendAllText(this.Path, message + Environment.NewLine);
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            return (ulong)text
                .Where(c => char.IsLetter(c))
                .Sum(c => (int)c);
        }
    }
}
