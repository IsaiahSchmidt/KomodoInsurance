using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    public class Developer
    {
        public Developer(){}
        public Developer(string firstName, string lastName, int idNumber, bool hasPluralsight, string teamName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = idNumber;
            HasPluralsight = hasPluralsight;
            TeamName = teamName;
        }
        // Unique Identifier
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName
        { 
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public bool HasPluralsight { get; set; }
        public string TeamName { get; set; }

        public override string ToString() 
        {
            string str = $"Id: {Id}\n" +
                        $"Name: {FullName}\n"+
                        $"HasPluralsight; {HasPluralsight}";

                        return str;
        }
    }
}