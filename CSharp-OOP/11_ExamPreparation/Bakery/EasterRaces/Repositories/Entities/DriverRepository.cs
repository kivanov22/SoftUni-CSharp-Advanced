using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository:IRepository<IDriver>
    {
        private  List<IDriver> driversRepostiory;
        public DriverRepository()
        {
            this.driversRepostiory = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            this.driversRepostiory.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => this.driversRepostiory;

        public IDriver GetByName(string name)
        => this.driversRepostiory.FirstOrDefault(n => n.Name == name);

        public bool Remove(IDriver model) => this.driversRepostiory.Remove(model);
    }
}
