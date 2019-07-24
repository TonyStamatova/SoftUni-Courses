namespace _01.Logger.Models.Layouts
{
    using _01.Logger.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
