namespace Tests
{
    using NUnit.Framework;
    using Moq;

    using Contracts;

    [TestFixture]
    public class HeroTests
    {
        private const int XP_TO_GAIN_FROM_KILLED_TARGET = 10;

        private Hero hero;
        private Mock<IWeapon> weapon;
        private Mock<ITarget> target;

        [SetUp]
        public void CreateHeroWithWeaponAndTarget()
        {
            this.target = new Mock<ITarget>();
            this.weapon = new Mock<IWeapon>();

            this.target
                .Setup(t => t.GiveExperience())
                .Returns(XP_TO_GAIN_FROM_KILLED_TARGET);

            this.target
                .Setup(t => t.IsDead())
                .Returns(true);

            this.hero = new Hero("Our Hero", weapon.Object);
        }

        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            this.hero.Attack(this.target.Object);

            Assert.That(
                this.hero.Experience, 
                Is.EqualTo(this.target.Object.GiveExperience()));
        }
    }
}
