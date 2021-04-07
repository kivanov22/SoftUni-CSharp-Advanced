using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product,IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public override decimal Price => base.Price + Components.Sum(c=>c.Price) + Peripherals.Sum(p=>p.Price);

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count==0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + Components.Average(x => x.OverallPerformance);
            }
        }
        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (Components.Any(c=>c.GetType().Name==component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.Count==0 || Components.Any(c=>c.GetType().Name==componentType)==false)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {GetType().Name} with Id {Id}.");
            }

            var targetComponent = components.FirstOrDefault(c => c.GetType().Name == componentType);

            components.Remove(targetComponent);

            return targetComponent;

        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (Peripherals.Count==0 || (Peripherals.Any(p=>p.GetType().Name == peripheralType)==false))
            {
                throw new ArgumentException($"Peripheral {peripheralType} already exists in {GetType().Name} with Id {Id}.");
            }

            var targetPeripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            peripherals.Remove(targetPeripheral);

            return targetPeripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var item in Components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            double averageOverallPerformanceOfPeripherals = 0;

            if (Peripherals.Any())
            {
                averageOverallPerformanceOfPeripherals =this.Peripherals.Average(x => x.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({averageOverallPerformanceOfPeripherals:F2}):");//wrong data

            foreach (var item in Peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
