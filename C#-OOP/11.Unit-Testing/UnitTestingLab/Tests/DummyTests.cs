namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int INITIAL_HEALTH = 10;
        private const int INITIAL_XP = 10;

        private Dummy dummy;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            this.dummy = new Dummy(INITIAL_HEALTH, INITIAL_XP);
        }

        [Test]
        public void LoseHealthWhenAttacked()
        {
            this.dummy.TakeAttack(3);

            Assert.That(this.dummy.Health, Is.EqualTo(INITIAL_HEALTH - 3));
        }

        [Test]
        public void DeadDummyThrowsIfAttacked()
        {
            //Takes all health from Setup Dummy
            this.dummy.TakeAttack(INITIAL_HEALTH);             

            Assert.That(
                () => this.dummy.TakeAttack(3), 
                Throws.Exception.With.Message.EqualTo("Dummy is dead."));
        }
        
        [Test]
        public void DeadDummyGivesXP()
        {
            //Takes all health from Setup Dummy
            this.dummy.TakeAttack(INITIAL_HEALTH);

            int experience = this.dummy.GiveExperience();

            Assert.That(experience, Is.EqualTo(INITIAL_XP));
        }

        [Test]
        public void AliveDummyThrowsInsteadOfGivingXP()
        {
            Assert.That(
                () => this.dummy.GiveExperience(),
                Throws.Exception.With.Message.EqualTo("Target is not dead."));
        }
    }
}
