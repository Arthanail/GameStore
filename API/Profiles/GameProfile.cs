using API.Commands;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, ReadGameDto>();
            CreateMap<CreateGameCommand, Game>();
            CreateMap<UpdateGameCommand, Game>();
            CreateMap<ReadGameDto, PublishedGameDto>();
        }
    }
}