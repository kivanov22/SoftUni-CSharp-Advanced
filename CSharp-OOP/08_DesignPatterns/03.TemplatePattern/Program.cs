using System;

namespace _03.TemplatePattern
{
   public class Program
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();

        }
    }
}
    //There are easily hundreds of types of bread currently being made in the world,
    //but each kind involves specific steps in order to make them.
    //Your task is to model a few different kinds of bread that all use this same pattern,
    //which is a good fit for the Template Design Pattern.