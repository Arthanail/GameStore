using System.ComponentModel.DataAnnotations;
using API.Dtos;
using MediatR;

namespace API.Commands
{
    public record CreateGameCommand : IRequest<ReadGameDto>
    {
        [Required]
        public string Title { get; init; }
        [Required]
        public string DevelopmentStudio { get; init; }
        [Required]
        public string GameGenre { get; init; }
    }
}