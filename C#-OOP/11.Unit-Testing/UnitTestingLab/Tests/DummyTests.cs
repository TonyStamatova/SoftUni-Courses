namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LoseHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(3);

            Assert.That(dummy.Health, Is.EqualTo(7));
        }

        [Test]
        public void DeadDummyThrowsIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);            

            Assert.That(
                () => dummy.TakeAttack(3), 
                Throws.Exception.With.Message.EqualTo("Dummy is dead."));
        }
        
        [Test]
        public void DeadDummyGivesXP()
        {
            Dummy dummy = new Dummy(0, 10);

            int experience = dummy.GiveExperience();

            Assert.That(experience, Is.EqualTo(10));
        }

        [Test]
        public void AliveDummyThrowsInsteadOfGivingXP()
        {
            Dummy dummy = new Dummy(10, 10);
            
            Assert.That(
                () => dummy.GiveExperience(),
                Throws.Exception.With.Message.EqualTo("Target is not dead."));
        }
    }
}
