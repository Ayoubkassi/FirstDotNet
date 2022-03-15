using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using System.Collections.Generic;
using Commander.Data;
using AutoMapper;
using Commander.Dtos;

namespace Commander.Controllers
{

  //api/commands
  [Route("api/v1/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository , IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
    //GET api/v1/commands
    [HttpGet]
    public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();

      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    //GET api/v1/commands/{id}
    [HttpGet("{id}", Name="GetCommandById")]
    public ActionResult <CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if(commandItem !=  null)
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      //NO Id in DB
      return NotFound();
    }

    //POST API Command
    //POST /api/v1/commands
    [HttpPost]
    public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();

      var CommandReadDto = _mapper.Map<CommandReadDto>(commandModel);

      return CreatedAtRoute(nameof(GetCommandById), new {Id = CommandReadDto.Id}, CommandReadDto);
      //return Ok(commandModel);
    }

    //PUT api/v1/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    //Delete /api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if(commandModelFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteCommand(commandModelFromRepo);

      _repository.SaveChanges();

      return NoContent();

    }

  }
}
