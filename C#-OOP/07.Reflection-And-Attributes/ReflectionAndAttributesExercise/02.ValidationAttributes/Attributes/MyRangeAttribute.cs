namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!int.TryParse(obj.ToString(), out int parameterAsInt))
            {
                return false;
            }

            if (parameterAsInt >= minValue && parameterAsInt <= maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
