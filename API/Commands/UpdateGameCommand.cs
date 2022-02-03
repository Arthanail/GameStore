using System;
using API.Dtos;
using MediatR;

namespace API.Commands
{
    public class UpdateGameCommand : IRequest<ReadGameDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DevelopmentStudio { get; set; }
        public string GameGenre { get; set; }
    }
}