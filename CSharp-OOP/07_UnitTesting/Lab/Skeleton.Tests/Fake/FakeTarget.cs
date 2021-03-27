using Skeleton.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fake
{
    public class FakeTarget : ITarget
    {
        public int Health { get; }

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
