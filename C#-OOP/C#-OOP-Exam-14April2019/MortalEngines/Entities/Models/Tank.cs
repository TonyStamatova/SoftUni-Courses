using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        private bool defenseMode = false;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, 100)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode => this.defenseMode;

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.defenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.defenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            string modeInfo = " *Defense: OFF";

            if (this.DefenseMode)
            {
                modeInfo = " *Defense: ON";
            }

            return base.ToString()
                + Environment.NewLine
                + modeInfo;
        }
    }
}
