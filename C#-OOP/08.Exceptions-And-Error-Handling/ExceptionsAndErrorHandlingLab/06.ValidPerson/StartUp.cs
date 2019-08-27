namespace _06.ValidPerson
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<string[]> peopleInfo = new List<string[]>
            {
                new string[]{ "Pesho", "Peshev", "24" },
                new string[]{ string.Empty, "Goshev", "31" },
                new string[]{ "Ivan", null, "63" },
                new string[]{ "Stoyan", "Kolev", "-1" },
                new string[]{ "Iskren", "Ivanov", "121" }
            };


            foreach (var personInfo in peopleInfo)
            {
                try
                {
                    CreateNewPerson(personInfo);
                }
                catch (ArgumentNullException ane)
                {
                    PrintExceptionMessage(ane);
                    continue;
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    PrintExceptionMessage(aoore);
                    continue;
                }

                Console.WriteLine("You have created a Person entity successfully");
            }           
        }

        private static void CreateNewPerson(string[] personInfo)
        {
            string firstName = personInfo[0];
            string lastName = personInfo[1];
            int age = int.Parse(personInfo[2]);

            Person newPerson = new Person(firstName, lastName, age);
        }

        private static void PrintExceptionMessage(ArgumentException ae)
        {
            Console.WriteLine($"Exception thrown: {ae.Message}");
        }
    }
}
