using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        //        Strength: int
        //Ability: int
        //Intelligence: int
        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public override string ToString()
        {
            return $"Item:"
                + Environment.NewLine + $"  * Strength: {this.Strength}"
                + Environment.NewLine + $"  * Ability: {this.Ability}"
                + Environment.NewLine + $"  * Intelligence: {this.Intelligence}";
        }
    }
}
