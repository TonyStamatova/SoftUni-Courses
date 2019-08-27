namespace _07.CustomException
{
    using System;

    public class InvalidPersonNameException : ArgumentException
    {
        public override string Message => "Name should not contain any special characters or numeric values!";
    }
}
