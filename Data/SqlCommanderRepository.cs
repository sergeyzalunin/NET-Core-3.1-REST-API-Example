using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext context;

        public SqlCommanderRepository(CommanderContext context)
        {
            this.context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentException(nameof(cmd));
            }
            context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentException(nameof(cmd));
            }
            context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return context.Commands.FirstOrDefault(n => n.Id == id);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        public void UpdateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentException(nameof(cmd));
            }
            context.Commands.Update(cmd);
        }
    }
}