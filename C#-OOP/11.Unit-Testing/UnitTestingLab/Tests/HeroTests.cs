namespace Tests
{
    using NUnit.Framework;

    using Contracts;
    using FakeModels;

    [TestFixture]
    public class HeroTests
    {
        private Hero hero;
        private IWeapon weapon;
        private ITarget target;

        [SetUp]
        public void CreateHeroWithWeaponAndTarget()
        {
            this.target = new FakeDummy();
            this.weapon = new FakeAxe();

            this.hero = new Hero("Our Hero", weapon);
        }

        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            this.hero.Attack(target);

            Assert.That(this.hero.Experience, Is.EqualTo(this.target.GiveExperience()));
        }
    }
}
