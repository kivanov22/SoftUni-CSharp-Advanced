using Bakery.Models.BakedFoods;

namespace Bakery.Models
{
    public class Cake : BakedFood
    {
        
        public Cake(string name, decimal price)
            : base(name, 245, price)
        {
        }
    }
}
