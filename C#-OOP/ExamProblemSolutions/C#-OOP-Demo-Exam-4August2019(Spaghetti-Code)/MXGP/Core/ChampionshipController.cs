using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> riders;
        private readonly IRepository<IRace> races;
        private readonly IRepository<IMotorcycle> motorcycles;

        public ChampionshipController()
        {
            riders = new RiderRepository();
            races = new RaceRepository();
            motorcycles = new MotorcycleRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.RiderNotFound,
                       riderName));
            }

            IMotorcycle motorcycle = this.motorcycles.GetByName(motorcycleModel);
            if (motorcycle == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.MotorcycleNotFound,
                        motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);
            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceNotFound,
                        raceName));
            }

            IRider rider = this.riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RiderNotFound,
                        riderName));
            }

            race.AddRider(rider);
            return string.Format(
                OutputMessages.RiderAdded,
                riderName,
                raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycles.GetByName(model) != null)
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.MotorcycleExists,
                        model));
            }

            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            this.motorcycles.Add(motorcycle);
            return string.Format(
                OutputMessages.MotorcycleCreated,
                motorcycle.GetType().Name,
                model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceExists,
                        name));
            }

            IRace race = new Race(name, laps);
            this.races.Add(race);
            return string.Format(
                OutputMessages.RaceCreated,
                name);
         }

        public string CreateRider(string riderName)
        {
            if (this.riders.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            IRider rider = new Rider(riderName);
            this.riders.Add(rider);
            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceNotFound,
                        raceName));
            }

            List<IRider> fastest = race
                .Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            if (fastest.Count < 3)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceInvalid,
                        raceName,
                        3));
            }            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(
                OutputMessages.RiderFirstPosition, fastest[0].Name, raceName));
            sb.AppendLine(string.Format(
                OutputMessages.RiderSecondPosition, fastest[1].Name, raceName));
            sb.AppendLine(string.Format(
                 OutputMessages.RiderThirdPosition, fastest[2].Name, raceName));

            this.races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}

