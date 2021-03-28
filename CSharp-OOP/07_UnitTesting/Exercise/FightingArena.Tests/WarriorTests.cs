using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {

        [Test]
        [TestCase(" ", 10, 20)]
        [TestCase("", 10, 20)]
        [TestCase(null, 10, 20)]
        [TestCase("Name", -10, 20)]
        [TestCase("Name", 50, -20)]
        [TestCase("Name", 0, 50)]

        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()//if all data is set to this properties
        {
            string name = "Name";
            int damage = 10;
            int hp = 20;


            Warrior warrior = new Warrior(name, damage, hp);

            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(hp));

        }

        [Test]
        [TestCase(30,55)]
        [TestCase(15,55)]
        [TestCase(55,30)]
        [TestCase(55,15)]

        public void WarriorAttack_HpIsLessThanAttack(int attackerHp, int warriorHp)
        {

            var attacker = new Warrior("Pesho", 50, attackerHp);
            var warrior = new Warrior("Rado", 10, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenWarriorKillsTheAttacker()
        {
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Warrrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_DecreaseHpWithAttack()
        {
            int initialHp = 100;
            var attacker = new Warrior("Attacker", 50, initialHp);
            var warrior = new Warrior("Warrrior", 30, 100);

            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - warrior.Damage));
        }

        [Test]
        public void Attack_SetEnemyHpToZero_WhenAttackerDamageIsGreaterThanEnemyHp()
        {
            
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Warrrior", 30, 40);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_DecreasesEnemyHpByAttackerDamage()
        {
            int warriorInitialHp = 100;
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Warrrior", 30, warriorInitialHp);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(warriorInitialHp-attacker.Damage));
        }
    }
}