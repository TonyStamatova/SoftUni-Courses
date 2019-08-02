namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        private static Dummy dummy;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void WeaponLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void AttackWithBrokenAxeShouldThrow()
        {
            Axe axe = new Axe(10, 0);

            Assert.That(
                () => axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message
                    .EqualTo("Axe is broken."));
        }
    }
}
