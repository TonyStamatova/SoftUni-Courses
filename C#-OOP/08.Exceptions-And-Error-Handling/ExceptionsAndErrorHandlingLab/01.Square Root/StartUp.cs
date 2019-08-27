namespace _01.Square_Root
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number"); 
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
