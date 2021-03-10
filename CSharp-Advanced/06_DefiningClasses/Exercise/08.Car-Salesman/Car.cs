using System;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        

        public string CarModel { get; set; }

        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }


        public Car(string carModel, Engine engine)
        {
            this.CarModel = carModel;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.CarModel}:");
            result.AppendLine($"  {this.Engine.EngineModel}:");
            result.AppendLine($"    Power: {this.Engine.Power}");
            result.AppendLine($"    Displacement: {this.Engine.Displacement}");
            result.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            result.AppendLine($"  Weight: {this.Weight}");
            result.AppendLine($"  Color: {this.Color}");

             return result.ToString().TrimEnd();
        }
    }
}
