﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CompositeDesign
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with price {price}");
            return price;
        }
    }
}
