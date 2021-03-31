using System;

namespace _01.PrototypePattern
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();


            sandwichMenu["BLT"] = new Sandwitch("Wheat", "Bacon", "Lettuce", "Tomato");
            sandwichMenu["PB&J"] = new Sandwitch("Wheat",  "Potato", "Lettuce", "Tomato");
            sandwichMenu["Turkey"] = new Sandwitch("Swis", "Bacon", "Onion", "Tomato");


            Sandwitch sandwich1 = sandwichMenu["BLT"].Clone() as Sandwitch;
            Sandwitch sandwich2 = sandwichMenu["PB&J"].Clone() as Sandwitch;
            Sandwitch sandwich3 = sandwichMenu["Turkey"].Clone() as Sandwitch;



        }
    }
}
