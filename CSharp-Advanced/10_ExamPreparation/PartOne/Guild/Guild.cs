using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
   public class Guild
    {
        private List<Player> roster;
        public Guild(string name , int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return roster.Count; } }
        public void AddPlayer(Player player)
        {
            if (roster.Count<Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)//TODO
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return false;
            }
            roster.Remove(player);
            return true;
        }
        public void PromotePlayer(string name)//ToDo
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank=="Trial")
            {
                player.Rank = "Member";
            }
            
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);//&& p.Rank == "Trial"
            if (player.Rank=="Member")
            {
                player.Rank = "Trial";
            }
            
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> array = new List<Player>();

            foreach (Player player in roster)//.Where(player => player.Class == @class)
            {
                if (player.Class==@class)
                {
                    array.Add(player);
                }
             }
            Player[] returnArray = array.ToArray();
            this.roster = this.roster.Where(x => x.Class != @class).ToList();
            return returnArray;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var item in roster)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
