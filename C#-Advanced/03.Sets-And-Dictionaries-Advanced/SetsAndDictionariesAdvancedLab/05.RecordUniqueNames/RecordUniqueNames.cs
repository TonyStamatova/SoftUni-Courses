namespace _05.RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    public class RecordUniqueNames
    {
        public static void Main()
        {
            var names = new HashSet<string>();

            var numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var name = Console.ReadLine();

                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
