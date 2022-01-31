using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateGameDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string DevelopmentStudio { get; set; }
        [Required]
        public string GameGenre { get; set; }
    }
}