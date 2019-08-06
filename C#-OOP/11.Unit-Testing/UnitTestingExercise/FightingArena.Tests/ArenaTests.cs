using System;

using NUnit.Framework;

using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("name", 40, 40);
        }

        [Test]                
        public void ConstructorCreatedWarriorsCollection()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]                   
        public void EnrollShouldIncreaseCorrectCount()
        {
            this.arena.Enroll(this.warrior);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.arena.Count);
        }


        [Test]                  
        public void EnrollShouldThrowWithExistingWarrior()
        {
            this.arena.Enroll(this.warrior);

            Warrior newWarrior = new Warrior(this.warrior.Name, 30, 50);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Enroll(newWarrior));
        }

        [Test]                  
        public void FightShouldExecuteAttackMethodOnWarriors()
        {
            Warrior attacker = new Warrior("attacker", 50, 50);
            Warrior defender = new Warrior("defender", 40, 60);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("attacker", "defender");

            int expectedDefenderHP = 10;

            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]                  
        public void FightWithInvalidAttackedNameShouldThrow()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Fight(this.warrior.Name, "attacked"));
        }

        [Test]                   
        public void FightWithInvalidAttackerNameShouldThrow()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Fight("attacker", this.warrior.Name));
        }
    }
}
