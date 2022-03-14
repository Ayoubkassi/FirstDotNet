using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles;

{
  public class CommandsProfile : Profile
  {
    public CommandsProfile()
    {
      CreateMap<Command, CommandReadDto>();
    }
  }
}
