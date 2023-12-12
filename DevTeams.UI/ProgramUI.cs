using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DevTeams.Data;
using DevTeams.Repository;
using static System.Console;


public class ProgramUI
{
    private readonly DevRepository _devRepo = new DevRepository();
    private readonly DevTeamRepository _devTeamRepo = new DevTeamRepository();

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            // Clear();
            WriteLine("Welcome to Komodo Dev Teams\n"+
                                    "1. Add developers\n"+
                                    "2. List developers\n"+
                                    "3. Remove Developers\n"+
                                    "4. Create New Team\n"+
                                    "5. List Teams\n"+
                                    "6. Add Developer to Team\n"+
                                    "7. Update Developer Info\n"+
                                    "8. Check Who Needs Pluralsight License\n"+
                                    "0. Close");

            var userInput = int.Parse(ReadLine()!);

            switch (userInput)
            {
                case 1:
                    AddDeveloper();
                    break;
                case 2:
                    ListDevelopers();
                    break;
                case 3:
                    RemoveDevelopers();             //todo: Remove Developers
                    break;                          // should be go to go - debug again to check
                case 4:
                    CreateNewTeam();                   //todo: Create New Team
                    break;                              // should be good
                case 5:
                    ListTeams();
                    break;
                case 6:
                    AddToTeam();                        //todo: Add To Team
                    break;
                case 7:
                    UpdateDeveloperInfo();              //todo: Update Info
                    break;
                case 8:                                  
                    // NeedPluralsight();                  //todo: Extra Credit 1
                    break;
                case 0:
                    isRunning = CloseApp();
                    break;
                default:
                    break;
            }
        }
    }

    private void ListTeams()
    {
        List<DevTeam> devTeamsInDb = _devTeamRepo.GetDevTeams();
        foreach (DevTeam devTeam in devTeamsInDb)
        {
            WriteLine(devTeam);
            WriteLine("------------------\n");
        }
        PressAnyKey();
    }

    // private List<Developer> NeedPluralsight()       //todo: Extra Credit - done in class elsewhere
    // {
    //     ListDevelopers();
    //     foreach (Developer developer in //? )
    //     {
    //         if (developer.HasPluralsight)
    //         {
    //             continue;
    //         }
    //         else
    //         {
    //             return //?
    //         }
    //     }
    // }

    private void AddToTeam()
    {
        ListDevelopers();

    }

    private void UpdateDeveloperInfo()
    {
        //todo - reference streaming content
    }

    public void CreateNewTeam()
    {
        //todo
        // same as add developer
        var devTeam = new DevTeam();
        WriteLine("Please input a team name: ");
        string userInput_DevTeamName = ReadLine()!;
        devTeam.TeamName = userInput_DevTeamName;
        PressAnyKey();
       // todo: add team members - may be a spearate method
       WriteLine("Please input a team ID: ");
       string userInput_TeamNumber = ReadLine()!;
       int userInput_TeamIDNumber = int.Parse(userInput_TeamNumber);
       devTeam.TeamId = userInput_TeamIDNumber;
       PressAnyKey();
    }

    private void RemoveDevelopers()
    {
        ListDevelopers();
        WriteLine("please enter the ID Number of the developer you would like to remove: ");
        string userInput_RmId = ReadLine()!;
        int userInput_RemoveId = int.Parse(userInput_RmId);
        if (_devRepo.RemoveDeveloper(userInput_RemoveId))
        {
            System.Console.WriteLine("Developer successfully removed");
        }
        else
        {
            System.Console.WriteLine("failed to remove. please try again");
        }
        PressAnyKey();
    }

    private bool CloseApp()
    {
        // Clear();
        WriteLine("thx");
        return false;
    }

    private void PressAnyKey()
    {
        WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ListDevelopers()
    {
        // Clear();
        List<Developer> devsInDb = _devRepo.GetDevelopers();       
        foreach (Developer dev in devsInDb)
        {
            WriteLine(dev);
            WriteLine("------------------\n");
        }
        PressAnyKey();
    }

    private void AddDeveloper()
    {
        // Clear();
        var developer = new Developer();
        WriteLine("please input first name: ");
        string userInput_FirstName = ReadLine()!;
        developer.FirstName = userInput_FirstName;
        PressAnyKey();
        WriteLine("please input last name: ");
        string userInput_LastName = ReadLine()!;
        developer.LastName = userInput_LastName;
        PressAnyKey();
        WriteLine("please input ID number: ");      
        string userInput_IdNumber = ReadLine()!;    
        int userInput_Id = int.Parse(userInput_IdNumber);
        developer.Id = userInput_Id;        
        PressAnyKey();
        WriteLine("Do you have Pluralsight? (Y/N)");
        string userInput_HasPluralsight = ReadLine()!.ToUpper();
        switch (userInput_HasPluralsight)
        {
            case "Y":
            case "YES":
                developer.HasPluralsight = true;
                return;
            default:
                developer.HasPluralsight = false;
                break;
        }       //* note to self: anything other than YES or Y will default to false
                //* to make it catch typos, need a while loop
        PressAnyKey();
        WriteLine("please input a team name: ");
        string userInput_TeamName = ReadLine()!;
        developer.TeamName = userInput_TeamName;
        PressAnyKey();
    }

}