using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializeWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorAlreadyExists()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 30, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 55, 55)));

        }
        [Test]
        public void Enroll_IncreaseArenaCount()
        {
            this.arena.Enroll(new Warrior("Warrior", 30, 50));

            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsWariorToWarriors()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 30, 50));
            
            Assert.That(this.arena.Warriors.Any(w=>w.Name==name), Is.True);
        }

        [Test]
        public void Fight_ThrowsException_WhenDefenderDoesNotExist()
        {
            string attacker = "Attacker";
            this.arena.Enroll(new Warrior(attacker, 40, 40));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker, "Defender"));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            string name = "Defender";
            this.arena.Enroll(new Warrior(name, 40, 40));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker",name));
        }

        [Test]
        public void Fight_ThrowsException_WhenBothDoesNotExist()
        {
            

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void Fight_BothWariorsLoseHp()
        {
            var initialHP = 100;

            var attacker = new Warrior("Attacker", 50, initialHP);
            var defender = new Warrior("Defender", 50, initialHP);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHP - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHP - attacker.Damage));
                

        }
    }
}
