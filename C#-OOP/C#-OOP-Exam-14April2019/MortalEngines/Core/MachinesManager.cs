namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);
            this.pilots.Add(pilot);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            IMachine existingTank = this.machines.FirstOrDefault(m => m.Name == name);

            if (existingTank != null && existingTank is ITank)
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);
            return $"Tank {name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine existingFighter = this.machines.FirstOrDefault(m => m.Name == name);

            if (existingFighter != null && existingFighter is IFighter)
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);
            return $"Fighter { name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            machine.Pilot = pilot;
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacking = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine defending = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attacking == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (defending == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attacking.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defending.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attacking.Attack(defending);
            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defending.HealthPoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IMachine existingFighter = this.machines.FirstOrDefault(m => m.Name == fighterName);

            if (existingFighter != null && existingFighter is IFighter fighter)
            {
                fighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }

            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            IMachine existingTank = this.machines.FirstOrDefault(m => m.Name == tankName);

            if (existingTank != null && existingTank is ITank tank)
            {
                tank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }

            return $"Machine {tankName} could not be found";
        }
    }
}