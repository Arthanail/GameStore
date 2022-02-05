using API.Dtos;
using MediatR;

namespace API.Commands
{
    public record UpdateGameCommand : IRequest<ReadGameDto>
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string DevelopmentStudio { get; init; }
        public string GameGenre { get; init; }
    }
}