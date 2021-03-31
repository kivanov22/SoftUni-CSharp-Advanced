using System;

namespace _02.CompositeDesign
{
    public class Program
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("Rootbox", 0);
            var truckToy = new SingleGift("Trucktoy", 289);
            var plainToy = new SingleGift("Plaintoy", 587);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            var childBox = new CompositeGift("Childbox", 0);
            var soldierToy = new SingleGift("Soldiertoy", 200);

            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is {rootBox.CalculateTotalPrice()}");
        }
    }
}
    //Your task is to create a console application that calculates the total price of gifts that are being sold in a shop. 
    //The gift could be a single element (toy) or it can be a complex gift,
    //which consists of a box with two toys and another box with maybe one toy and the box with a single toy inside.
    //We have a tree structure representing our complex gift so, implementing the Composite design pattern will be the right solution for us.