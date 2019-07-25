using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfSuspectClass, params string[] fields)
    {
        Type suspectClassType = Type.GetType(nameOfSuspectClass);

        FieldInfo[] allFields = suspectClassType.GetFields(
            BindingFlags.Static
            | BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.NonPublic);

        object suspect = Activator.CreateInstance(suspectClassType, new object[] { });

        StringBuilder builder = new StringBuilder();

        builder.AppendLine(
            $"Class under investigation: {nameOfSuspectClass}");

        foreach (var field in allFields)
        {
            if (fields.Contains(field.Name))
            {
                builder.AppendLine($"{field.Name} = {field.GetValue(suspect)}");
            }
        }

        return builder
            .ToString()
            .TrimEnd();
    }
}

