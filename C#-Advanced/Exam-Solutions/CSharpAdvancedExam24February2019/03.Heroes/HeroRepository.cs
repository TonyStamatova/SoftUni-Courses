namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private Dictionary<string, Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new Dictionary<string, Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero)
        {
            this.heroes.Add(hero.Name, hero);
        }

        public void Remove(string name)
        {
            if (this.heroes.ContainsKey(name))
            {
                this.heroes.Remove(name);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.heroes
                .Values
                .OrderByDescending(h => h.Item.Strength)
                .FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.heroes
                .Values
                .OrderByDescending(h => h.Item.Ability)
                .FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.heroes
                .Values
                .OrderByDescending(h => h.Item.Intelligence)
                .FirstOrDefault();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var (name, hero) in this.heroes)
            {
                builder.AppendLine(hero.ToString());
            }

            return builder.ToString();
        }
    }
}
