using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Contracts
{
    public interface IWeapon
    {
        void Attack(ITarget target);

        int AttackPoints { get; }

        int DurabilityPoints { get; }

    }
}
