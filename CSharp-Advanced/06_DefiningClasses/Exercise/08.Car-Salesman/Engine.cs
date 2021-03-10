namespace CarSalesman
{
    public class Engine
    {
  
        public string EngineModel { get; set; }

        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string engineModel,int power)
        {
            this.EngineModel = engineModel;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

    }
}
