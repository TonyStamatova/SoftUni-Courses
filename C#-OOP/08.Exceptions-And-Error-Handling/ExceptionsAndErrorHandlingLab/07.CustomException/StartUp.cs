namespace _07.CustomException
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Student student = new Student("Gen4o", "gencho@abv.bg");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }
        }
    }
}
