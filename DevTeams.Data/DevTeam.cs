using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    public class DevTeam
    {
        public DevTeam()
        {
            
        }
        public DevTeam(string teamName, List<Developer> developers, int teamId)
        {
            TeamName = teamName;
            Developers = developers;
            TeamId = teamId;
        }
        public int TeamId {get; set;}
        public string TeamName {get; set;}
        public List<Developer> Developers { get; set; } = new List<Developer>();

        public override string ToString()
        {
            string str = $"Team Name: {TeamName}\n"+
                        $"Team ID: {TeamId}\n"+
                        "============\n";
            if (Developers.Count() > 0)
            {
                foreach (Developer developer in this.Developers)
                {
                    str += $"{developer}\n"+
                            "===============";
                }
            }
            else
            {
                str+= "Sorry, no developers available";
            }
            return str;
        }
    }
}