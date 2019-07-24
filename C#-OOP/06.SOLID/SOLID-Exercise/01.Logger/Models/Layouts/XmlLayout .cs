namespace _01.Logger.Models.Layouts
{
    using System.Text;

    using _01.Logger.Contracts;

    public class XmlLayout : ILayout
    {
        public string Format => this.GetFormat();

        public string GetFormat()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<log>")
                .AppendLine(" <date>{0}</date>")
                .AppendLine(" <level>{1}</level>")
                .AppendLine(" <message>{2}</message>")
                .AppendLine("</log>");

            return builder.ToString().TrimEnd();
        }
    }
}
