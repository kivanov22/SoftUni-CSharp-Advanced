﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
   public class Player
    {
        private string rank = "Trial";
        private string description = "n/a";

        public Player(string name,string @class)
        {
            Name = name;
            Class = @class;
            Rank = rank;
            Description = description;
        }
        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine ($"Player {Name}: {Class}");
            result.AppendLine($"Rank: {Rank}");
            result.AppendLine($"Description: {Description}");

            return result.ToString().TrimEnd();
        }
    }
}
