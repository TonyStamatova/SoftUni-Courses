using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        private bool aggressiveMode = false;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, 200)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode => this.aggressiveMode;

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.aggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.aggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            string modeInfo = " *Aggressive: OFF";

            if (this.AggressiveMode)
            {
                modeInfo = " *Aggressive: ON";
            }

            return base.ToString()
                + Environment.NewLine
                + modeInfo;
        }
    }
}
