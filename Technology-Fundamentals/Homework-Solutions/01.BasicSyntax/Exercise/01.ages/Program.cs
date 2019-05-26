using System;

namespace _01.agesss
{
    class Program
    {
        public static void Main()
        {
            //            •	0 - 2 – baby; 
            //•	3 - 13 – child; 
            //•	14 - 19 – teenager;
            //•	20 - 65 – adult;
            //•	>= 66 – elder;

            int age = int.Parse(Console.ReadLine());
            string result = string.Empty;

            if (age <= 2)
            {
                result = "baby";
            }
            else if (age <= 13)
            {
                result = "child";
            }
            else if (age <= 19)
            {
                result = "teenager";
            }
            else if (age <= 65)
            {
                result = "adult";
            }
            else
            {
                result = "elder";
            }

            Console.WriteLine(result);
        }
    }
}
