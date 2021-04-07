using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.computers.Any(x => x.Id == computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var targetComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            targetComputer.AddComponent(component);

            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c=>c.Id==id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            IComputer computer = null;

            if (computerType=="DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType=="Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }
            this.computers.Add(computer);
            

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (this.computers.Any(x => x.Id == computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var targetComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (this.peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            targetComputer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count==0 || computers.Any(x=>x.Price<=budget)==false)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            this.computers = computers.OrderByDescending(d => d.OverallPerformance).ThenByDescending(x => x.Price).ToList();

            var targetComputer = computers.FirstOrDefault();
            this.computers.Remove(targetComputer);

            return targetComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            if (this.computers.Any(x => x.Id == id) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var targetComputer = this.computers.FirstOrDefault(x => x.Id == id);

            this.computers.Remove(targetComputer);

            return targetComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (this.computers.Any(x => x.Id == id) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var targetComputer = this.computers.FirstOrDefault(x => x.Id == id);

            return targetComputer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (this.computers.Any(x => x.Id == computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var targetComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (targetComputer.Components.Any(x=>x.GetType().Name==componentType)==false)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {targetComputer.GetType().Name} with Id {computerId}.");
            }

            var targetComponent = targetComputer.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            targetComputer.RemoveComponent(componentType);
            this.components.Remove(targetComponent);

            return $"Successfully removed {componentType} with id {targetComponent.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (this.computers.Any(x => x.Id == computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var targetComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (targetComputer.Peripherals.Any(x => x.GetType().Name == peripheralType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, targetComputer.GetType().Name, computerId));
            }

            var targetPeripheral= targetComputer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            targetComputer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(targetPeripheral);

            return $"Successfully removed {peripheralType} with id {targetPeripheral.Id}.";
        }
    }
}
