namespace _06.GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T> where T : IComparable<T>
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

        public int GetGreaterElementsCount(List<T> list, T element)
        {
            return list.Where(e => e.CompareTo(element) > 0).Count();
        }
    }
}
