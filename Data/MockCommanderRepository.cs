using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command
                {
                Id = 0,
                HowTo = "Boil an egg",
                Line = "Boil water",
                Platform = "Kettle & Pan"
                },
                new Command
                {
                Id = 1,
                HowTo = "Cut bread",
                Line = "Get a knife",
                Platform = "Knife & chopping board"
                },
                new Command
                {
                Id = 2,
                HowTo = "Make cup of tea",
                Line = "Place teabug in cup",
                Platform = "Kettle & Cup"
                }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return GetAppCommands().FirstOrDefault(n => n.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}