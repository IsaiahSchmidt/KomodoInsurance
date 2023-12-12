using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTeams.Data;

namespace DevTeams.Repository
{
    public class DevRepository
    {
        // fake database : Collection List<T>
        private readonly List<Developer> _devDbContent;
        private int _idCount;

        public DevRepository()
        {
            _devDbContent = new List<Developer>();
            Seed();
        }

        private void Seed()
        {
            Developer daymon = new Developer("Daymon","Wayans",101,false,"TeamOne");
            Developer george = new Developer("George","Carlin",102,true,"TeamTwo");
            Developer burr = new Developer("Bill","Burr",103,false,"TeamTwo");

            AddDeveloper(daymon);
            AddDeveloper(george);
            AddDeveloper(burr);
        }

        // CRUD method
        public bool AddDeveloper(Developer developer)
        {
            if (developer is null)
            {
                return false;
            }
            else
            {
                return AddToDatabase(developer);
            }
            // return (developer is null)? false : AddToDatabase(developer);    //* same as above, just one line
        }

        private bool AddToDatabase(Developer developer)
        {
            IncrementId(developer);
            _devDbContent.Add(developer);
            return true;
        }

        private void IncrementId(Developer developer)
        {
            _idCount++;
            developer.Id = _idCount;
        }   //* only need to increment up, not down

        public List<Developer> GetDevelopers()
        {
            return _devDbContent;
        }

         public Developer GetDeveloper(int idRemove)    
        {
            return _devDbContent.FirstOrDefault(dev => dev.Id == idRemove)!;
        }
        public bool RemoveDeveloper(int idRemove) 
        {
            var devInDb = GetDeveloper(idRemove);
            return _devDbContent.Remove(devInDb);
        }

        //todo Update method - reference streaming content      finished in class
        //! do NOT update ID
        public bool UpdateDeveloperInfo(int devId, Developer newDevData)
        {
            Developer devInDatabase = GetDeveloper(devId);
            // defensive coding
            // dev is in database...
            if (devInDatabase != null)
            {
                devInDatabase.FirstName = newDevData.FirstName;
                devInDatabase.LastName = newDevData.LastName;
                devInDatabase.HasPluralsight = newDevData.HasPluralsight;
                return true;
            }
            return false;
        }

        //todo: Challenge 1         done in class
        public List<Developer> GetDevelopersWithoutPs()
        {
            // start w empty list
            List<Developer> developersWoPs = new List<Developer>();
            // loop thru database
            foreach (Developer developer in _devDbContent)
            {
                if (developer.HasPluralsight is false)
                {
                    // add to empty list
                    developersWoPs.Add(developer);
                }
            }
            return developersWoPs;
        }
    }
}