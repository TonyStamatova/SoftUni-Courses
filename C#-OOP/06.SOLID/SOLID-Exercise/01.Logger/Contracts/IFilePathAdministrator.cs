namespace _01.Logger.Contracts
{
    public interface IFilePathAdministrator
    {
       string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void CreateValidPath();

        string GetPath();
    }
}
