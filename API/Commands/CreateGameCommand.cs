using System.ComponentModel.DataAnnotations;
using API.Dtos;
using MediatR;

namespace API.Commands
{
    public class CreateGameCommand : IRequest<ReadGameDto>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string DevelopmentStudio { get; set; }
        [Required]
        public string GameGenre { get; set; }
    }
}