using System;

namespace _04.passwordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool charCountIsValid = CheckCountOfChars(password);
            bool contentIsValid = CheckContent(password);
            bool minDigitCount = CheckMinDigitCount(password);

            if (!charCountIsValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!contentIsValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!minDigitCount)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (charCountIsValid && contentIsValid && minDigitCount)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckMinDigitCount(string password)
        {
            int digitCount = default(int);

            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]))
                {
                    digitCount++;
                }
            }

            return digitCount < 2 ? false : true;
        }

        private static bool CheckContent(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!Char.IsDigit(password[i]) && !Char.IsLetter(password[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckCountOfChars(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }

            return true;
        }
    }
}
