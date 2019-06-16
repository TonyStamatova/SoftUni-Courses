namespace _02.GenericBoxOfIntegers
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            string objType = this.Value.GetType().ToString();
            return $"{objType}: {this.Value}";
        }
    }
}
