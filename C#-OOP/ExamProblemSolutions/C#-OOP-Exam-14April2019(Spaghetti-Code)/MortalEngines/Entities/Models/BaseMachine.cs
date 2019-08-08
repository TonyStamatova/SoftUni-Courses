using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        
        public BaseMachine(
            string name, 
            double attackPoints, 
            double defensePoints, 
            double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                this.pilot = value ??
                    throw new NullReferenceException("Pilot cannot be null.");
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double difference = this.AttackPoints - target.DefensePoints;

            if (target.HealthPoints > difference)
            {
                target.HealthPoints -= difference;
            }
            else
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");
            sb.Append($" *Targets: ");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine(string.Join(",", this.Targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
