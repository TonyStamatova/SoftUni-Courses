using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.Public
            | BindingFlags.NonPublic);

        foreach (MethodInfo method in methods)
        {
            Attribute[] attributes = method
                .GetCustomAttributes(typeof(AuthorAttribute))
                .ToArray();

            foreach (AuthorAttribute attribute in attributes)
            {
                Console.WriteLine($"{method.Name} is wirtten by {attribute.Name}");
            }
        }
    }
}
