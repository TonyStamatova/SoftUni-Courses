﻿namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private Random random = new Random();        

        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string result = this[index];
            this.RemoveAt(index);

            return result;
        }
    }
}
