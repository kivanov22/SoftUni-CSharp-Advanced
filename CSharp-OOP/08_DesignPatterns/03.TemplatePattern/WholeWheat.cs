using System;
using System.Collections.Generic;
using System.Text;

namespace _03.TemplatePattern
{
    public class WholeWheat:Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheats Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat Bread.");
        }
    }
}
