using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data

{
  public class MockCommanderRepo : ICommanderRepo
  {

    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>

      {
        new Command{Id= 0 , HowTo="Paccicio" , Line ="Coca" , Platform = "Mini House"},
        new Command{Id= 1 , HowTo="Tacos" , Line ="Pepsi" , Platform = "Macdo"},
        new Command{Id= 2 , HowTo="Pizza" , Line ="Hawai" , Platform = "Burger King"}
      };

      return commands;
    }

    public Command GetCommandById(int id)
    {
      return new Command{Id= 0 , HowTo="Paccicio" , Line ="Coca" , Platform = "Mini House"};

    }

    public bool SaveChanges()
    {

    }
  }
}
