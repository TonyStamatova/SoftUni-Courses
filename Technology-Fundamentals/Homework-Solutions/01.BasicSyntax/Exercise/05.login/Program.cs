using System;

namespace _05.login
{
    class Program
    {
        public static void Main()
        {
            string username = Console.ReadLine();

            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string inputPass = string.Empty;

            for (int i = 1; i <= 4; i++)
            {
                inputPass = Console.ReadLine();

                if (inputPass == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (i == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
