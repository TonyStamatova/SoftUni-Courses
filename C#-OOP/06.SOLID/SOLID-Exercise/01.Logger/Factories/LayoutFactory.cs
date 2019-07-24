namespace _01.Logger.Factories
{
    using System;

    using _01.Logger.Contracts;
    using _01.Logger.Exceptions;
    using _01.Logger.Models.Layouts;

    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidLayoutMessage);
            }
        }
    }
}
