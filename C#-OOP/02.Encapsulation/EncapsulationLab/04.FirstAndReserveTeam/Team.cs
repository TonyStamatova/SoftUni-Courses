﻿namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;

            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public IReadOnlyList<Person> FirstTeam { get => this.firstTeam; }

        public IReadOnlyList<Person> ReserveTeam { get => this.reserveTeam; }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
