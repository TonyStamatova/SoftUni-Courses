namespace _01.Logger.Contracts
{
    using _01.Logger.Models.Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel  Level { get; }

        void Append(ILog log);
    }
}
