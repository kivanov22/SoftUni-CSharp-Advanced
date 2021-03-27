using Skeleton.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fake
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints { get; }

        public int DurabilityPoints { get; }

        public void Attack(ITarget target)
        {
            
        }

       
    }
}
