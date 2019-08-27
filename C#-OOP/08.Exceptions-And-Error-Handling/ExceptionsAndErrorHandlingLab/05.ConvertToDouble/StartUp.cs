namespace _05.ConvertToDouble
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                TriggerFormatException();
            }
            catch (FormatException)
            {                
            }

            try
            {
                TriggerOverflowException();
            }
            catch (OverflowException)
            {
            }
        }

        private static void TriggerFormatException()
        {
            string invalidNumberFormat = "this string is not a number in a valid format";

            try
            {
                double result = Convert.ToDouble(invalidNumberFormat);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw fe;
            }            
        }

        private static void TriggerOverflowException()
        {
            string biggerThanMaxValue = "2.79769313486232E+308";

            try
            {
                double result = Convert.ToDouble(biggerThanMaxValue);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                throw oe;
            }
        }
    }
}
