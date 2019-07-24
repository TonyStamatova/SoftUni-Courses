namespace _01.Logger.Models
{
    using System.IO;

    using _01.Logger.Contracts;

    public class FilePathAdministrator : IFilePathAdministrator
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        public FilePathAdministrator(string currentDirectory, string currentFile)
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;

            this.currentPath = this.GetPath();
        }

        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        public void CreateValidPath()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
