namespace _01.ReverseString    
{
    using System;
    using System.Collections.Generic;

    public class ReverseString
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> result = new Stack<char>(input);
            Console.WriteLine(string.Join("",result));
        }
    }
}
