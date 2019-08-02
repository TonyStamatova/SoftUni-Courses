namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private Axe axe;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void WeaponLoosesDurabilityAfterAttack()
        {
            this.axe = new Axe(10, 10);

            this.axe.Attack(dummy);

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void AttackWithBrokenAxeShouldThrow()
        {
            this.axe = new Axe(10, 0);

            Assert.That(
                () => this.axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message
                    .EqualTo("Axe is broken."));
        }
    }
}
