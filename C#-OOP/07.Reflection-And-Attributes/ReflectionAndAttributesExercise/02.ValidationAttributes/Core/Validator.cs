namespace ValidationAttributes.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();
            
            PropertyInfo[] properties = objectType.GetProperties(
                BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.NonPublic);

            foreach (PropertyInfo property in properties)
            {
                Attribute[] attributes = property
                     .GetCustomAttributes()
                     .ToArray();

                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
