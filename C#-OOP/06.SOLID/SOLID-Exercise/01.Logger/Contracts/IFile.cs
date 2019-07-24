namespace _01.Logger.Contracts
{
    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        void Write(string logText);
    }
}
