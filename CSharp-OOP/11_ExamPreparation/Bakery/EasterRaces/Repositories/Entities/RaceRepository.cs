using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> raceRepository;
        public RaceRepository()
        {
            this.raceRepository = new List<IRace>();
        }
        public void Add(IRace model)
        {
            this.raceRepository.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()=>this.raceRepository;

        public IRace GetByName(string name)
        => this.raceRepository.FirstOrDefault(n => n.Name == name);

        public bool Remove(IRace model) => this.raceRepository.Remove(model);
        
    }
}
