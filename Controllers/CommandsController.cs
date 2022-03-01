using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  //api/commands
  [Route("api/v1/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly MockCommanderRepo _repository = new MockCommanderRepo();
    //GET api/v1/commands
    [HttpGet]
    public ActionResult <IEnumerable<Command>> GetAllCommands()
    {
      var commandItems = _repository.GetAppCommands();

      return Ok(commandItems);
    }

    //GET api/v1/commands/{id}
    [HttpGet("{id}")]
    public ActionResult <Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);

      return Ok(commandItem);
    }
  }
}
