﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread.");
        }
    }
}
