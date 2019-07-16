namespace _05.FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Validation;

    public class Player
    {
        private string name;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        private double skillLevel;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;

            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

            this.SkillLevel = default(double);
        }

        public string Name
        {
            get => this.name;

            set
            {
                Validator.ValidateName(value);
                this.name = value;
            }
        }

        private int Endurance
        {
            get => this.endurance;

            set
            {
                Validator.ValidateStat("Endurance", value);
                this.endurance = value;
            }
        }

        private int Sprint
        {
            get => this.sprint;

            set
            {
                Validator.ValidateStat("Sprint", value);
                this.sprint = value;
            }
        }

        private int Dribble
        {
            get => this.dribble;

            set
            {
                Validator.ValidateStat("Dribble", value);
                this.dribble = value;
            }
        }

        private int Passing
        {
            get => this.passing;

            set
            {
                Validator.ValidateStat("Passing", value);
                this.passing = value;
            }
        }

        private int Shooting
        {
            get => this.shooting;

            set
            {
                Validator.ValidateStat("Shooting", value);
                this.shooting = value;
            }
        }

        public double SkillLevel
        {
            get => this.skillLevel;

            private set
            {
                this.skillLevel = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
            }
        }
    }
}
