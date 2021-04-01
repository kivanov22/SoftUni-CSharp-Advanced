using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private int fireRate = 10;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (BulletsCount - fireRate >= 0)
            {
                return fireRate;
            }
            else
            {
                //here two options
                int resultBullets = BulletsCount;
                BulletsCount = 0;
                return resultBullets;//0
            }
        }
    }
}
