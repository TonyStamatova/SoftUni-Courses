using System;

namespace _07.concatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = Console.ReadLine();
            string secondName = Console.ReadLine();
            result += Console.ReadLine() + secondName;
            Console.WriteLine(result);
        }
    }
}
