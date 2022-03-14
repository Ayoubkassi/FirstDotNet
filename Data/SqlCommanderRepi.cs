using System.Collections.Generic;
using Commander.Models;
using System.Linq;
using System;

namespace Commander.Data

{
  public class SqlCommanderRepo : ICommanderRepo
  {
      private readonly CommanderContext _context;

      public void CreateCommand(Command cmd)
      {
        if(cmd == null)
          throw new ArgumentNullException(nameof(cmd));

        _context.Commands.Add(cmd);
      }

      public bool SaveChanges()
      {
        return(_context.SaveChanges() >= 0);
      }

      //Update Command
      public void UpdateCommand(Command cmd)
      {
        throw new System.NotImplementedException();
      }

      //Delete Command
      public void UpdateCommand(Command cmd)
      {
        if(cmd == null)
        {
          throw new ArgumentNullException(nameof(cmd));
        }

        _context.Commands.Remove(cmd);
      }

      public SqlCommanderRepo(CommanderContext context)
      {
        _context = context;
      }
      public IEnumerable<Command> GetAllCommands()
      {
        return _context.Commands.ToList();
      }

      public Command GetCommandById(int id)
      {
        return _context.Commands.FirstOrDefault(p => p.Id == id);
      }
  }
}
