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
            | BindingFlags.Public);

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

    public string AnalyzeAcessModifiers(string className)
    {
        Type suspectClassType = Type.GetType(className);

        StringBuilder builder = new StringBuilder();

        builder.AppendLine(CheckFieldModifiers(suspectClassType));

        builder.AppendLine(CheckPropertyMethodModifiers(suspectClassType));

        return builder.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"All Private Methods of Class: {className}");

        Type suspectClassType = Type.GetType(className);
        builder.AppendLine($"Base Class: {suspectClassType.BaseType.Name}");

        MethodInfo[] privateMethods = suspectClassType.GetMethods(
            BindingFlags.Instance
            | BindingFlags.NonPublic
            | BindingFlags.FlattenHierarchy);

        foreach (MethodInfo method in privateMethods)
        {
            builder.AppendLine(method.Name);
        }

        return builder
            .ToString()
            .TrimEnd();
    }

    private string CheckPropertyMethodModifiers(Type suspectClassType)
    {
        PropertyInfo[] propInfo = suspectClassType.GetProperties(
                    BindingFlags.Static
                    | BindingFlags.Instance
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);

        StringBuilder builder = new StringBuilder();

        builder.AppendLine(CheckGetterModifiers(propInfo));
        builder.AppendLine(CheckSetterModifiers(propInfo));

        return builder.ToString().TrimEnd();
    }

    private string CheckSetterModifiers(PropertyInfo[] propInfo)
    {
        MethodInfo[] settersInfo = propInfo
                    .Select(x => x.GetSetMethod())
                    .Where(x => x != null)
                    .ToArray();

        StringBuilder builder = new StringBuilder();

        foreach (MethodInfo setter in settersInfo)
        {
            if (setter.IsPublic)
            {
                builder.AppendLine($"{setter.Name} have to be private!");
            }
        }

        return builder.ToString().TrimEnd();
    }

    private static string CheckGetterModifiers(PropertyInfo[] propInfo)
    {
        MethodInfo[] gettersInfo = propInfo
                    .Select(x => x.GetGetMethod(true))
                    .ToArray();

        StringBuilder builder = new StringBuilder();

        foreach (MethodInfo getter in gettersInfo)
        {
            if (!getter.IsPublic)
            {
                builder.AppendLine($"{getter.Name} have to be public!");
            }
        }

        return builder.ToString().TrimEnd();
    }

    private string CheckFieldModifiers(Type suspectClassType)
    {
        FieldInfo[] allFields = suspectClassType.GetFields(
                    BindingFlags.Static
                    | BindingFlags.Instance
                    | BindingFlags.Public);

        StringBuilder builder = new StringBuilder();

        foreach (FieldInfo field in allFields)
        {
            if (!field.IsPrivate)
            {
                builder.AppendLine($"{field.Name} must be private!");
            }
        }

        return builder.ToString().TrimEnd();
    }
}

