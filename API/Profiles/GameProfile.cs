using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<CreateGameDto, Game>();
            CreateMap<Game, ReadGameDto>();
            CreateMap<UpdateGameDto, Game>();
            CreateMap<ReadGameDto, PublishedGameDto>();
        }
    }
}