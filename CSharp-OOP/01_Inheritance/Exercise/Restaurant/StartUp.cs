namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var coffee = new Coffee("Costa", 250);

            System.Console.WriteLine(coffee.Price);//maybe 3.50 not 3.5
        }
    }
}