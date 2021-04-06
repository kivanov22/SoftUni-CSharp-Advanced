using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
   public class CarRepository:IRepository<ICar>
    {
        private  List<ICar> carRepository;
        public CarRepository()
        {
            this.carRepository = new List<ICar>();
        }
        public void Add(ICar model)
        {
            this.carRepository.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll() => this.carRepository;

        public ICar GetByName(string name)
        => this.carRepository.FirstOrDefault(n => n.Model == name);

        public bool Remove(ICar model) => this.carRepository.Remove(model);
    }
}
