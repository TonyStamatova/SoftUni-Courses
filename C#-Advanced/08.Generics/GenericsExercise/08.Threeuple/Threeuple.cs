namespace _08.Threeuple
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Threeuple<T, V, W>
    {
        public Threeuple(T firstElement, V secondElement, W thirdElement)
        {
            this.FirstElement = firstElement;
            this.SecondElement = secondElement;
            this.ThirdElement = thirdElement;
        }

        public T FirstElement { get; set; }

        public V SecondElement { get; set; }

        public W ThirdElement { get; set; }

        public string GetInfo()
        {
            return $"{this.FirstElement} -> {this.SecondElement} -> {this.ThirdElement}";
        }
    }
}
