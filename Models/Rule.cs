using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class Rule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public ICollection<RulesProfiles> RulesProfiles { get; set; } = new List<RulesProfiles>();
        public Rule()
        {
        }
        public Rule(string name, string label)
        {
            Name = name;
            Label = label;
        }
    }
}
