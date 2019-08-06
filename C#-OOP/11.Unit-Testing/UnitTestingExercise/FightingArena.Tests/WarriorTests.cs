using System;

using NUnit.Framework;

using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private string name = "test name";
        private int damage = 10;
        private int hp = 20;

        private Warrior warrior;

        private Warrior enemy = new Warrior("enemy", 10, 10);

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void ConstructorCreatesWarrior()
        {
            Assert.IsNotNull(this.warrior);
        }

        [Test]                  
        public void NameGetterReturnsCorrecrString()
        {
            string expectedName = this.name;

            Assert.AreEqual(expectedName, this.warrior.Name);
        }

        [Test]                  
        public void NameSetterShouldThrowWithEmptyString()
        {
            string emptyStringName = "";

            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(emptyStringName, this.damage, this.hp),
                "Name should not be empty or whitespace!");
        }

        [Test]
        public void NameSetterShouldThrowWithWhitespace()
        {
            string emptyStringName = "  ";
        
            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(emptyStringName, this.damage, this.hp),
                "Name should not be empty or whitespace!");
        }

        [Test]
        public void DamageGetterReturnsCorrectInt()
        {
            int expectedDamage = this.damage;
        
            Assert.AreEqual(expectedDamage, this.warrior.Damage);
        }

        [Test]                  
        public void DamageSetterShouldThrowWithZeroDamage()
        {
            int zeroDamage = 0;

            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(this.name, zeroDamage, this.hp),
                "Damage value should be positive!");
        }

        [Test]                 
        public void DamageSetterShouldThrowWithNegativeDamage()
        {
            int negativeDamage = -1;

            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(this.name, negativeDamage, this.hp),
                "Damage value should be positive!");
        }
        
        [Test]                 
        public void HPSetterShouldThrowWithNegativeHP()
        {
            int negativeHP = -10;

            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(this.name, this.damage, negativeHP),
                "HP should not be negative!");
        }

        [Test]
        public void AttackEnemyWith30HPShouldThrow()
        {
            int enoughHPPoints = 40;
            this.warrior = new Warrior(this.name, this.damage, enoughHPPoints);
            Warrior enemyWith30HP = new Warrior("enm", 50, 30);
        
            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(enemyWith30HP));
        }

        [Test]
        public void AttackWith30HPShouldThrow()
        {
            int edgeCaseHPPoints = 30;
            this.warrior = new Warrior(this.name, this.damage, edgeCaseHPPoints);
            Warrior enemy = new Warrior("enm", 50, 40);
        
            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(enemy));
        }

        [Test]                    
        public void AttackWithHPLessThan30ShouldThrow()
        {
            int enoughHPPoints = 40;
            Warrior defender = new Warrior(this.name, this.damage, enoughHPPoints);

            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(defender));
        }

        [Test]         
        public void AttackEnemyWithHPLessThan30ShouldThrow()
        {
            int enoughHPPoints = 40;
            this.warrior = new Warrior(this.name, this.damage, enoughHPPoints);

            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(this.enemy),
                "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]                         
        public void AttackEnemyWithMoreDamagePointsShouldThrow()
        {
            int enoughHPPoints = 40;
            this.warrior = new Warrior(this.name, this.damage, enoughHPPoints);

            Warrior enemyAvailableForAttack = new Warrior("enemy", 50, 40);

            Assert.That(
                () => this.warrior.Attack(enemyAvailableForAttack),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]                         
        public void AttackEnemyShouldDecreaseHP()
        {
            int enoughHPPoints = 40;
            this.warrior = new Warrior(this.name, this.damage, enoughHPPoints);
        
            Warrior enemyAvailableForAttack = new Warrior("enemy", 30, 35);
        
            int expectedWarriorHP = 10;
            int expectedEnemyHP = 25;
        
            this.warrior.Attack(enemyAvailableForAttack);
        
            Assert.AreEqual(expectedWarriorHP, this.warrior.HP);
            Assert.AreEqual(expectedEnemyHP, enemyAvailableForAttack.HP);
        }

        [Test]                  
        public void AttackEnemyWithLessHPPointsThanDamageOfAttackerShouldZeroThem()
        {
            Warrior attacker = new Warrior(this.name, 60, 50);
            Warrior attacked = new Warrior("attacked", 40, 40);

            attacker.Attack(attacked);

            int expectedHP = 0;

            Assert.AreEqual(expectedHP, attacked.HP);
        }

        [Test]                          
        public void AttackEnemyShouldDecreaseEnemyHP()
        {
            Warrior attacker = new Warrior(this.name, 30, 50);
            Warrior attacked = new Warrior("attacked", 40, 50);
        
            attacker.Attack(attacked);
        
            int expectedHP = 20;
        
            Assert.AreEqual(expectedHP, attacked.HP);
        }

        [Test]                 
        public void AttackEnemyWithHPPointsEqualToDamageOfAttackerShouldZeroThem()
        {
            Warrior attacker = new Warrior(this.name, 40, 50);   
            Warrior attacked = new Warrior("attacked", 40, 40);
        
            attacker.Attack(attacked);
        
            int expectedHP = 0;
        
            Assert.AreEqual(expectedHP, attacked.HP);
        }
    }
}