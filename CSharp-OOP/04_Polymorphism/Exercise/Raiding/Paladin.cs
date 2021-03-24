using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int BaseHero = 100;
        public Paladin(string name)
            : base(name, BaseHero)
        {
        }

        public override string CastAbilibty()
        {
            return $"{nameof(Paladin)} - {Name} healed for {Power}";
        }
    }
}
