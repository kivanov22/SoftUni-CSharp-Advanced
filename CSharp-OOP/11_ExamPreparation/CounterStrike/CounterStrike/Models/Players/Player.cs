using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;


        public Player(string username,int health,int armor,IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }
        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        
        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }
        
        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }
        public bool IsAlive
        {
            get { return this.Health > 0; }
        }
        

        public void TakeDamage(int points)
        {
            if (armor-points>=0)
            {
                armor -= points;
                return;
            }
            else if(armor>0)
            {
                points -= armor;
                armor = 0;
            }
            Health -= points;
        }
    }
}
