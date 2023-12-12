using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTeams.Data;

namespace DevTeams.Repository
{
    public class DevTeamRepository
    {
        //* similar to methods DevRepository
        // start here, work to UI (makes it easier)
        private readonly List<DevTeam> _devTeamDbContent = new List<DevTeam>();
        private readonly DevRepository _devRepo = new DevRepository();
        private int _teamIdCount;
        private List<Developer> _dbDevContent;

        public DevTeamRepository()
        {
            _devTeamDbContent = new List<DevTeam>();
            Seed();
        }

        private void Seed()
        {
            _dbDevContent = new List<Developer>();
            DevTeam teamOne = new DevTeam("Team One",_dbDevContent,1001);
            DevTeam teamTwo = new DevTeam("Team Two",_dbDevContent,1002);
            DevTeam teamThree = new DevTeam("Team Three",_dbDevContent, 1003);
            //! doesn't return list of developers -> should be fixed (done in class)
            AddDevTeam(teamOne);
            AddDevTeam(teamTwo);
            AddDevTeam(teamThree);
        }

        public bool AddDevTeam(DevTeam devTeam)
        {
            if (devTeam is null)
            {
                return false;
            }
            else
            {
                return AddToDatabase(devTeam);
            }
        }

        private bool AddToDatabase(DevTeam devTeam)
        {
            IncrementId(devTeam);
            _devTeamDbContent.Add(devTeam);
            return true;
            
        }

        private void IncrementId(DevTeam devTeam)
        {
            _teamIdCount++;
            devTeam.TeamId = _teamIdCount;
        }

        public List<DevTeam> GetDevTeams()
        {
            return _devTeamDbContent;
        }

        public DevTeam GetDevTeam(int teamIdRemove)
        {
            return _devTeamDbContent.FirstOrDefault(dTeam => dTeam.TeamId == teamIdRemove)!;
        }

        public bool RemoveTeam(int teamIdRemove)
        {
            var dTeamInDb = GetDevTeam(teamIdRemove);
            return _devTeamDbContent.Remove(dTeamInDb);
        }

        //todo: Update method - do for Developer first

        //todo: Add Dev to Team - done in class
        public bool AddToTeam(int devId, int teamId)
        {
            //! we cant access developer stuff here - need new instance of DevRepository in this class (private readonly statement at top)
            Developer dev = _devRepo.GetDeveloper(devId);
            if(dev != null)
            {
                DevTeam team = GetDevTeam(teamId);
                if (team != null)
                {
                    team.Developers.Add(dev);
                    return true;
                }
            }
            return false;
        }

        //todo: Challenge 2 - done in class
        // adding multiple devs at once
        public bool AddMultiDevs(int teamId, List<int> devId)
        {
            var team = GetDevTeam(teamId);
            if (team != null)
            {
                foreach (var dev in devId)
                {
                    Developer developer = _devRepo.GetDeveloper(id);    //todo: check what variable should be
                    if (developer is not null)                               
                    {
                        team.Developers.Add(developer);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}