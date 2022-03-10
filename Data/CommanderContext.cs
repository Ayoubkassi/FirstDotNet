using Microsoft.EntityFrameworkCore;
using Commander.Models;

namespace Commander.Data
{
  public class CommanderContext : DbContext
  {
      public CommanderContext(DbContextOptions<CommanderContext> opt): base(opt)
      {

      }

      public DbSet<Command> Commands { get; set; }
  }
}
